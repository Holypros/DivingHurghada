using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    // Start is called before the first frame update 
    public static UiManager UiInstance;
    public Button CollectButton;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI ScoreText;

    [SerializeField] Image OxygenBar;
    [SerializeField] GameObject gameOvetTxt;

    [SerializeField] Image DepthBar;
    [SerializeField] TextMeshProUGUI DepthTxt;

    public Button catchButton;
    public TextMeshProUGUI congrats;

    public Button nextLevel;

    public Animator transition;
    public float transitionTime = 10.0f;
   
    int Textspeed = 50;
    bool ButtonIsCliked = false;

    public static bool GameIsPaused = false;
   
    [HideInInspector]
     public int clicked=0;
   public bool caughtCreature = false; 
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
        nextLevel.gameObject.SetActive(false);
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
        clicked++;
        Debug.Log(clicked);
    }

    public void transitionClicked()
    {
       StartCoroutine( LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }



    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }




    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = true;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void MenuClicked()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }


    public void SetDepthAmount(float value) {
        DepthBar.fillAmount = value;
    }

    public float GetDepthAmount()
    {
        return DepthBar.fillAmount;
    }

    public void SetDepthText(string txt)
    {
        DepthTxt.text = txt;
    }

    

    public void SetOxygenAmount(float value)
    {
        OxygenBar.fillAmount = value;
    }

    public float GetOxygenAmount()
    {
        return OxygenBar.fillAmount;
    }

    public void ShowGameOverText() {
        gameOvetTxt.SetActive(true);
    }
}
