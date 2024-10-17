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
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        playerLocation = player.transform.position;
        transform.position = (playerLocation);
         
    }
}
