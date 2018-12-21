using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {
	
	private void OnTriggerEnter2D(Collider2D collision){
		SceneLoader.currentLevel = SceneManager.GetActiveScene().buildIndex;
		Debug.Log("On this level:" + SceneLoader.currentLevel);
		SceneManager.LoadScene("GameOver", LoadSceneMode.Single);

	}

}
