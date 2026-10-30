using UnityEngine;

public class EnemyShooterBehavior : EnemyBehavior
{
    private GameObject player;
    private float playerDistance;
    private bool isShooting;

    protected override void Start()
    {
        base.Start();
        player = GameManager.Instance.GetPlayer();
    }

    protected override void Update()
    {
        base.Update();
        CheckPlayerDistance();
    }
    
    private void CheckPlayerDistance()
    {
        if (player == null)
        {
            player = GameManager.Instance.GetPlayer();
            return;
        }

        playerDistance = Vector3.Distance(player.transform.position, transform.position);

        if (playerDistance <= Attributes.range)
        {
            if (!isShooting)
            {
                ChangeState(new EnemyStateShooting(this));
                isShooting = true;
            }
        }else
        {
            if (isShooting)
            {
                ChangeState(new EnemyStateWalking(this));
                isShooting = false;
            }
        }
    }
}
