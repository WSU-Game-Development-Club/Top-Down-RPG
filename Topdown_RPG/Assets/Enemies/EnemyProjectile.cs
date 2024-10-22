using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.TryGetComponent(out IDamageable damageable)) {
            damageable.Damage(damage);
        }
        Destroy(gameObject);
    }

}
