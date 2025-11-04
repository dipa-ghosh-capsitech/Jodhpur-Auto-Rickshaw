
using UnityEngine;

public class RickshawFly : MonoBehaviour
{
    
    public float gravity;
    public float jumpSpeeed;
    Rigidbody2D rb;
    private bool isReached = false;

    public float minY = -4.53f;
    public float maxY = 4.55f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
      public void RickshawStartFlying()
    {
        isReached = true;
    }
    private void Update()
    {
        if (isReached)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {

                Up();
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                Down();
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    Up();
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    Down();
                }
            }

            Vector3 pos = transform.position;
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
            transform.position = pos;
        }

    }
    void Up()
    {
        rb.linearVelocity = Vector2.up * jumpSpeeed;
    }
    void Down()
    {
        rb.gravityScale = gravity;
    }
  

}


