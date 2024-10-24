using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Somthing : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.TryGetComponent(out IDamageable damagable))
        {
            damagable.Damage(100);
        }
        Destroy(gameObject);
    }
}
