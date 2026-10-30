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
        float speed = enemy.onDebuff ? enemy.Attributes.speed / 4f : enemy.Attributes.speed;

        enemy.transform.LookAt(target.transform);
        enemy.transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }
}
