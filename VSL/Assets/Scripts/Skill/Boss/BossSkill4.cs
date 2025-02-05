using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill4 : SkillBase
{
    [SerializeField] private float maxScale = 2.0f; // 최대 크기
    [SerializeField] private float growthSpeed = 0.2f; // 성장 속도
    [SerializeField] private float lifeTime = 10f; // 10초 뒤 제거

    private Vector3 initialScale;

    protected override void Start()
    {
        base.Start();
        initialScale = transform.localScale;
        StartCoroutine(GrowAndDisappear());
    }

    public override void SetDirection(Vector3 newDirection)
    {
        // 이동하지 않으므로 비워둠
    }

    protected override void Move()
    {
        // 이동하지 않으므로 비워둠
    }

    private IEnumerator GrowAndDisappear()
    {
        float elapsedTime = 0f;
        while (elapsedTime < lifeTime)
        {
            transform.localScale = Vector3.Lerp(initialScale, initialScale * maxScale, elapsedTime / lifeTime);
            elapsedTime += Time.deltaTime * growthSpeed;
            yield return null;
        }
        Destroy(gameObject);
    }
}
