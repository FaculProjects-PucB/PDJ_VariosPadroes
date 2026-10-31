using System;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private EnemyState state;

    public int type;
    public GameObject target;
    public SO_Enemy Attributes;
    public int life;
    public bool onDebuff;

    public void SetAttributes(SO_Enemy attributes)
    {
        Attributes = attributes;
        life = attributes.maxLife;
    }

    protected virtual void Start()
    {
        state = new EnemyStateWalking(this);
        state?.Enter();

        onDebuff = false;
        GameManager.Instance.OnPowerUpCollected.AddListener(PowerUpDebuff);
        GameManager.Instance.OnPowerUpEnded.AddListener(PowerUpEnded);
    }

    protected virtual void Update()
    {
        state?.OnState();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.Hit(10);
            Die();
        }
    }

    public void ChangeState(EnemyState newState)
    {
        state = newState;
        state?.Enter();
    }

    public void Damage(int value)
    {
        life -= value;

        if (life <= 0) Die();
    }

    public void Die()
    {
        GameManager.Instance.EnemyKilled();
        Destroy(gameObject);
    }

    public void PowerUpDebuff()
    {
        onDebuff = true;
        Debug.Log("onDebuff True");
    }

    public void PowerUpEnded()
    {
        onDebuff = false;
        Debug.Log("onDebuff False");
    }
}
