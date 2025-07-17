using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    public float lifetime = 0.2f;
    public GameObject explosionPrefab;

    private LineRenderer lr;

    public void Init(Transform target, int damage)
    {
        lr = GetComponent<LineRenderer>();

        if(target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 start = transform.position;
        Vector3 end = target.position;

        lr.SetPosition(0, start);
        lr.SetPosition(1, end);

        EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }

        Vector3 explosionPosition = end;
        explosionPosition.z -= 1f;
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, explosionPosition, Quaternion.identity);
        }

        Destroy(gameObject, lifetime);
    }
}
