using System.Collections;
using UnityEngine;

public class BossSkill4 : SkillBase
{
    // Fields
    [SerializeField] private float maxScale = 2.0f;
    [SerializeField] private float growthSpeed = 0.2f;
    [SerializeField] private float lifeTime = 10f;

    private Vector3 initialScale;

    // Inheritances
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

    // Unity Coroutine
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
