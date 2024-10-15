using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This state moves the character to a random position nearby, then exits
public class MoveRandomlyState : EnemyState
{

    [SerializeField] private Vector2 _distanceRange;

    [SerializeField] private bool _useDefaultSpeedAndForce;

    [SerializeField] private float _movementSpeed;

    [SerializeField] private float _movementForce;


    private Vector2 _target;
    private float _abortTime;

    protected override void OnEnable() {
        base.OnEnable();
        if (_stateToExitTo == null) {
            _stateToExitTo = this;
        }

        _target = GetRandomPosition(_distanceRange);
        EnemyMovementParameters parameters = _enemySM.MovementParameters;
        parameters.Target = _target;
        if (!_useDefaultSpeedAndForce) {
            parameters.Speed = _movementSpeed;
            parameters.Force = _movementForce;
        } 
        _enemySM.MovementParameters = parameters;

        _abortTime = parameters.Speed > 0 ? (Vector2.Distance(_enemySM.transform.position, _target) / parameters.Speed) * 2f : Mathf.Infinity;

    }

    [SerializeField] private LayerMask _environmentLayer;

    /// <summary>
    /// Gets a random position nearby that the character can move to
    /// </summary>
    /// <param name="distanceRange">the min and max distance the character should randomly travel</param>
    /// <returns>A Vector2 representing the position in world space</returns>
    public Vector2 GetRandomPosition(Vector2 distanceRange) {

        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float randomDistance = Random.Range(distanceRange.x, distanceRange.y);
        Vector2 targetPosition = (Vector2)_enemySM.transform.position + randomDirection * randomDistance;
        RaycastHit2D hit = Physics2D.CircleCast(_enemySM.transform.position, _enemySM.Collider.radius, randomDirection, randomDistance, _environmentLayer);

        if (hit.collider != null) {
            return hit.point + hit.normal * _enemySM.Collider.radius;
        }
        return targetPosition;
    }
    private void FixedUpdate() {
        float closeEnoughDistance = _enemySM.Collider.radius * 0.5f;
        if(Vector2.Distance(_enemySM.transform.position, _target) <= closeEnoughDistance) {
            _enemySM.SwitchState(_stateToExitTo);
            return;
        }
        if(Time.time - _timeEntered > _abortTime) {
            _enemySM.SwitchState(_stateToExitTo);

            return;
        }
    }
}
