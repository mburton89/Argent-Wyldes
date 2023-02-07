using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializedField] Slider VolumeSlider;

    // Start is called before the first frame update
    void Start()
    {

    }
        if(!PlayerPrefs.HasKey("musicVolume))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
         }

         else
         {
             Load();
          }

    public void ChangeVolume ()
    {
         AudioListnere.volume = volumeSlider.value;
         Save();
    } 

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs,SetFloat("musicVolume", volumeSlider.value);
    
    }
}