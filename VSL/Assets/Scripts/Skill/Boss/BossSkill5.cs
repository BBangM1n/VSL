using UnityEngine;

public class BossSkill5 : SkillBase
{
    // Fields
    private Vector3 direction;

    // Inheritances
    public override void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    protected override void Move()
    {
        if (direction != Vector3.zero)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
