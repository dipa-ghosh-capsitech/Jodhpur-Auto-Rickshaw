using UnityEngine;

public class ObstacleCollector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
        }
    }
}
