using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Fields
    public float Speed;

    // Functions
    public void MoveTowardsTarget(Rigidbody2D rigid,Rigidbody2D target)
    {
        Vector2 direction = (Vector2)(target.transform.position - transform.position).normalized;
        rigid.MovePosition(rigid.position + direction * Speed * Time.fixedDeltaTime);
        rigid.velocity = Vector2.zero;
    }
    public void UpdateRotation(Rigidbody2D target)
    {
        float rotationY = target.position.x > transform.position.x ? 180f : 0f;
        transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
