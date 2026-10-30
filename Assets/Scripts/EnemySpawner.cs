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
        
        SO_Enemy enemyAttributes;
        switch(enemy.type)
        {
            case 1:
                //normal
                enemyAttributes = attributes_normal[Random.Range(0, attributes_normal.Length)];
                break;
            case 2:
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
}
