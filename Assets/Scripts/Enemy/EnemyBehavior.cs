using System;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private EnemyState state;

    public int type;
    public GameObject target;
    public float speed;
    public int life;
    public float range;
    public bool onDebuff;

    public void SetAttributes(float speed, int life, float range)
    {
        this.speed = speed;
        this.life = life;
        this.range = range;
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
            Die();
        }
    }

    public void ChangeState(EnemyState newState)
    {
        state = newState;
        state?.Enter();
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
