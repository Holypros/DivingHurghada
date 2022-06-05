using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] public AudioSource voiceOver;
    [SerializeField] private GameObject firstPanel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;
    private Queue<AudioClip> audioclips;

    public Animator animator;

    private int counter = 0;

    

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
    }


}
