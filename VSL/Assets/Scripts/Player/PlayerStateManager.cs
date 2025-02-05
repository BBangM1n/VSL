using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    // Fields
    [SerializeField] private PlayerState currentState = PlayerState.Idle;

    public PlayerState CurrentState => currentState;

    // Methods
    public void ChangeState(PlayerState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
            //Debug.Log($"Player state changed to: {newState}");
        }
    }
}
