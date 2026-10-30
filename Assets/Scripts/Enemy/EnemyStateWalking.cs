using UnityEngine;

public class EnemyStateWalking : EnemyState
{
    GameObject target;
    EnemyBehavior enemy;

    public EnemyStateWalking(EnemyBehavior enemy)
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

        Vector3 dir = target.transform.position - enemy.transform.position;

        enemy.transform.LookAt(target.transform);
        enemy.transform.Translate(dir.normalized * (enemy.onDebuff ? enemy.speed/4: enemy.speed) * Time.deltaTime, Space.World);
    }
}
