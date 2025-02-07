using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    // Event Handlers
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log($"OnTriggerEnter2D with: {other.name}");
        if (other.CompareTag("Monster"))
        {
            Debug.Log("Hit with Monster! OnTriggerEnter2D");
        }
    }
}
