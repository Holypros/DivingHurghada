using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    static public AudioManager AudioInstance;
    // Start is called before the first frame update
    [SerializeField] private Slider Musicslider = null;
    [SerializeField] private Slider EffectSlider = null;
    [SerializeField] public AudioSource EffectSource;
    [SerializeField] public AudioClip Effectsclip;
    private void Awake()
    {
        if(AudioInstance == null)
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
        AudioListener.volume = 0f;

        AudioListener.volume = PlayerPrefs.GetFloat("Music");
        EffectSource.volume = PlayerPrefs.GetFloat("Effects");
        EffectSlider.value= PlayerPrefs.GetFloat("Effects");
        Musicslider.value = AudioListener.volume;
       



      }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMusicSlider()
    {

        AudioListener.volume = Musicslider.value;
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
      


    }
    public void MuteButton()
    {
        AudioListener.volume = 0;
        Musicslider.value = AudioListener.volume;
        EffectSource.volume = 0;
        EffectSlider.value = 0;
       
    }
   
}
