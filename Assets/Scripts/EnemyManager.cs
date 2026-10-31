using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Normal = 1,
    Shooter = 2
}

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    private GameObject player;
    private EnemySpawner enemySpawner;

    [SerializeField] private float enemySpawnInterval;
    [SerializeField] private float descreaseSpawnTimeInterval;
    private float cooldown;
    private float descreaseCooldown;

    public List<EnemyBehavior> enemies;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        player = GameManager.Instance.GetPlayer();
        enemySpawner = GetComponent<EnemySpawner>();

        cooldown = 0;
        descreaseCooldown = descreaseSpawnTimeInterval;

        enemies = new List<EnemyBehavior>();
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
        descreaseCooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            SpawnEnemy();
            cooldown = enemySpawnInterval;
        }

        if (descreaseCooldown <= 0)
        {
            descreaseCooldown = descreaseSpawnTimeInterval;
            enemySpawnInterval *= 0.9f;
        }
    }

    void SpawnEnemy()
    {
        EnemyBehavior enemy = enemySpawner.CreateEnemy();
        enemy.target = player;

        Vector2 spawnOffset = Random.insideUnitCircle.normalized * Random.Range(40f, 50f);
        Vector3 spawnPosition = new Vector3(
            player.transform.position.x + spawnOffset.x,
            2,
            player.transform.position.z + spawnOffset.y
        );
        enemy.transform.position = spawnPosition;

        enemies.Add(enemy);
    }
}
