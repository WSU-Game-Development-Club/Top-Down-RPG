using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] private string triggeredByTag;
    [SerializeField] private UnityEvent<GameObject> onTriggerTouched;
    [SerializeField] private UnityEvent<GameObject> onTriggerUntouched;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(triggeredByTag))
        {
            onTriggerTouched.Invoke(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(triggeredByTag))
        {
            onTriggerUntouched.Invoke(collision.gameObject);
        }
    }
}
