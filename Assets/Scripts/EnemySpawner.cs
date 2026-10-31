using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SO_Enemy[] attributes_normal;
    [SerializeField] private SO_Enemy[] attributes_shooter;


    [SerializeField] private GameObject[] enemies;
    private GameObject player;
    

    void Start()
    {
        player = GameManager.Instance.GetPlayer();
    }

    public EnemyBehavior CreateEnemy()
    {
        int i = Random.Range(0, enemies.Length);

        EnemyBehavior enemy = Instantiate(enemies[i]).GetComponent<EnemyBehavior>();
        enemy.index = i;
        
        SO_Enemy enemyAttributes;
        switch(enemy.type)
        {
            case EnemyType.Normal:
                //normal
                enemyAttributes = attributes_normal[Random.Range(0, attributes_normal.Length)];
                break;
            case EnemyType.Shooter:
                //shooter
                enemyAttributes = attributes_shooter[Random.Range(0, attributes_shooter.Length)];
                break;
            default:
                enemyAttributes = attributes_normal[0];
                break;
        }
        
        enemy.SetAttributes(enemyAttributes);

        return enemy;
    }

    public EnemyBehavior CreateEnemy(EnemyData data)
    {
        EnemyBehavior enemy = Instantiate(
            enemies[data.index],
            data.position,
            Quaternion.Euler(data.rotation)
        ).GetComponent<EnemyBehavior>();

        enemy.life = data.life;
        enemy.index = data.index;
        enemy.Attributes = data.attributes;

        return enemy;
    }
}
