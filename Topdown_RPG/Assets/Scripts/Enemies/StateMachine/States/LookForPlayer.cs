using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayer : EnemyState
{

    [SerializeField] private LayerMask _environmentLayer;
    [SerializeField] private float _detectionRange;
    private PlayerController _player;
    protected override void OnEnable() {
        base.OnEnable();
        _player  = FindObjectOfType<PlayerController>();

    }

    private void Update() {
        float distToPlayer = Vector2.Distance(_player.transform.position, _enemySM.transform.position);
        if ( distToPlayer > _detectionRange) {
            return;
        }
        Vector2 dirToPlayer = _player.transform.position - _enemySM.transform.position;
        if(Physics2D.CircleCast(_enemySM.transform.position, _enemySM.Collider.radius, dirToPlayer, distToPlayer, _environmentLayer)) {
            //return;
        }
        _enemySM.SwitchState(_stateToExitTo);
    }

}
