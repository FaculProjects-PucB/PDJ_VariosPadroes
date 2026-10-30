using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private GameObject player;
    private EnemySpawner enemySpawner;

    [SerializeField] private float enemySpawnInterval;
    private float cooldown;


    void Start()
    {
        player = GameManager.Instance.GetPlayer();
        enemySpawner = GetComponent<EnemySpawner>();

        cooldown = 0;
    }

    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            SpawnEnemy();
            cooldown = enemySpawnInterval;
        }
    }

    void SpawnEnemy()
    {
        EnemyBehavior enemy = enemySpawner.CreateEnemy();
        enemy.target = player;
        enemy.transform.position = new Vector3(
            Random.Range(0f, 5f),
            2,
            Random.Range(0f, 5f)
        );
    }
}