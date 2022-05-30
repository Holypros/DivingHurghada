using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
    static public AudioManager AudioInstance;
    [SerializeField] public AudioSource EffectSource;
    [SerializeField] public AudioSource MusicSource;
    [SerializeField] public AudioSource SwimmingEffect;
   // Start is called before the first frame update


   [SerializeField] public AudioClip Effectsclip;
    [SerializeField] public AudioClip SwimmimgClip;

    private void Awake()
    {
        if (AudioInstance == null)
        {
            AudioInstance = this;

        }
        else if (AudioInstance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        //if (AudioSlider .AudioS.MusicSource.isPlaying)
        //{
        //    AudioSlider.AudioS.MusicSource.playOnAwake=false;
        //}
       // PlayerPrefs.Save();
    }

    

    // Update is called once per frame

    public void UpdateMusicSlider()
    {

       
        MusicSource.volume = AudioSlider.AudioS.Musicslider.value;
        AudioSlider.AudioS.Musicslider.value = MusicSource.volume;
        PlayerPrefs.SetFloat("Music", AudioSlider.AudioS.Musicslider.value);
    }
    public void UpdateEffectSlider()
    {


       EffectSource.volume = AudioSlider.AudioS.EffectSlider.value;
        AudioSlider.AudioS.EffectSlider.value =EffectSource.volume;
        PlayerPrefs.SetFloat("Effects", AudioSlider.AudioS.EffectSlider.value);
        SwimmingEffect.volume= AudioSlider.AudioS.EffectSlider.value;
        

    }
    public void EffectPlayer()
    {

       EffectSource.PlayOneShot(Effectsclip);

        EffectSource.volume = AudioSlider.myval;
          

    }
    
    //public void test()
    //{
    //    EffectPlayer();
    //}

}
