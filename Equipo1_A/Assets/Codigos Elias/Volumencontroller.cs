using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider volumeSlider;

    void Start()
    {
        // Inicializa el slider con el valor actual del volumen del AudioSource
        volumeSlider.value = audioSource.volume;

        // Añade un listener al slider para detectar cambios en el valor
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float volume)
    {
        // Ajusta el volumen del AudioSource al valor del slider
        audioSource.volume = volume;
    }
}
