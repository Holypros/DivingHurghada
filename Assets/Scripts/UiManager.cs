using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    // Start is called before the first frame update 
    public static UiManager UiInstance;
    public Button button;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI ScoreText;

    public Image bar;
    public GameObject gameOvetTxt;
    public float oxygenLossRate = 0.03f;
    public float oxygenGainRate = 0.05f;
    public float maxY;

    public Image Dbar;
    public TextMeshProUGUI depthTxt;
    public float DmaxY;
    public float DminY;
    public float playerLength;
    int speed = 50;
    bool buttonIsCliked = false;
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
        UiInstance.button.gameObject.SetActive(false);
        UiInstance.Text.gameObject.SetActive(false);
        UiInstance.ScoreText.text = ("Score:" + GameManager.Instance.GetScore());

    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = ("Score:" + GameManager.Instance.GetScore());
        if (buttonIsCliked == true)
        {
            Text.gameObject.SetActive(true);
            Text.transform.position += new Vector3(0, 3, 0) * speed * Time.deltaTime;
            //  Debug.Log(playerscore);
        }
        if (TrashScript.Tinstance.IsTriggerd == true)
        {

            button.gameObject.SetActive(true);


        }
        if (TrashScript.Tinstance.IsTriggerd == false)
        {
            button.gameObject.SetActive(false);
        }

    }
    public void buttonClicked()
    {
        Debug.Log("Button");
        button.gameObject.SetActive(false);
        Text.gameObject.transform.localPosition = TrashScript.Tinstance.trash.transform.position;
        Text.gameObject.SetActive(true);
        Destroy(TrashScript.Tinstance.trash.gameObject);
        GameManager.Instance.AddTOScore(3);
        buttonIsCliked = true;

    }
}
