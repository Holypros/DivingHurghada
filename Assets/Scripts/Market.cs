using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*public enum Items { 
    SkinChanging, OxygenUpgrading
}*/

//public enum 
public class Market : MonoBehaviour
{
    [SerializeField] GameObject confirmationPanel;

    [SerializeField] TextMeshProUGUI scoreAmount;
    [SerializeField] TextMeshProUGUI skinCostTxt;
    [SerializeField] TextMeshProUGUI oxygenCostTxt;
    [SerializeField] TextMeshProUGUI oxygenUpgradeTxt;


    [SerializeField] Button defaultSkinBtn;
    [SerializeField] Button maleCharacterBtn;
    [SerializeField] Button femaleCharacterBtn;
    [SerializeField] Button skinChangingBtn;
    [SerializeField] Button upgradingOxygenBtn;

    [SerializeField] GameObject skinItem;
    [SerializeField] GameObject oxygenItem;

    [SerializeField] GameObject itemsYouHave;
    [SerializeField] GameObject itemsYouDontHave;

    int skinCost = 0, oxygenUpgrade = 0;
    bool defaultSkin = true, maleCharacter = true;

    Items currentSelection;
    private void Start()
    {
        skinCostTxt.text = skinCost + " Coin";
        oxygenCostTxt.text = oxygenUpgrade + " Coin";

        defaultSkinBtn.interactable = false;
        maleCharacterBtn.interactable = false;

        defaultSkinBtn.onClick.AddListener(ChangeSkin);
        skinChangingBtn.onClick.AddListener(ChangeSkinClicked);

        maleCharacterBtn.onClick.AddListener(ChangeCharacter);
        femaleCharacterBtn.onClick.AddListener(ChangeCharacter);


        if (skinCost > GameManager.Instance.GetScore())
        {
            skinChangingBtn.interactable = false;
        }
        if (oxygenUpgrade > GameManager.Instance.GetScore())
        {
            upgradingOxygenBtn.interactable = false;
        }
    }
    
    private void OnEnable()
    {
        UpdateScore();
    }

    public void UpgradeTankClicked() {
        confirmationPanel.SetActive(true);
        currentSelection = Items.OxygenUpgrading;
    }

    public void ChangeSkinClicked() {
        confirmationPanel.SetActive(true);
        //currentSelection = Items.SkinChanging;
    }

    private void UpdateScore()
    {

        scoreAmount.text = "Your Money : " +  GameManager.Instance.GetScore();

    }

    public void YesClicked() {
        confirmationPanel.SetActive(false);

        if (currentSelection.Equals(Items.OxygenUpgrading)) {
            GameManager.Instance.MinusFromSCore(oxygenUpgrade);
            GameManager.Instance.UpgradeOxygenTank(1f);
            oxygenUpgradeTxt.enabled = true;
            UpdateScore();
            oxygenItem.transform.SetParent(itemsYouHave.transform);
            upgradingOxygenBtn.interactable = false;
            oxygenCostTxt.enabled = false;
        }

        else /*if (currentSelection.Equals(Items.SkinChanging))*/
        {
            GameManager.Instance.MinusFromSCore(skinCost);
            UpdateScore();
            skinItem.transform.SetParent(itemsYouHave.transform);
            skinChangingBtn.onClick.RemoveListener(ChangeSkinClicked);
            skinChangingBtn.onClick.AddListener(ChangeSkin);

            skinCostTxt.enabled = false;

        }
    }

    public void CancelClicked()
    {
        confirmationPanel.SetActive(false);
    }

    public void ChangeSkin() 
    {
        if (defaultSkin)
        {
            skinChangingBtn.interactable = false;
            defaultSkinBtn.interactable = true;
            defaultSkin = false;

            //male with second skin
            if (maleCharacter)
            {
                GameManager.Instance.SetAvatar(2);
                Debug.Log("male with second skin");
            }
            //female with second skin
            else
            {
                GameManager.Instance.SetAvatar(5);
                Debug.Log("female with second skin");

            }

        }
        else 
        {
            
            skinChangingBtn.interactable = true;
            defaultSkinBtn.interactable = false;
            defaultSkin = true;
            //male with default skin
            if (maleCharacter)
            {
                GameManager.Instance.SetAvatar(1);
                Debug.Log("male with default skin");

            }
            //female with default skin
            else
            {
                GameManager.Instance.SetAvatar(4);
                Debug.Log("female with default skin");

            }

        }
    }

    public void ChangeCharacter()
    {
        if (maleCharacter)
        {
            femaleCharacterBtn.interactable = false;
            maleCharacterBtn.interactable = true;
            maleCharacter = false;

            //female with default skin
            if (defaultSkin)
            {
                GameManager.Instance.SetAvatar(4);
                Debug.Log("female with default skin");

            }
            //female with second skin
            else
            {
                GameManager.Instance.SetAvatar(5);
                Debug.Log("female with second skin");

            }

        }
        else
        {
            femaleCharacterBtn.interactable = true;
            maleCharacterBtn.interactable = false;
            maleCharacter = true;
            GameManager.Instance.SetAvatar(6);

            //male with default skin
            if (defaultSkin)
            {
                GameManager.Instance.SetAvatar(1);
                Debug.Log("male with default skin");

            }
            //male with second skin
            else
            {
                GameManager.Instance.SetAvatar(2);
                Debug.Log("male with second skin");

            }

        }
    }
}
