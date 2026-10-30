using System;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //Singleton

    // Statistics
    [SerializeField] private int enemiesToKill;
    private int enemiesKilled;
    [SerializeField] private int maxLife;
    private int life;

    // References
    private GameObject player;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        life = maxLife;
    }

    public void SetPlayer(GameObject player)
    {
        if (this.player == null) this.player = player;
        else return;
    }

    public GameObject GetPlayer()
    {
        if (player != null) return player;
        else return null;
    }

    public void EnemyKilled()
    {
        enemiesKilled++;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.SetEnemiesKilled(maxEnemiesKilled: enemiesToKill, enemiesKilled: enemiesKilled);
        }
    }

    public void Hit(int damage)
    {
        life -= damage;

        if (life <= 0)
        {
            Die();
        }

        if (UIManager.Instance != null)
        {
            UIManager.Instance.SetLife(maxHealth: maxLife, health: life);
        }
    }

    private void Die()
    {
        //Die Method
    }
}
