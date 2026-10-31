using UnityEngine;

public class EnemyAdapter : EnemyData
{
    public EnemyAdapter(EnemyBehavior enemy)
    {
        position = enemy.transform.position;
        rotation = enemy.transform.rotation.eulerAngles;

        life = enemy.life;
        index = enemy.index;
        attributes = enemy.Attributes;
    }
}
