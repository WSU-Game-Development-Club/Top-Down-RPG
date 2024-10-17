using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Movement state that makes the character run away from the player
public class FleeFromPlayerState : EnemyState {

    [SerializeField] private Vector2 _distanceRange;//How far should the character run?
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
        _target = GetDirectionAwayFromPlayer(_distanceRange);
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
    /// Returns the dir away from the player, if there is a wall the character will move away from the wall
    /// </summary>
    /// <param name="distanceRange">the min and max distance the character should randomly travel</param>
    /// <returns>A Vector2 representing the position in world space</returns>
    public Vector2 GetDirectionAwayFromPlayer(Vector2 distanceRange) {

        Vector2 targetPosition = _enemySM.transform.position;

        Vector2 dirAway = -(_player.transform.position - _enemySM.transform.position).normalized;
        float randomDistance = Random.Range(distanceRange.x, distanceRange.y);
        targetPosition = (Vector2)_enemySM.transform.position + dirAway * randomDistance;

        RaycastHit2D hit = Physics2D.CircleCast(_enemySM.transform.position, _enemySM.Collider.radius, dirAway, randomDistance, _environmentLayer);

        if (hit.collider != null) {
            targetPosition = hit.point + hit.normal * _enemySM.Collider.radius;
            if (Vector2.Distance(_enemySM.transform.position, _player.transform.position) < distanceRange.x 
                && Vector2.Distance(targetPosition, _enemySM.transform.position)< distanceRange.x) {


                dirAway = hit.normal;

                targetPosition = (Vector2)_enemySM.transform.position + dirAway * randomDistance;
            }
        }
        return targetPosition;
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
