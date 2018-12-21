using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	public static int currentLevel;
	public void LoadNextScene()
	{
		int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
		int currSceneIndex = SceneManager.GetActiveScene().buildIndex;
		
		
		if(currSceneIndex == sceneCount - 2) //if we're currently at GameOver Scene
		{
			Debug.Log("On GameOver Screen, currentLevel here is " + currentLevel);
			
			//Change score of game to what it was before gameOver
			GameStatus gameStatus = FindObjectOfType<GameStatus>();
			gameStatus.updateScoreToBeforeGameOver();
			
			SceneManager.LoadScene(currentLevel);
		}
		else if (currSceneIndex == sceneCount -1) //if we are currently at win screen
		{
			Debug.Log(sceneCount);
			
			GameStatus gameStatus = FindObjectOfType<GameStatus>();
			gameStatus.ResetGame();
			
			SceneManager.LoadScene(0);
		}
		else{
			SceneManager.LoadScene(currSceneIndex + 1);
		}
	
	}
	public void LoadWinScene()
	{
		SceneManager.LoadScene("Win");
	}


}

