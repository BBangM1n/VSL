using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2 : SkillBase
{
    // Fields
    public int skillLevel = 1;
    public GameObject projectilePrefab;

    // Methods
    public override void SetDirection(Vector3 newDirection) { }

    protected override void Move()
    {
        Vector3[] directions = GetDirectionsByLevel(skillLevel);
        foreach (var direction in directions)
        {
            SpawnProjectile(direction);
        }

        Destroy(gameObject);
    }

    private void SpawnProjectile(Vector3 direction)
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        var skillBase = projectile.GetComponent<SkillBase>();
        if (skillBase != null)
        {
            skillBase.SetDirection(direction);
        }
    }

    private Vector3[] GetDirectionsByLevel(int level)
    {
        switch (level)
        {
            case 1:
                return new Vector3[] { Vector3.left, Vector3.right };
            case 2:
                return new Vector3[] { Vector3.left, Vector3.right, Vector3.up, Vector3.down };
            case 3:
                return new Vector3[]
                {
                    Vector3.left, Vector3.right, Vector3.up, Vector3.down,
                    new Vector3(-1, 1, 0).normalized, new Vector3(1, -1, 0).normalized
                };
            case 4:
                return new Vector3[]
                {
                    Vector3.left, Vector3.right, Vector3.up, Vector3.down,
                    new Vector3(-1, 1, 0).normalized, new Vector3(1, 1, 0).normalized,
                    new Vector3(-1, -1, 0).normalized, new Vector3(1, -1, 0).normalized
                };
            default:
                return new Vector3[] { Vector3.left, Vector3.right };
        }
    }
}
