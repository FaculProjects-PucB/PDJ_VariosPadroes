using UnityEngine;

public class EnemyStateWalking : EnemyState
{
    GameObject player;
    EnemyBehavior enemy;

    public EnemyStateWalking(EnemyBehavior enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        player = GameManager.Instance.GetPlayer();
    }

    public void OnState()
    {
        if (player == null)
        {
            player = GameManager.Instance.GetPlayer();
            return;
        }

        Vector3 dir = player.transform.position - enemy.transform.position;

        enemy.transform.LookAt(player.transform);
        enemy.transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
    }
}
