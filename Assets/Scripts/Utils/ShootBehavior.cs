using UnityEngine;

public class ShootBehavior : MonoBehaviour
{
    public float speed;
    public int damage;

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
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("oi");
            other.GetComponent<EnemyBehavior>().Damage(damage);
            Destroy(gameObject);
        }
    }
}
