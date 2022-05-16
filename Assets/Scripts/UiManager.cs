using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    // Start is called before the first frame update 
    public static UiManager UiInstance;
    public Button CollectButton;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI ScoreText;

    public Image OxygenBar;
    public GameObject gameOvetTxt;
   
    public Image DepthBar;
    public TextMeshProUGUI DepthTxt;

    public Button catchButton;
    public TextMeshProUGUI congrats;
   
    int Textspeed = 50;
    bool ButtonIsCliked = false;
    bool caughtCreature = false;
    private void Awake()
    {

        if (UiInstance == null)
        {
            UiInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        CollectButton.gameObject.SetActive(false);
        Text.gameObject.SetActive(false);
        ScoreText.text = ("Score:" + GameManager.Instance.GetScore());

        catchButton.gameObject.SetActive(false);
        congrats.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = ("Score:" + GameManager.Instance.GetScore());
        if (ButtonIsCliked == true)
        {
            Text.gameObject.SetActive(true);
            Text.transform.position += new Vector3(0, 3, 0) * Textspeed * Time.deltaTime;
        }
        if (TrashScript.Tinstance.IsTriggerd == true)
        {
            CollectButton.gameObject.SetActive(true);
        }
        if (TrashScript.Tinstance.IsTriggerd == false)
        {
            CollectButton.gameObject.SetActive(false);
        }
        // creature
        if(caughtCreature == true)
        {
            congrats.gameObject.SetActive(true);
            congrats.transform.position += new Vector3(0, 3, 0) * 25 * Time.deltaTime;
        }

        if(CreatureScript.Tinstance.IsTriggerd == true)
        {
            catchButton.gameObject.SetActive(true);
        }
        if (CreatureScript.Tinstance.IsTriggerd == false)
        {
            catchButton.gameObject.SetActive(false);
        }


    }
    public void buttonClicked()
    {
       
        Text.gameObject.transform.localPosition = TrashScript.Tinstance.trash.transform.position;
        Text.gameObject.SetActive(true);
        Destroy(TrashScript.Tinstance.trash.gameObject);
        GameManager.Instance.AddTOScore(3);
        ButtonIsCliked = true;
        CollectButton.gameObject.SetActive(false);
        TrashScript.Tinstance.IsTriggerd = false;
    }

    public void creatureClicked()
    {
        congrats.gameObject.transform.localPosition = CreatureScript.Tinstance.creature.transform.position;
        congrats.gameObject.SetActive(true);
        Destroy(CreatureScript.Tinstance.creature.gameObject);
        caughtCreature = true;
        catchButton.gameObject.SetActive(false);
        CreatureScript.Tinstance.IsTriggerd = false;

    }
}
