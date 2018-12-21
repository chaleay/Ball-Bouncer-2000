using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int numBlocks;
    [SerializeField] bool lastLevel;
    SceneLoader sceneLoader;
    GameStatus gameStatus;

    private void Start(){
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    
    public void CountBreakableBlocks()
    {
        numBlocks++;
    }

    public void DecrementNumBlocks()
    {
        numBlocks--;
        if(numBlocks <= 0)
        {
            if(lastLevel)
                sceneLoader.LoadWinScene();
            else 
                sceneLoader.LoadNextScene();
        }
    }
}
