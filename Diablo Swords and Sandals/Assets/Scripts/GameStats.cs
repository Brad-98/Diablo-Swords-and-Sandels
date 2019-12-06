using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static GameStats instance;

    public int playerHealth;
    public int playerLevel;
    public int playerGold;

    public int maxExperienceValue;
    public int currentExperienceValue;

    public int daysRemaining;

    // Start is called before the first frame update
    void Awake()
    {
        CreateSingleton();
        playerHealth = 100;
        playerLevel = 1;
        playerGold = 0;
        daysRemaining = 30;

        maxExperienceValue = 100;
        currentExperienceValue = 0;
    }

    private void CreateSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
