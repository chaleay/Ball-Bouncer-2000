using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Need this for textMeshPro access
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;

    //Game State
    [SerializeField] int scorePerBlockDestroyed = 10;
    public static int score = 0;
    public static int scoreBeforeGameOver = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool autoplay;

    // Start is called before the first frame update
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            scoreBeforeGameOver = score;
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }     

        if(gameObject) //not null
        {
            scoreText.text = score.ToString();
            Time.timeScale = gameSpeed;
        }
       
   }
    
    public void addToScore()
    {
        score += scorePerBlockDestroyed;
        scoreText.text = score.ToString();
        
    }

    public void updateScoreToBeforeGameOver()
    {
        score = scoreBeforeGameOver;
        scoreText.text = score.ToString();
    }

    public void ResetGame()
    {
        scoreBeforeGameOver = score = 0;
        Destroy(this.gameObject);
    }
    
    public bool IsAutoPlayEnabled()
    {
        return autoplay;
    }
}
