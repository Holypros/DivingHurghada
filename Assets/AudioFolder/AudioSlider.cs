using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    // Start is called before the first frame update
     public static  AudioSlider AudioS;
    [SerializeField] public Slider Musicslider;
    [SerializeField] public Slider EffectSlider;
    public static float myval;
   
    public void UpdateMusicSlider()
    {

        AudioManager .AudioInstance. MusicSource.volume = Musicslider.value;
        Musicslider.value = AudioManager.AudioInstance.MusicSource.volume;
        PlayerPrefs.SetFloat("Music",Musicslider.value);
    }
    public void UpdateEffectSlider()
    {


        AudioManager.AudioInstance.EffectSource.volume = EffectSlider.value;
       EffectSlider.value = AudioManager.AudioInstance.EffectSource.volume;
        PlayerPrefs.SetFloat("Effects", EffectSlider.value);
    }
    void Start()
    {

        AudioManager.AudioInstance.MusicSource.volume = 0.5f;

        AudioManager.AudioInstance.MusicSource.volume = PlayerPrefs.GetFloat("Music");

        AudioManager.AudioInstance.EffectSource.volume = PlayerPrefs.GetFloat("Effects");
       
        EffectSlider.value = PlayerPrefs.GetFloat("Effects");
      
        Musicslider.value = AudioManager.AudioInstance.MusicSource.volume;

    }

    private void OnEnable()
    {
        AudioManager.AudioInstance.MusicSource.volume = PlayerPrefs.GetFloat("Music");

        AudioManager.AudioInstance.EffectSource.volume = PlayerPrefs.GetFloat("Effects");

        EffectSlider.value = PlayerPrefs.GetFloat("Effects");

        Musicslider.value = AudioManager.AudioInstance.MusicSource.volume;
    }

    public void MuteButton()
    {

        AudioManager.AudioInstance.MusicSource.volume = 0;
        
        Musicslider.value = AudioManager.AudioInstance.MusicSource.volume;
        AudioManager.AudioInstance.EffectSource.volume = 0;
       EffectSlider.value = 0;
       

    }
    public void Update()
    {
        myval = EffectSlider.value;
    }
}
