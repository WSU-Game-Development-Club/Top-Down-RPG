using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// keeps hit indicator on top of the player
/// </summary>
public class IndicatorParent : MonoBehaviour
{
    private Transform player;
    private Vector2 playerLocation;
    
    private void Awake()
    {
        // changed to find object of type because it's faster
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
            player = FindObjectOfType<PlayerController>()?.transform;
        
        
    }

    private void Update()
    {
        playerLocation = player.transform.position;
        transform.position = (playerLocation);         
    }
}
