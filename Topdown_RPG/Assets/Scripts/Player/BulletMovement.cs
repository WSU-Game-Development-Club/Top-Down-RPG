using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // the player's speed in units/second
    [SerializeField] private float bulletSpeed;


    [SerializeField] private float bulletLife;

    // reference to game object's rigidbody behavior
    private Rigidbody2D rb;


    private float timer;


    // called when script is loaded into memory
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);

        timer += Time.deltaTime;
        if(timer > bulletLife)
        {
            Destroy(gameObject);
            timer = 0;
        }
    }
}
