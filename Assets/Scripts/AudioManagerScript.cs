using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    public AudioSource carRunning;


    public AudioClip background;
    public AudioClip scoreCollect;
    public AudioClip rickshawRunning;
    public AudioClip crashWithElectricWire;
    public AudioClip crashWithSignalPole;

    


    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();

        carRunning.clip = rickshawRunning;
        
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
        

    }
    public void PlayRickshawRunning()
    {
        if (carRunning != null && !carRunning.isPlaying)
        {
            carRunning.Play();
        }
    }
    public void StopRickshawRunning()
    {
        if (carRunning != null && carRunning.isPlaying)
        {
            carRunning.Stop();
        }
    }


}
