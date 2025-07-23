using UnityEngine;

public class AutoTapManager : MonoBehaviour
{
    [Header("Dependencies")]
    public EnemyTargeting enemyTargeting;

    [Header("Auto Tap Settings")]
    public float baseTapDamage = 1f;
    public float damageMultiplier = 1f;

    public float baseTapInterval = 3f;
    public float speedMultiplier = 1f;

    private float tapTimer = 0f;

    void Update()
    {
        if (UIManager.Instance != null && UIManager.Instance.IsMenuOpen)
            return;

        tapTimer += Time.deltaTime;

        if (tapTimer >= GetCurrentInterval())
        {
            tapTimer = 0f;
            PerformAutoTap();
        }
    }

    void PerformAutoTap()
    {
        float damage = baseTapDamage * damageMultiplier;
        if (enemyTargeting != null)
        {
            enemyTargeting.AutoFire();
            Debug.Log("Auto Tap! Fired auto laser.");
        }
        else
        {
            Debug.LogWarning("EnemyTargeting reference is missing.");
        }
        Debug.Log($"Auto Tap! Dealt {damage} damage.");
    }

    float GetCurrentInterval()
    {
        return baseTapInterval / speedMultiplier;
    }

    // Call these from upgrade buttons or logic
    public void UpgradeDamage(float multiplierIncrease)
    {
        damageMultiplier += multiplierIncrease;
    }

    public void UpgradeSpeed(float speedIncrease)
    {
        speedMultiplier += speedIncrease;
    }

    public void SetSpeedMultiplier(float newMultiplier)
    {
        speedMultiplier = newMultiplier;
    }

    public void SetDamageMultiplier(float newMultiplier)
    {
        damageMultiplier = newMultiplier;
    }
}
