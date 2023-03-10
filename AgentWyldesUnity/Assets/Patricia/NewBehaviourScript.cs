using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;
    public AudioSource audioSource;

    void Start()
    {
        // Set the slider's value to the current volume level
        slider.value = audioSource.volume;
        // Add a listener to the slider to update the volume when it changes
        slider.onValueChanged.AddListener(UpdateVolume);
    }

    void UpdateVolume(float value)
    {
        // Update the audio source's volume to match the slider's value
        audioSource.volume = value;
    }
}