using UnityEngine;

public class EnemyStateShooting : EnemyState
{
    GameObject player;
    EnemyShooterBehavior enemy;

    public EnemyStateShooting(EnemyShooterBehavior enemy)
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

        enemy.transform.LookAt(player.transform);
    }
}
