using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile {
    [SerializeField] private float damage;
    [SerializeField] private float knockback;
    [SerializeField] private GameObject hitIndicator;
    private void OnTriggerEnter2D(Collider2D collision) {
        //Debug.Log($"Collision with {collision.gameObject.name}");
        if (collision.TryGetComponent(out IDamageable damageable)) {
            damageable.Damage(damage);
            Instantiate(hitIndicator);
            

        }
        if(collision.TryGetComponent(out IKnockbackable knockbackable)) {
            Vector2 dir = rb.velocity.normalized;
            knockbackable.Knockback(dir * knockback);
        }
        Destroy(gameObject);
    }
}
