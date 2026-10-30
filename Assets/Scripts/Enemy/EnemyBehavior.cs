using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private EnemyState state;

    public float speed;

    protected virtual void Start()
    {
        state = new EnemyStateWalking(this);
        state?.Enter();
    }

    protected virtual void Update()
    {
        state?.OnState();
    }

    public void ChangeState(EnemyState newState)
    {
        state = newState;
        state?.Enter();
    }
}
