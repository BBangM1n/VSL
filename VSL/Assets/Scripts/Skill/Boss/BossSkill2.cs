using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill2 : SkillBase
{
    private Transform target;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(DestroyObject());
    }

    public override void SetDirection(Vector3 newTarget)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            target = player.transform;
        }
    }

    protected override void Move()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;

            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
