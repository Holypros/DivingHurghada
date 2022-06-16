using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] public AudioSource voiceOver;
    [SerializeField] private GameObject firstPanel;
    [SerializeField] private GameObject secondPanel;
    [SerializeField] private GameObject thirdPanel;
    [SerializeField] private GameObject fourthPanel;
    [SerializeField] private GameObject fifthPanel;
    [SerializeField] private GameObject sixthPanel;
    [SerializeField] private GameObject SeventhPanel;
    [SerializeField] private GameObject EighthPanel;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;
    private Queue<AudioClip> audioclips;

    public Animator animator;

    private int counter = 0;

    public Animator transition;
    public float transitionTime = 10.0f;

    public TextMeshProUGUI continueButton;

    private void Awake()
    {
        sentences = new Queue<string>();
        audioclips = new Queue<AudioClip>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.npcName;

        sentences.Clear();
        audioclips.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);        
        }

        foreach (AudioClip clip in dialogue.audioclips)
        {
            audioclips.Enqueue(clip);
        }


        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        voiceOver.Stop();
        if (sentences.Count == 0)
        {
            EighthPanel.SetActive(false);
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        AudioClip clip = audioclips.Dequeue();  
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        voiceOver.PlayOneShot(clip);
        counter++;
        if(counter == 2)
        {
            firstPanel.SetActive(true);
        }
        else if (counter == 3)
        {
            firstPanel.SetActive(false);
            secondPanel.SetActive(true);
        }
        else if (counter == 4)
        {
            secondPanel.SetActive(false);
            thirdPanel.SetActive(true);
        }
        else if (counter == 5)
        {
            thirdPanel.SetActive(false);
            fourthPanel.SetActive(true);
        }
        else if(counter == 6)
        {
            fourthPanel.SetActive(false);
            fifthPanel.SetActive(true); 
        }
        else if(counter == 7)
        {
            fifthPanel.SetActive(false);
            sixthPanel.SetActive(true);
        }
        else if(counter == 8)
        {
            sixthPanel.SetActive(false);
            SeventhPanel.SetActive(true);
        }
        else if(counter == 9)
        {
            SeventhPanel.SetActive(false);
            EighthPanel.SetActive(true);
            
        }    
        else if(counter == 10)
        {
            continueButton.text = "Start";
        }
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }


    void EndDialogue()
    {       
        animator.SetBool("IsOpen", false);
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            transitionClicked();
        }
    }

    public void transitionClicked()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 2));
        AudioManager.AudioInstance.EffectPlayer();
    }



    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }


}
