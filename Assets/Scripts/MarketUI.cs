using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketUI : MonoBehaviour
{
    [SerializeField] Image suitsBtn;
    [SerializeField] Image tankBtn;
    [SerializeField] Color color;

    [SerializeField] GameObject suits;
    [SerializeField] GameObject tank;
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

                ChangeCurrentSelection(suitsBtn);

                suits.SetActive(true);
                tank.SetActive(false);

                break;
            case 1:
                suitsBtn.color = Color.white;
                ChangeCurrentSelection(tankBtn);
                suits.SetActive(false);
                tank.SetActive(true);
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
