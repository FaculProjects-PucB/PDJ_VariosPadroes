using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance; //Singleton

    [SerializeField] private Slider enemiesKilledText;
    [SerializeField] private Slider lifeBar;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        enemiesKilledText.value = 0;
        lifeBar.value = 1;
        lifeBar.gameObject.SetActive(false);
    }

    public void SetEnemiesKilled(int maxEnemiesKilled, int enemiesKilled)
    {
        enemiesKilledText.value = (float)enemiesKilled/maxEnemiesKilled;
    }

    public void SetLife(int maxHealth, int health)
    {
        float barValue = (float)health/maxHealth;

        if (barValue < 1) lifeBar.gameObject.SetActive(true);
        else lifeBar.gameObject.SetActive(false);

        lifeBar.value = barValue;
    }
}
