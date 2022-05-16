using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;

    static int Score = 0;
    float maxY = 27.2f;
    float minY = -60f;
    public float playerLength;

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

}