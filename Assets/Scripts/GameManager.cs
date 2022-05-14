using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;

    static int Score = 0;

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

}