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
   
    int Textspeed = 50;
    bool ButtonIsCliked = false;
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
        UiInstance.CollectButton.gameObject.SetActive(false);
        UiInstance.Text.gameObject.SetActive(false);
        UiInstance.ScoreText.text = ("Score:" + GameManager.Instance.GetScore());

    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = ("Score:" + GameManager.Instance.GetScore());
        if (ButtonIsCliked == true)
        {
            Text.gameObject.SetActive(true);
            Text.transform.position += new Vector3(0, 3, 0) * Textspeed * Time.deltaTime;
            //  Debug.Log(playerscore);
        }
        if (TrashScript.Tinstance.IsTriggerd == true)
        {

            CollectButton.gameObject.SetActive(true);


        }
        if (TrashScript.Tinstance.IsTriggerd == false)
        {
            CollectButton.gameObject.SetActive(false);
        }

    }
    public void buttonClicked()
    {
        Debug.Log("Button");
        CollectButton.gameObject.SetActive(false);
        Text.gameObject.transform.localPosition = TrashScript.Tinstance.trash.transform.position;
        Text.gameObject.SetActive(true);
        Destroy(TrashScript.Tinstance.trash.gameObject);
        GameManager.Instance.AddTOScore(3);
        ButtonIsCliked = true;

    }
}
