using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public enum Items
{
    MaleSkinChanging, FemaleSkinChanging, OxygenUpgrading
}

public class MarketHandling : MonoBehaviour
{
    [SerializeField] GameObject confirmationPanel;

    [SerializeField] Image charImg;
    //[SerializeField] GameObject femaleImg;

    [SerializeField] GameObject tankBuy;
    [SerializeField] GameObject maleSkinBuy;
    [SerializeField] GameObject femaleSkinBuy;

    [SerializeField] Button maleSkin;
    [SerializeField] Button femaleSkin;

    [SerializeField] Button maleSkinExtra;
    [SerializeField] Button femaleSkinExtra;

    [SerializeField] TextMeshProUGUI scoreAmount;

    [SerializeField] ScrollRect scrollRect;

    Items currentSelection;
    int maleSkinCost = 0, femaleSkinCost = 0, oxygenUpgrade = 0;

    void Start()
    {
        UpdateScore();

        if (PlayerPrefs.GetInt("UpgradeTank") == 1)
        {
            tankBuy.SetActive(false);
            GameManager.Instance.UpgradeOxygenTank(1f);

        }
        else
        {
            if (oxygenUpgrade > GameManager.Instance.GetScore())
            {
                tankBuy.GetComponentInChildren<Button>().interactable = false;
            }
        }


        if (PlayerPrefs.GetInt("BuyFemaleSkin") == 1)
        {
            femaleSkinBuy.SetActive(false);
            femaleSkinExtra.interactable = true;
        }
        else
        {
            if (maleSkinCost > GameManager.Instance.GetScore())
            {
                maleSkinBuy.GetComponentInChildren<Button>().interactable = false;
            }
        }


        if (PlayerPrefs.GetInt("BuyMaleSkin") == 1)
        {
            maleSkinBuy.SetActive(false);
            maleSkinExtra.interactable = true;
        }
        else 
        {
            if (femaleSkinCost > GameManager.Instance.GetScore())
            {
                femaleSkinBuy.GetComponentInChildren<Button>().interactable = false;
            }
        }


        if (PlayerPrefs.GetInt("MaleCharacter") == 0)
        {
            ChangeToFemaleCharacter();
            ChangeFemaleSkin(PlayerPrefs.GetInt("extraSkin"));
        }
        else
        {
            ChangeToMaleCharacter();
            ChangeMaleSkin(PlayerPrefs.GetInt("extraSkin"));

        }
    }

    private void OnEnable()
    {
        UpdateScore();
    }

    public void UpgradeTankClicked()
    {
        confirmationPanel.SetActive(true);
        currentSelection = Items.OxygenUpgrading;
    }

    public void UpgradeTank()
    {
        tankBuy.SetActive(false);
        GameManager.Instance.MinusFromSCore(oxygenUpgrade);
        GameManager.Instance.UpgradeOxygenTank(1f);
        UpdateScore();
        PlayerPrefs.SetInt("UpgradeTank", 1);
    }

    public void ExtraMaleSkinClicked()
    {
        confirmationPanel.SetActive(true);
        currentSelection = Items.MaleSkinChanging;
    }

    public void ExtraFemaleSkinClicked()
    {
        confirmationPanel.SetActive(true);
        currentSelection = Items.FemaleSkinChanging;
    }

    public void ChangeMaleSkin(int def)
    {
        if (def == 0)
        {
            GameManager.Instance.SetAvatar(1);
            charImg.sprite = maleSkin.gameObject.GetComponent<Image>().sprite;
            PlayerPrefs.SetInt("extraSkin", 0);

        }
        else
        {
            GameManager.Instance.SetAvatar(2);
            charImg.sprite = maleSkinExtra.gameObject.GetComponent<Image>().sprite;
            PlayerPrefs.SetInt("extraSkin", 1);


        }
    }

    public void ChangeFemaleSkin(int def)
    {
        if (def == 0)
        {
            GameManager.Instance.SetAvatar(4);
            charImg.sprite = femaleSkin.gameObject.GetComponent<Image>().sprite;
            PlayerPrefs.SetInt("extraSkin", 0);

        }
        else
        {
            GameManager.Instance.SetAvatar(5);
            charImg.sprite = femaleSkinExtra.gameObject.GetComponent<Image>().sprite;
            PlayerPrefs.SetInt("extraSkin", 1);

        }
    }
    private void UpdateScore()
    {
        scoreAmount.text = "Your Money : " + GameManager.Instance.GetScore();
    }

    public void ChangeToMaleCharacter()
    {
        charImg.sprite = maleSkin.gameObject.GetComponent<Image>().sprite;
        //femaleImg.SetActive(false);
        //maleImg.SetActive(true);

        femaleSkin.interactable = false;
        femaleSkinExtra.interactable = false;

        maleSkin.interactable = true;
        if (maleSkinBuy.activeInHierarchy == false)
            maleSkinExtra.interactable = true;

        scrollRect.normalizedPosition = new Vector2(0, 0);
        PlayerPrefs.SetInt("MaleCharacter", 1);

    }

    public void ChangeToFemaleCharacter()
    {
        charImg.sprite = femaleSkin.gameObject.GetComponent<Image>().sprite;
        //maleImg.SetActive(false);
        //femaleImg.SetActive(true);

        maleSkin.interactable = false;
        maleSkinExtra.interactable = false;

        femaleSkin.interactable = true;
        if(femaleSkinBuy.activeInHierarchy == false)
            femaleSkinExtra.interactable = true;

        scrollRect.normalizedPosition = new Vector2(1, 0);
        PlayerPrefs.SetInt("MaleCharacter", 0);

    }

    public void YesClicked()
    {
        confirmationPanel.SetActive(false);

        if (currentSelection.Equals(Items.OxygenUpgrading))
        {
            UpgradeTank();
        }

        else if (currentSelection.Equals(Items.MaleSkinChanging))
        {
            GameManager.Instance.MinusFromSCore(maleSkinCost);
            UpdateScore();
            maleSkinBuy.SetActive(false);
            maleSkinExtra.interactable = true;
            PlayerPrefs.SetInt("BuyMaleSkin", 1);

        }
        else if (currentSelection.Equals(Items.FemaleSkinChanging))
        {
            GameManager.Instance.MinusFromSCore(femaleSkinCost);
            UpdateScore();
            femaleSkinBuy.SetActive(false);
            femaleSkinExtra.interactable = true;
            PlayerPrefs.SetInt("BuyFemaleSkin", 1);

        }
    }

    public void CancelClicked()
    {
        confirmationPanel.SetActive(false);
    }
}