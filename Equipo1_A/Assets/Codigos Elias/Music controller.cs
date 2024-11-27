using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip backgroundMusic1;
    public AudioClip backgroundMusic2;

    void Start()
    {
        // Reproduce la primera música al inicio
        audioSource.clip = backgroundMusic1;
        audioSource.Play();
    }

    void Update()
    {
        // Cambia la música cuando ocurre algún evento (por ejemplo, pulsar una tecla)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayMusic(backgroundMusic1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayMusic(backgroundMusic2);
        }
    }

    void PlayMusic(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
