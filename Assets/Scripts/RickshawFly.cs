
using UnityEngine;

public class RickshawFly : MonoBehaviour
{
    
    public float gravity;
    public float jumpSpeeed;
    Rigidbody2D rb;
    private bool isReached = false;

    public float minY = -3.92f;
    public float maxY = 4.55f;

    private ScoreManager scoreManager;
    AudioManagerScript audioManagerScript;
    MenuManagerScript menuManagerScript;
    private bool isGameOver = false;
    // private AudioSource engineAudio;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        audioManagerScript = GameObject.Find("AudioManager").GetComponent<AudioManagerScript>();
        menuManagerScript = GameObject.Find("MenuManager").GetComponent<MenuManagerScript>();
       
    }
      public void RickshawStartFlying()
    {
        audioManagerScript.PlayRickshawRunning();
        isReached = true;
    }
    private void Update()
    {
        if (isReached)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                Up();
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                Down();
            }

            if (Input.touchCount > 0 )
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


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            Debug.Log("Rickshaw collides with obstacle");     
            audioManagerScript.PlaySFX(audioManagerScript.crashWithSignalPole);
            audioManagerScript.StopRickshawRunning();
            scoreManager.ShowGameOverScores();
            isGameOver = true;
            Time.timeScale = 0f;
            GameOver();

        }
        else if (collision.tag == "Wire")
        {
            audioManagerScript.PlaySFX(audioManagerScript.crashWithElectricWire);
            audioManagerScript.StopRickshawRunning();
            scoreManager.ShowGameOverScores();
            isGameOver = true;
            Time.timeScale = 0f;
            GameOver();

        }
        else if (collision.tag == "Scorer")
        {
            audioManagerScript.PlaySFX(audioManagerScript.scoreCollect);
            
            scoreManager.AddScore(5);
        }

    }
    
    void GameOver()
    {
        if (isGameOver)
        {
            menuManagerScript.gameoverPanel.SetActive(true);
            menuManagerScript.settingsPanel.SetActive(false);
            menuManagerScript.pausePanel.SetActive(false);
            menuManagerScript.gameUiPanel.SetActive(false);
        }
    }

}







