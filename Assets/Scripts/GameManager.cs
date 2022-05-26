using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;

    float oxygenLossRate = 10f;
    int Score = 0;
    float maxY = 27.2f;
    float minY = -60f;
    int avatar = 1;
    public float playerLength;
    //[HideInInspector]
    //public int CreatureMovementCounter=0;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;

            
        }
        else if( Instance !=this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);

        PlayerPrefs.SetInt("Score", Score);
        PlayerPrefs.GetInt("Score");

    }
  

    public void AddTOScore(int score)
    {
        Score += score;

    }


    public void MinusFromSCore(int score)
    {
        if (Score - score < 0)
        {
            Debug.Log("Score is less than zero");
        }
        else 
        {
            Score -= score;
        }
    }
    public int GetScore()
    {
        return Score;
    } 
  //public  void setMaxY(float depthmax)
  //  {
  //      maxY = depthmax;

  //  } 
  public  float GetMaxY()
    {
        return maxY;
    } 
  //public  void SetMinY(float depthmin)
  //  {
  //      minY = depthmin;
  //  } 
   public float GetMinY()
    {
        return minY;
    } 
   public void SetPlayerLength(float PlayerLenght)
    {
        playerLength = PlayerLenght;

    } 
   public float GetPlayerLength() 
    {
        return playerLength;
    }

    public void UpgradeOxygenTank(float value)
    {
        oxygenLossRate = value;
    }

    public float GetOxygenTank()
    {
        return oxygenLossRate;
    }

    public void SetAvatar(int a) {
        avatar = a;
    }

    public int GetAvatar()
    {
        return avatar;
    }
}
    //public void trans()
    //{
    //    UiManager.UiInstance.congrats.gameObject.transform.localPosition = CreatureScript.Tinstance.creature.transform.position;
    //    UiManager.UiInstance.congrats.gameObject.SetActive(true);
    //    Destroy(CreatureScript.Tinstance.creature.gameObject);
    //    UiManager.UiInstance.caughtCreature = true;
    //    UiManager.UiInstance.catchButton.gameObject.SetActive(false);
    //    CreatureScript.Tinstance.IsTriggerd = false;
    //    UiManager.UiInstance.nextLevel.gameObject.SetActive(true);
    //}

