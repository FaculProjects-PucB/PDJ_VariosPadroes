using UnityEngine;

public class PowerUpBehavior : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.OnPowerUpCollected.Invoke();
            Destroy(gameObject);
        }
    }
}
