using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;

    static int Score = 0;
    float maxY = 27.2f;
    float minY = -60f;
    public float playerLength;
    //[HideInInspector]
    //public int CreatureMovementCounter=0;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddTOScore(int score)
    {
        Score += score;

    }


    public void MinusFromSCore(int score)
    {
        Score -= score;
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

}