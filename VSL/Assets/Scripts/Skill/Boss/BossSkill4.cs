using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill4 : SkillBase
{
    [SerializeField] private float maxScale = 2.0f; // �ִ� ũ��
    [SerializeField] private float growthSpeed = 0.2f; // ���� �ӵ�
    [SerializeField] private float lifeTime = 10f; // 10�� �� ����

    private Vector3 initialScale;

    protected override void Start()
    {
        base.Start();
        initialScale = transform.localScale;
        StartCoroutine(GrowAndDisappear());
    }

    public override void SetDirection(Vector3 newDirection)
    {
        // �̵����� �����Ƿ� �����
    }

    protected override void Move()
    {
        // �̵����� �����Ƿ� �����
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
