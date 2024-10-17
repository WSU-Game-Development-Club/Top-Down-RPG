using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Fire(Vector2 dir) {
        GetComponent<Rigidbody2D>().velocity = dir.normalized * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(!collision.gameObject.TryGetComponent(out EnemySM _) && !collision.gameObject.TryGetComponent(out Projectile _)) {
            Destroy(gameObject);
        }
    }
}
