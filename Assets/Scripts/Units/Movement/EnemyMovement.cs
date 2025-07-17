using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Destroy if off screen (below)
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}