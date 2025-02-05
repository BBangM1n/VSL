using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log($"OnTriggerEnter2D with: {other.name}");
        if (other.CompareTag("Monster"))
        {
            Debug.Log("Hit with Monster! OnTriggerEnter2D");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log($"OnTriggerStay2D with: {other.name}");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log($"OnTriggerExit2D with: {other.name}");
    }
}
