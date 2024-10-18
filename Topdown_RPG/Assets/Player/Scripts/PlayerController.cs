using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// In charge of controlling player movement
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    // the player's speed in units/second
    [SerializeField] private float speed;

    // reference to game object's rigidbody behavior
    private Rigidbody2D rb;

    // called when script is loaded into memory
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // called once a game tick
    private void Update()
    {
        // note: using GetAxis() allows use to have some smoothing and damping 
        // built into the input manager, can change to GetAxisRaw() for snappier movement
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")).normalized * speed;
    }
}
