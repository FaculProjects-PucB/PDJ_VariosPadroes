using UnityEngine;

public class EnemyShooterBehavior : EnemyBehavior
{
    private EnemyState state;
    private GameObject player;

    [SerializeField] private float range;
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
        playerDistance = Vector3.Distance(player.transform.position, transform.position);

        if (playerDistance <= range)
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
