using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Fields
    [SerializeField] private Animator anim;
    [SerializeField] private SkillManager skillManager;
    [SerializeField] private Button[] skillButton;

    private PlayerStateManager stateManager;
    private PlayerMove movement;
    private PlayerAttack attack;

    public int temp = 1;
    public Vector3 direction;

    // Unity Messages
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        stateManager = GetComponent<PlayerStateManager>();
        movement = GetComponent<PlayerMove>();
        attack = GetComponent<PlayerAttack>();

        attack.Initialize(anim, stateManager);
        movement.Initialize(anim, stateManager);

        skillButton[0].onClick.AddListener(() =>
        {
            skillManager.CastSkill("Skill1", direction);
        });

        skillButton[1].onClick.AddListener(() =>
        {
            skillManager.CastSkill("Skill2", Vector3.zero, temp);
        });
    }
    private void Update()
    {
        direction = movement.GetInputDirection();

        movement.HandleMovement(direction);

        if (Input.GetKeyDown(KeyCode.A))
        {
            attack.PerformAttack();
        }

        if (Input.GetKeyDown(KeyCode.S) && direction != Vector3.zero)
        {
            skillManager.CastSkill("Skill1", direction);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            skillManager.CastSkill("Skill2", Vector3.zero, temp);
        }
    }

}