using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//EnemyStates that extend this should be attached to their own GameObject
public abstract class EnemyState : MonoBehaviour
{
    [SerializeField] protected EnemyState _stateToExitTo;
    [SerializeField] protected EnemyState _defaultSubState;
    protected EnemySM _enemySM;
    protected float _timeEntered;



    protected virtual void OnEnable() {
        _enemySM = GetComponentInParent<EnemySM>();
        if (_stateToExitTo == null) {
            _stateToExitTo = this;
        }
        if (_defaultSubState != null) {
            _enemySM.SwitchState(_defaultSubState);
        }

        _timeEntered = Time.time;
    }
    public void ExitStateImmediate() {
        if (_stateToExitTo == null) {
            return;
        }
        _enemySM.SwitchState(_stateToExitTo);
    }
}
