using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//EnemyStates that extend this should be attached to their own GameObject
public abstract class EnemyState : MonoBehaviour
{
    [SerializeField] protected EnemyState _stateToExitTo;
    protected EnemySM _enemySM;
    protected float _timeEntered;
    protected virtual void OnEnable() {
        if (_stateToExitTo == null) {
            _stateToExitTo = this;
        }
        _enemySM = GetComponentInParent<EnemySM>();
        _timeEntered = Time.time;
    }
}
