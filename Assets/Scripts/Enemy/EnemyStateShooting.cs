using UnityEngine;

public class EnemyStateShooting : EnemyState
{
    GameObject target;
    EnemyShooterBehavior enemy;

    public EnemyStateShooting(EnemyShooterBehavior enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        target = enemy.target;
    }

    public void OnState()
    {
        if (target == null) return;

        enemy.transform.LookAt(target.transform);
    }
}
