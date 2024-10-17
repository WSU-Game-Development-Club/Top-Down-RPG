using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This state stops the character from moving for a random duration set by the range.
public class HoldStillState : EnemyState
{
    [SerializeField] private Vector2 _durationRange;

    private float _duration;
    protected override void OnEnable() {
        base.OnEnable();
        _duration = Random.Range(_durationRange.x, _durationRange.y);
        _enemySM.ResetMovementParameters();
    }

    private void Update() {
        if(Time.time - _timeEntered > _duration) {
            _enemySM.SwitchState(_stateToExitTo);
        }
    }
     
}
