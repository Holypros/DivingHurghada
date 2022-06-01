using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketUI : MonoBehaviour
{
    [SerializeField] Image suitsBtn;
    [SerializeField] Image tankBtn;
    [SerializeField] Image ownedBtn;
    [SerializeField] Color color;

    [SerializeField] GameObject suits;
    [SerializeField] GameObject tank;
    [SerializeField] GameObject owned;
    void Start()
    {
        ButtonPressed(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPressed(int index) {
        switch (index)
        {
            case 0:
                tankBtn.color = Color.white;
                ownedBtn.color = Color.white;

                ChangeCurrentSelection(suitsBtn);

                suits.SetActive(true);
                tank.SetActive(false);
                owned.SetActive(false);

                break;
            case 1:
                suitsBtn.color = Color.white;
                ownedBtn.color = Color.white;
                ChangeCurrentSelection(tankBtn);
                suits.SetActive(false);
                tank.SetActive(true);
                owned.SetActive(false);
                break;
            case 2:
                tankBtn.color = Color.white;
                suitsBtn.color = Color.white;
                ChangeCurrentSelection(ownedBtn);
                suits.SetActive(false);
                tank.SetActive(false);
                owned.SetActive(true);
                break;

            default:
                break;
        }
    }

    void ChangeCurrentSelection(Image btn) {
        btn.color = color;
        /*Rect r = btn.gameObject.GetComponent<RectTransform>().rect;
        
        r.height += 2;
        btn.gameObject.GetComponent<RectTransform>().
        ColorBlock c = btn.colors;
        c.normalColor = color;
        btn.colors = c;*/
    }
}
