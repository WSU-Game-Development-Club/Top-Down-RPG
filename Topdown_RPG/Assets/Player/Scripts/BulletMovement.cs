using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// creates the bullet and translate it a certain direction for a x ammount of time
/// </summary>
public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletLife;    
    [SerializeField] private GameObject hitIndicator;

    // reference to game object's rigidbody behavior
    private Rigidbody2D rb;

    private CapsuleCollider2D bulletColider;

    private float timer;

    // called when script is loaded into memory
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && bulletColider.enabled)
        {
            Destroy(gameObject);
            Instantiate(hitIndicator);
        }
    }
}
