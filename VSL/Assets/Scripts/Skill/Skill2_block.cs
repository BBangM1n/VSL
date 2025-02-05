using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2_block : SkillBase
{
    private Vector3 direction;

    // 방향 설정
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
