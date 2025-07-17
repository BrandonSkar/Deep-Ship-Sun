using UnityEngine;

public class GameStageManager : MonoBehaviour
{
    [Header("Enemy Spawn")]
    public Transform enemyPool;
    public GameObject normalEnemyPrefab;
    public GameObject bossEnemyPrefab;

    [Header("Stage Settings")]
    public int currentStage = 1;
    public float baseEnemyHP = 10f;
    public float hpGrowthRate = 1.18f;
    public float bossMultiplier = 6f;

    [Header("Player Settings")]
    public float playerDamage = 10f;

    private GameObject currentEnemy;
    private float currentEnemyHP;
    private bool isBoss;

    void Start()
    {
        StartStage(currentStage);
    }

    void Update()
    {
        // TEMP: Simulate attack with space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DealDamage(playerDamage);
        }
    }

    void StartStage(int stage)
    {
        isBoss = stage % 25 == 0;
        currentEnemyHP = CalculateEnemyHP(stage);
        Debug.Log($"Stage {stage} started. {(isBoss ? "BOSS!" : "Normal")} Enemy HP: {currentEnemyHP}");

        // Clear any previous enemy
        if (currentEnemy != null)
        {
            Destroy(currentEnemy);
        }

        // Choose enemy prefab
        GameObject enemyPrefab = isBoss ? bossEnemyPrefab : normalEnemyPrefab;

        // Instantiate under EnemyPool
        currentEnemy = Instantiate(enemyPrefab, enemyPool.position, Quaternion.identity, enemyPool);
    }

    float CalculateEnemyHP(int stage)
    {
        float hp = baseEnemyHP * Mathf.Pow(hpGrowthRate, stage - 1);
        if (stage % 25 == 0)
            hp *= bossMultiplier;
        return Mathf.Floor(hp);
    }

    public void DealDamage(float amount)
    {
        currentEnemyHP -= amount;
        Debug.Log($"Dealt {amount} damage. Enemy HP left: {Mathf.Max(currentEnemyHP, 0)}");

        if (currentEnemyHP <= 0)
        {
            OnEnemyDefeated();
        }
    }

    void OnEnemyDefeated()
    {
        Debug.Log($"Stage {currentStage} cleared!");
        currentStage++;
        StartStage(currentStage);
    }
}
