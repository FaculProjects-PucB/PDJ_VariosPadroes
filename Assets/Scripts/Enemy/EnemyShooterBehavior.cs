using UnityEngine;

public class EnemyShooterBehavior : EnemyBehavior
{
    [SerializeField] private GameObject shoot;
    [SerializeField] private float shootInterval;

    private GameObject player;
    private float playerDistance;
    private bool isShooting;
    private float cooldown;

    protected override void Start()
    {
        base.Start();
        player = GameManager.Instance.GetPlayer();
        cooldown = 0;
    }

    protected override void Update()
    {
        base.Update();
        CheckPlayerDistance();
        cooldown -= Time.deltaTime;

        if (isShooting)
        {
            TryShoot();
        }
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

    private void TryShoot()
    {
        if (player == null || shoot == null || cooldown > 0) return;

        cooldown = shootInterval;
        Vector3 targetPosition = new Vector3(
            player.transform.position.x,
            transform.position.y,
            player.transform.position.z
        );
        Quaternion rotation = Quaternion.LookRotation(targetPosition - transform.position);
        Instantiate(shoot, transform.position, rotation);
    }
}
