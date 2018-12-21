using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	
	[SerializeField] private float screenWidthUnits = 16f;
	[SerializeField] private float screenHeightUnits = 12f;
	[SerializeField] private const float minX = 1;
	[SerializeField] private const float maxX = 15;
	GameStatus gameStatus;
	Ball ball;

	// Use this for initialization
	void Start () {
		transform.position = new Vector2(8f, .25f);
		gameStatus = FindObjectOfType<GameStatus>();
		ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//Stores mouse position
		float mousePosY = Input.mousePosition.y / Screen.height * screenHeightUnits;
		
		//Makes a new vector2, which stores x and y of paddle's current location
		Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
		
		paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
		paddlePos.y = Mathf.Clamp(mousePosY, .25f, 1f);

		//transforming (moving) paddle to x/y coordinate pair saved in vector2
		transform.position = paddlePos; 
		
		//For y-axis movement
		//Debug.Log("Current Y:" + Input.mousePosition.y / Screen.height * screenHeighUnits );
	}

	private float GetXPos()
	{
		if(gameStatus.IsAutoPlayEnabled())
			return ball.transform.position.x;
		else return Input.mousePosition.x / Screen.width * screenWidthUnits;
	}
}
