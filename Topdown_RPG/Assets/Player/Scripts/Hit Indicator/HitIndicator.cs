using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// it like idk destroy itself or somthing, not sure, hmmmm ummm
/// </summary>
public class HitIndicator : MonoBehaviour
{
    // This method will be triggered by the Animation Event
    public void DestroySelf()
    {
        Destroy(transform.parent.gameObject);
    }
}
