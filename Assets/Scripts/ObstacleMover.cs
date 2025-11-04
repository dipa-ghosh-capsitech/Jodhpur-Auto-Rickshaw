using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
 public float speed = 3f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
