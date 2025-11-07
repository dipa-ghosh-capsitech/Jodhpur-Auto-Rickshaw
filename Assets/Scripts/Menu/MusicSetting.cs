using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    public Image soundIcon;
    public Image sfxIcon;

    [Header("Icons")]
    public Sprite soundOnIcon;
    public Sprite soundOffIcon;
    public Sprite sfxOnIcon;
    public Sprite sfxOffIcon;


    private void Start()
    {
        SetMusicVolume();
        SetSFXVolume();


        musicSlider.onValueChanged.AddListener(UpdateSoundIcon);
        sfxSlider.onValueChanged.AddListener(UpdateSFXIcon);

        UpdateSoundIcon(musicSlider.value);
        UpdateSFXIcon(sfxSlider.value);
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        
        
    }
    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        myMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
    }

    
    void UpdateSoundIcon(float value)
    {
        if (value <= 0.01f)
        {
            soundIcon.sprite = soundOffIcon;
        }
        else
        {
             soundIcon.sprite = soundOnIcon;
        }

       
    }

    void UpdateSFXIcon(float value)
    {
        if (value <= 0.01f)
        {
            sfxIcon.sprite = sfxOffIcon;
        }
        else
        {
            sfxIcon.sprite = sfxOnIcon;
        }

      
    }
}
