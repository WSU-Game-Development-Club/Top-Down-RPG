using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargePlayerState : EnemyState
{


    [SerializeField] private float _overShotDistance;
    [SerializeField] private bool _useDefaultSpeedAndForce;//Should the character use the default speed/accel
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _movementForce;

    private Vector2 _target;
    private float _abortTime;
    private PlayerController _player;
    protected override void OnEnable() {
        base.OnEnable();
        if (_stateToExitTo == null) {
            _stateToExitTo = this;
        }
        _player = FindObjectOfType<PlayerController>();
        _target = GetDirectionToPlayer(_overShotDistance);
        EnemyMovementParameters parameters = _enemySM.MovementParameters;
        parameters.Target = _target;
        if (!_useDefaultSpeedAndForce) {
            parameters.Speed = _movementSpeed;
            parameters.Force = _movementForce;
        }
        _enemySM.MovementParameters = parameters;
        _player = FindObjectOfType<PlayerController>();
        _abortTime = parameters.Speed > 0 ? (Vector2.Distance(_enemySM.transform.position, _target) / parameters.Speed) * 2f : Mathf.Infinity;

    }

    [SerializeField] private LayerMask _environmentLayer;

    /// <summary>
    /// Returns the the player position plus overshot
    /// </summary>
    /// <param name="overShotDistance">the amount to overshoot by</param>
    /// <returns>A Vector2 representing the position in world space</returns>
    public Vector2 GetDirectionToPlayer(float overShotDistance) {

        Vector2 targetPosition = _player.transform.position;

        Vector2 moveToPlayer = (_player.transform.position - _enemySM.transform.position);
        Vector2 overShot = moveToPlayer.normalized * overShotDistance;
        
        return targetPosition + overShot;
    }
    private void FixedUpdate() {
        float closeEnoughDistance = _enemySM.Collider.radius * 0.5f;
        if (Vector2.Distance(_enemySM.transform.position, _target) <= closeEnoughDistance) {
            _enemySM.SwitchState(_stateToExitTo);
            return;
        }
        if (Time.time - _timeEntered > _abortTime) {
            _enemySM.SwitchState(_stateToExitTo);

            return;
        }
    }
}
