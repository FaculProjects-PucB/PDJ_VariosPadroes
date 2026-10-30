using UnityEngine;

public class ShootBehavior : MonoBehaviour
{
    public float speed;
    public int damage;

    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyBehavior>().Damage(damage);
            Destroy(gameObject);
        }
    }
}
