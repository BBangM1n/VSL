using System;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    // Events
    public event Action<float> OnHit;

    // Event Handlers
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack"))
        {
            OnHit?.Invoke(1);
        }

        if (other.CompareTag("Skill"))
        {
            var damage = other.GetComponent<SkillBase>().Damage;
            OnHit?.Invoke(damage);
        }
    }
}
