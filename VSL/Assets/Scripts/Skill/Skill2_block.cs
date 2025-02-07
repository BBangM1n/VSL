using UnityEngine;

public class Skill2_block : SkillBase
{
    // Fields
    private Vector3 direction;

    // Inheritances
    public override void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
    }
    protected override void Move()
    {
        if (direction != Vector3.zero)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
