using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //Singleton

    // Statistics
    [SerializeField] private int enemiesToKill;
    private int enemiesKilled;
    [SerializeField] private int maxLife;
    private int life;
    [SerializeField] private float powerUpDuration;

    // Events
    public UnityEvent OnPowerUpCollected;
    public UnityEvent OnPowerUpEnded;

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

        OnPowerUpCollected.AddListener(PowerUpTimer);
    }

    private void PowerUpTimer()
    {
        StartCoroutine(I_PowerUpTimer());
    }

    private IEnumerator I_PowerUpTimer()
    {
        yield return new WaitForSeconds(powerUpDuration);
        OnPowerUpEnded.Invoke();
    }

    // Public Methods

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
