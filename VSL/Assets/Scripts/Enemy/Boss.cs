using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Fields
    [SerializeField] private EnemyMove move;
    [SerializeField] private EnemyHitBox hitbox;
    [SerializeField] private SpriteRenderer[] spriteRenderers;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private Rigidbody2D target;
    [SerializeField] private Animator anim;

    [SerializeField] private GameObject[] skillPrefabs;
    [SerializeField] private Transform point;

    public float MaxHealth = 2;
    public float NowHealth = 2;

    public bool stopMove = false;

    private bool IsHit = false;

    private bool isPatternRunning = false;
    private int patternNumber;

    // Unity Messages
    void Awake()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        target = GameManager.Instance.player.GetComponent<Rigidbody2D>();

        StartCoroutine(PatternLoop());
    }
    private void OnEnable()
    {
        hitbox.OnHit += onDamage;
        SetAnimatorRunState(0.5f);
    }
    private void OnDisable()
    {
        hitbox.OnHit -= onDamage;
    }
    private void FixedUpdate()
    {
        if (!stopMove)
        {
            move.MoveTowardsTarget(rigid, target);
        }
        else
        {
            rigid.velocity = Vector3.zero;
        }
    }
    private void LateUpdate()
    {
        move.UpdateRotation(target);
        Debug.Log(target.position);
    }

    // Methods
    // Functions
    private void SetAnimatorRunState(float state)
    {
        if (anim != null)
        {
            anim.SetFloat("RunState", state);
        }
    }
    private void onDie()
    {
        GameManager.Instance.UnitCount--;
        GameManager.Instance.getExp(1);
        gameObject.SetActive(false);
        NowHealth = MaxHealth; // 피 초기화
    }
    private void SetAnimatorAttackState(float AttackState = 0, float NormalState = 0, float SkillState = 0)
    {
        anim.SetFloat("AttackState", AttackState);
        anim.SetFloat("NormalState", NormalState);
        anim.SetFloat("SkillState", SkillState);
    }
    // Event Handlers
    private void onDamage(float Damage)
    {
        if (!IsHit)
        {
            NowHealth -= Damage;

            if (NowHealth <= 0)
            {
                onDie();
            }
            else
            {
                StartCoroutine(OnDamageCoroutine());
            }
        }
    }

    // Unity Coroutine
    IEnumerator OnDamageCoroutine()
    {
        IsHit = true;

        for (int i = 0; i < spriteRenderers.Length - 1; i++)
        {
            spriteRenderers[i].color = Color.red;
        }

        yield return new WaitForSeconds(0.5f);

        IsHit = false;

        for (int i = 0; i < spriteRenderers.Length - 1; i++)
        {
            spriteRenderers[i].color = Color.white;
        }
    }
    // 패턴 루프
    IEnumerator PatternLoop()
    {
        while (true)
        {
            if (!isPatternRunning)
            {
                patternNumber = Random.Range(0, 5); // 0~4 패턴 중 하나 선택
                isPatternRunning = true;

                switch (patternNumber)
                {
                    case 0:
                        yield return StartCoroutine(Pattern0());
                        break;
                    case 1:
                        yield return StartCoroutine(Pattern1());
                        break;
                    case 2:
                        yield return StartCoroutine(Pattern2());
                        break;
                    case 3:
                        yield return StartCoroutine(Pattern3());
                        break;
                    case 4:
                        yield return StartCoroutine(Pattern4());
                        break;
                }

                isPatternRunning = false;

                // 패턴 사이 딜레이
                yield return new WaitForSeconds(10.0f);
            }

            yield return null;
        }
    }

    // 패턴 0: 근접 공격 AttackState = 0, NormalState = 0
    IEnumerator Pattern0()
    {
        SetAnimatorAttackState(0, 0);

        move.Speed = 7;

        bool skillCreated = false;

        while (!skillCreated)
        {
            float distance = Vector2.Distance(transform.position, target.position);

            if (distance <= 7f)
            {
                stopMove = true;
                anim.SetTrigger("Attack");
                GameObject skill = Instantiate(skillPrefabs[0], transform.position, Quaternion.identity);
                skill.GetComponent<SkillBase>().SetDirection(target.position);
                Debug.Log(target.position);
                skillCreated = true;
            }

            yield return null;
        }

        yield return new WaitForSeconds(1.5f);

        move.Speed = 2.5f;
        stopMove = false;
    }

    // 패턴 1: 회오리 소환 AttackState = 0, NormalState = 1
    IEnumerator Pattern1()
    {
        SetAnimatorAttackState(0, 1);

        stopMove = true;

        yield return new WaitForSeconds(0.5f);

        anim.SetTrigger("Attack");
        GameObject skill = Instantiate(skillPrefabs[1], transform.position, Quaternion.identity);
        skill.GetComponent<SkillBase>().SetDirection(target.position);

        yield return new WaitForSeconds(2.0f);

        stopMove = false;
    }

    // 패턴 2: 에너지파 AttackState = 1, SkillState = 0
    IEnumerator Pattern2()
    {
        SetAnimatorAttackState(1, 0, 0);

        move.Speed = 7;

        yield return new WaitForSeconds(1.5f);

        stopMove = true;
        SetAnimatorRunState(0);

        yield return new WaitForSeconds(3f);

        anim.SetTrigger("Attack");
        Vector3 direction = ((Vector3)target.position - transform.position).normalized;
        GameObject skill = Instantiate(skillPrefabs[2], transform.position, Quaternion.identity);
        skill.GetComponent<SkillBase>().SetDirection(direction);

        yield return new WaitForSeconds(1.5f);

        move.Speed = 2.5f;
        stopMove = false;
        SetAnimatorRunState(0.5f);
    }

    // 패턴 3: 함정 설치 AttackState = 1, SkillState = 1
    IEnumerator Pattern3()
    {
        SetAnimatorAttackState(1, 0, 1);

        stopMove = true;

        yield return new WaitForSeconds(0.5f);

        anim.SetTrigger("Attack");

        int sphereCount = 5; // 생성할 구체 개수
        float spawnRadius = 30.0f; // 보스를 중심으로 생성할 반경

        for (int i = 0; i < sphereCount; i++)
        {
            Vector3 randomPos = point.position + (Vector3)Random.insideUnitCircle * spawnRadius;
            Instantiate(skillPrefabs[3], randomPos, Quaternion.identity);
        }
        yield return new WaitForSeconds(2.0f);

        stopMove = false;
    }

    // 패턴 4: 전방향 위험 AttackState = 1, SkillState = 0.5
    IEnumerator Pattern4()
    {
        SetAnimatorAttackState(1, 0, 0.5f);

        stopMove = true;

        yield return new WaitForSeconds(0.5f);

        anim.SetTrigger("Attack");
        Instantiate(skillPrefabs[4], point.position, Quaternion.identity);

        yield return new WaitForSeconds(2.0f);

        stopMove = false;
    }
}
