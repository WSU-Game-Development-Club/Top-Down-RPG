using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float lifespan = 1f;

    protected Rigidbody2D rb;

    private float timeAwakened;
    public void Fire(Vector2 dir) {
        if(rb == null) {
            rb = GetComponent<Rigidbody2D>();
        }
        rb.velocity = dir.normalized * speed;
    }
    
    private void Awake() {
        timeAwakened = Time.time;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        if (Time.time - timeAwakened > lifespan) {
            Destroy(gameObject);
        }

    }
}
