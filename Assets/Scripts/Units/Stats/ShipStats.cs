using UnityEngine;

public class ShipStats : MonoBehaviour
{
    public int currentDamage = 1;

    public void UpgradeDamage(int amount)
    {
        currentDamage += amount;
    }

    public int GetDamage()
    {
        return currentDamage;
    }
}
