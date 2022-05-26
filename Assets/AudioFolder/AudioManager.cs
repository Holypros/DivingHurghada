using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    static public AudioManager AudioInstance;
    // Start is called before the first frame update
    [SerializeField] private Slider Musicslider;
    [SerializeField] private Slider EffectSlider;
    [SerializeField] public AudioSource EffectSource;
    [SerializeField] public AudioSource MusicSource;
    [SerializeField] public AudioClip Effectsclip;

    private void Awake()
    {
        if (AudioInstance == null)
        {
            AudioInstance = this;

        }
        else if (AudioInstance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);

    }

    void Start()
    {
        MusicSource.volume = 0.5f;
        MusicSource.volume = PlayerPrefs.GetFloat("Music");
        EffectSource.volume = PlayerPrefs.GetFloat("Effects");
        EffectSlider.value = PlayerPrefs.GetFloat("Effects");
        Musicslider.value = MusicSource.volume;

    }

    // Update is called once per frame

    public void UpdateMusicSlider()
    {

        MusicSource.volume = Musicslider.value;
        PlayerPrefs.SetFloat("Music", Musicslider.value);
    }
    public void UpdateEffectSlider()
    {


        EffectSource.volume = EffectSlider.value;
        PlayerPrefs.SetFloat("Effects", EffectSlider.value);
    }
    public void EffectPlayer()
    {

        EffectSource.PlayOneShot(Effectsclip);

        EffectSource.volume = EffectSlider.value;




    }
    public void MuteButton()
    {
        MusicSource.volume = 0;
        Musicslider.value = MusicSource.volume;
        EffectSource.volume = 0;
        EffectSlider.value = 0;

    }
    //public void test()
    //{
    //    EffectPlayer();
    //}

}
