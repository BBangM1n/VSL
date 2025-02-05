using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    // Fields
    [SerializeField] private Button attackButton;
    [SerializeField] private BoxCollider2D boxCollider;

    private Animator anim;
    private PlayerStateManager stateManager;

    // Methods
    public void Initialize(Animator animator, PlayerStateManager manager)
    {
        anim = animator;
        stateManager = manager;
        boxCollider.enabled = false;

        attackButton.onClick.AddListener(PerformAttack);
    }
    public void PerformAttack()
    {
        if (stateManager.CurrentState == PlayerState.Attack) return;

        stateManager.ChangeState(PlayerState.Attack);
        anim.SetTrigger("Attack");
        boxCollider.enabled = true;
        StartCoroutine(ResetToIdleAfterAttack());
    }

    // Unity Coroutine
    private IEnumerator ResetToIdleAfterAttack()
    {
        yield return new WaitForSeconds(0.3f);
        boxCollider.enabled = false;
        stateManager.ChangeState(PlayerState.Idle);
    }
}
