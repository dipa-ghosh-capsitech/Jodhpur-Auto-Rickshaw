using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
  public float speed = 5f;
    public float destroyX = -20f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
