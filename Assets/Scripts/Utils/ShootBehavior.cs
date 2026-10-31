using UnityEngine;

public class ShootBehavior : MonoBehaviour
{
    public float speed;
    public int damage;
    public bool hitsPlayer;

    void Start()
    {
        Destroy(gameObject, 5);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (hitsPlayer && other.CompareTag("Player"))
        {
            GameManager.Instance.Hit(damage);
            Destroy(gameObject);
        }
        else if (!hitsPlayer && other.CompareTag("Enemy"))
        {
            EnemyBehavior enemy = other.GetComponent<EnemyBehavior>();
            if (enemy == null) return;

            enemy.Damage(damage);
            Destroy(gameObject);
        }
    }
}
