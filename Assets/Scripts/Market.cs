using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum Items { 
    SkinChanging, OxygenUpgrading
}

//public enum 
public class Market : MonoBehaviour
{
    [SerializeField] GameObject confirmationPanel;

    [SerializeField] TextMeshProUGUI scoreAmount;
    [SerializeField] TextMeshProUGUI skinCostTxt;
    [SerializeField] TextMeshProUGUI oxygenUpgradeTxt;

    [SerializeField] Button skinChanging;
    [SerializeField] Button upgradingOxygen;

    [SerializeField] GameObject skinItem;
    [SerializeField] GameObject oxygenItem;

    [SerializeField] GameObject itemsYouHave;
    [SerializeField] GameObject itemsYouDontHave;

    int skinCost = 100, oxygenUpgrade = 0;

    Items currentSelection;
    private void Start()
    {
        skinCostTxt.text = skinCost + " Coin";
        oxygenUpgradeTxt.text = oxygenUpgrade + " Coin";

        if (skinCost > GameManager.Instance.GetScore())
        {
            skinChanging.interactable = false;
        }
        if (oxygenUpgrade > GameManager.Instance.GetScore())
        {
            upgradingOxygen.interactable = false;
        }
    }
    
    private void OnEnable()
    {
        UpdateScore();
    }

    public void UpgradeTank() {
        confirmationPanel.SetActive(true);
        currentSelection = Items.OxygenUpgrading;
    }

    public void ChangeSkin() {
        confirmationPanel.SetActive(true);
        currentSelection = Items.SkinChanging;
    }

    private void UpdateScore()
    {

        scoreAmount.text = "Your Money : " +  GameManager.Instance.GetScore();

    }

    public void YesClicked() {
        confirmationPanel.SetActive(false);

        if (currentSelection.Equals(Items.OxygenUpgrading)) {
            GameManager.Instance.MinusFromSCore(oxygenUpgrade);
            GameManager.Instance.UpgradeOxygenTank(30);
            UpdateScore();
            oxygenItem.transform.SetParent(itemsYouHave.transform);
            oxygenUpgradeTxt.enabled = false;
        }

        else if (currentSelection.Equals(Items.SkinChanging))
        {
            GameManager.Instance.MinusFromSCore(skinCost);
            UpdateScore();
            skinItem.transform.parent.SetParent(itemsYouHave.transform);
            skinCostTxt.enabled = false;

        }
    }

    public void CancelClicked()
    {
        confirmationPanel.SetActive(false);
    }
}
