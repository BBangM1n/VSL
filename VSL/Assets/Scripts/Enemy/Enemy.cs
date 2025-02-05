using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Fields
    [SerializeField] private EnemyMove move;
    [SerializeField] private EnemyHitBox hitbox;
    [SerializeField] private SpriteRenderer[] spriteRenderers;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private Rigidbody2D target;
    [SerializeField] private Animator anim;

    public float MaxHealth = 2;
    public float NowHealth = 2;

    bool IsHit = false;

    // Unity Messages
    void Awake()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        target = GameManager.Instance.player.GetComponent<Rigidbody2D>();
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
        move.MoveTowardsTarget(rigid, target);
    }
    private void LateUpdate()
    {
        move.UpdateRotation(target);
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
    // Event Handlers
    private void onDamage(float Damage)
    {
        if(!IsHit)
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
    // Interface
}
