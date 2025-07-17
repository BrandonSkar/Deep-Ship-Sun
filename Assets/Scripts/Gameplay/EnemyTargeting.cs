using System.Linq;
using UnityEngine;

public class EnemyTargeting : MonoBehaviour
{
    public GameObject enemyPool;

    public GameObject laserPrefab;
    public GameObject autoLaserPrefab;

    public Transform autoFirePoint;
    public Transform firePoint1;
    public Transform firePoint2;
    public ShipStats shipStats;

    private bool useFirstFirePoint = true;

    void Start()
    {
        if (enemyPool == null)
        {
            enemyPool = GameObject.Find("Enemy Pool");
        }
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ShootClosestEnemy();
        }

        #if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
        {
            ShootClosestEnemy();
        }
        #endif
    }

    void ShootClosestEnemy()
    {
        Transform closestEnemy = FindClosestEnemy();
        if (closestEnemy != null)
        {
            Transform firePointToUse = useFirstFirePoint ? firePoint1 : firePoint2;

            GameObject laser = Instantiate(laserPrefab, firePointToUse.position, Quaternion.identity);
            laser.GetComponent<Laser>().Init(closestEnemy, shipStats.GetDamage());

            useFirstFirePoint = !useFirstFirePoint;
        }
    }

    public void AutoFire()
    {
        Transform closestEnemy = FindClosestEnemy();
        if (closestEnemy != null && autoFirePoint != null)
        {
            GameObject laser = Instantiate(autoLaserPrefab, autoFirePoint.position, Quaternion.identity);
            laser.GetComponent<Laser>().Init(closestEnemy, shipStats.GetDamage());
        }
    }
    Transform FindClosestEnemy()
    {
        Transform closest = null;
        float closestDist = Mathf.Infinity;
        Vector3 shipPos = transform.position;

        foreach (Transform enemy in enemyPool.transform)
        {
            float dist = Vector3.Distance(shipPos, enemy.position);
            if (dist < closestDist)
            {
                closestDist = dist;
                closest = enemy;
            }
        }

        return closest;
    }
}
