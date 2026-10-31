using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

class LevelData
{
    public EnemyData[] enemies;
    public PlayerData player;
}

public class SaveGame: MonoBehaviour
{
    string path;

    public EnemySpawner factory;

    void Awake()
    {
        path = Application.dataPath + "/save.txt";
    }

    public void Save(InputAction.CallbackContext cx)
    {
        EnemyManager.Instance.RemoveDeadEnemies();

        LevelData data = new LevelData
        {
            enemies = new EnemyData[EnemyManager.Instance.enemies.Count],
            player = GameManager.Instance.GetPlayerData()
        };

        for (int i=0; i<data.enemies.Length; i++)
        {
            data.enemies[i] = new EnemyAdapter(EnemyManager.Instance.enemies[i]);
        }

        string s = JsonUtility.ToJson(data);
        Debug.Log(s);
        File.WriteAllText(path, s);
    }

    public void Load(InputAction.CallbackContext cx)
    {
        EnemyManager.Instance.RemoveAllEnemies();
        
        string s = File.ReadAllText(path);
        LevelData data = JsonUtility.FromJson<LevelData>(s); 
        
        GameManager.Instance.SetPlayerData(data.player);
        for (int i=0; i<data.enemies.Length; i++)
        {
            factory.CreateEnemy(data.enemies[i]);
        }
    }
}
