using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DEPRECATED: don't use this, extend Projectile instead

/// <summary>
/// creates the bullet and translate it a certain direction for a x ammount of time
/// </summary>
public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletLife;
    [SerializeField] private float bulletDamage;
    [SerializeField] private GameObject hitIndicator;


    private CapsuleCollider2D bulletColider;

    private float timer;

    // called when script is loaded into memory
    private void Awake()
    {
        bulletColider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);

        timer += Time.deltaTime;
        if(timer > bulletLife)
        {
            timer = 0;
            
            Destroy(gameObject);            
        }        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Enemy") && bulletColider.enabled)
    //    {
    //        Destroy(gameObject);
    //        Instantiate(hitIndicator);
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy")&& bulletColider.enabled)
        {
            if(collision.gameObject.TryGetComponent(out IDamageable enemy))
            {
                enemy.Damage(bulletDamage);
            }
            Destroy(gameObject);
            Instantiate(hitIndicator);
        }

    }
}
