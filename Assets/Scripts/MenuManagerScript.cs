using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerScript : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject TapToPlayPanel;
    public GameObject settingsPanel;
    public GameObject pausePanel;
    public GameObject gameUiPanel;
    public GameObject gameoverPanel;
    public GameObject playEnter;
 
    AudioManagerScript audioManagerScript;

    public bool isPaused = false;
    public static bool isRestarting = false;

    void Start()
    {
        audioManagerScript = GameObject.Find("AudioManager").GetComponent<AudioManagerScript>();
        if (isRestarting)
        {
            mainMenuPanel.SetActive(false);
            gameUiPanel.SetActive(true);
            Time.timeScale = 1f;

            isRestarting = false;
        }
        else
        {
            Time.timeScale = 0f;
            mainMenuPanel.SetActive(true);
            settingsPanel.SetActive(false);
            pausePanel.SetActive(false);
            gameUiPanel.SetActive(false);
        }
    }
    public void TaptoPLay()
    {
        
    }

    public void StartGame()
    {
        gameUiPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        playEnter.SetActive(false);

        Time.timeScale = 1f;
    }
    public void play()
    {
        playEnter.SetActive(true);
        mainMenuPanel.SetActive(false);
    }
    public void OnSettingPanel()
    {
        // mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
        settingsPanel.transform.SetAsLastSibling();
        // Time.timeScale = 1f;
    }
    public void OnPrivacyPolicyButton()
    {
        Application.OpenURL("https://www.google.com/");
    }

    public void Pausegame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        audioManagerScript.StopRickshawRunning();
        pausePanel.SetActive(true);
       
    }
    public void OnResumeButton()
    {
        isPaused = false;
        Time.timeScale = 1f;
        audioManagerScript.PlayRickshawRunning();
        pausePanel.SetActive(false);
    }
    public void OnRestartButton()
    {
        isRestarting = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
  
    public void CloseSettingpanel()
    {
        settingsPanel.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
