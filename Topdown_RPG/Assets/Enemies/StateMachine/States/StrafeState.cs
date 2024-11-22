using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrafeState : EnemyState
{
    
    [SerializeField] private bool _useDefaultSpeedAndForce;//Should the character use the default speed/accel
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _movementForce;
    [SerializeField] private float _desiredDistance;
    [SerializeField] private float _circleSpeed;


    private PlayerController _player;

    [SerializeField] private float _duration;

    private float _desiredAngle;


    protected override void OnEnable()
    {
        base.OnEnable();
        if (_stateToExitTo == null)
        {
            _stateToExitTo = this;
        }
        _player = FindObjectOfType<PlayerController>();
        Vector2 dirToPlayer = _player.transform.position - transform.position;

        _desiredAngle = Mathf.Atan2(dirToPlayer.x, dirToPlayer.y);

    }

    private void FixedUpdate()
    {
        _desiredAngle += _circleSpeed * Time.deltaTime;
        Vector2 playerPos = _player.transform.position;
        Vector2 desiredPos = playerPos + new Vector2(Mathf.Cos(_desiredAngle), Mathf.Sin(_desiredAngle)) * _desiredDistance;
        EnemyMovementParameters parameters = _enemySM.MovementParameters;
        parameters.Target = desiredPos;
        if (!_useDefaultSpeedAndForce)
        {
            parameters.Speed = _movementSpeed;
            parameters.Force = _movementForce;
        }
        _enemySM.MovementParameters = parameters;
        if (Time.time - _timeEntered > _duration)
        {
            _enemySM.SwitchState(_stateToExitTo);

            return;
        }
    }


}
