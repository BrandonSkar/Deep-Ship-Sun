using UnityEngine;

public class EnemyDetails : MonoBehaviour
{
    public float speed = 1f;
    public GameObject deathExplosionPrefab;

    void Update()
    {
        transform.Rotate(new Vector3(15f, 30f, 45f) * Time.deltaTime);
    }

    public void Die()
    {
        if (deathExplosionPrefab != null)
        {
            Instantiate(deathExplosionPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}