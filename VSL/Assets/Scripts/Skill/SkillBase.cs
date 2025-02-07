using UnityEngine;

public abstract class SkillBase : MonoBehaviour
{
    // Fields
    [SerializeField] protected float speed = 10f;
    [SerializeField] protected float range = 5f;
    protected Vector3 startPosition;

    public float Damage = 3;

    // Inheritances
    protected virtual void Start()
    {
        startPosition = transform.position;
    }
    protected virtual void Update()
    {
        Move();
        CheckRange();
    }
    public abstract void SetDirection(Vector3 direction);

    protected abstract void Move();

    // Functions
    private void CheckRange()
    {
        if (Vector3.Distance(startPosition, transform.position) > range)
        {
            Destroy(gameObject);
        }
    }

    // Methods
    public void ActivateSkill()
    {
        Move();
    }
}