using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Fields
    [SerializeField] private bl_Joystick joystick;
    [SerializeField] private float speed;

    private Animator anim;
    private PlayerStateManager stateManager;

    // Methods
    public void Initialize(Animator animator, PlayerStateManager manager)
    {
        anim = animator;
        stateManager = manager;
    }
    public void HandleMovement(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            stateManager.ChangeState(PlayerState.Moving);
            anim.SetFloat("RunState", 0.5f);
            Move(direction);
            FlipCharacter(direction.x);
        }
        else
        {
            stateManager.ChangeState(PlayerState.Idle);
            anim.SetFloat("RunState", 0);
        }
    }
    public Vector3 GetInputDirection()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        return new Vector3(horizontal, vertical, 0).normalized;
    }

    // Functions
    private void Move(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    private void FlipCharacter(float horizontal)
    {
        if (horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
