using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	[SerializeField] Paddle paddle1;
	[SerializeField] float randomFactor = 1f;
	private bool hasStarted = false;
	private float xPush = 2f;
	private float yPush = 15f;

	[SerializeField] AudioClip[] ballSounds;
	
	// state
	Vector2 paddleToBallVector; 

	//cached
	AudioSource audioSource;
	Rigidbody2D ballRigidBody;

	// Use this for initialization
	void Start () {
		
		paddleToBallVector = transform.position - paddle1.transform.position;
		audioSource = GetComponent<AudioSource>();
		ballRigidBody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!hasStarted){
			LockBallToPaddle();
			LaunchOnMouseClick();
		}
    }

	private void LaunchOnMouseClick()
	{
		if(Input.GetMouseButtonDown(0))
		{
			
			//access rigidBody of the Ball
			ballRigidBody.velocity = new Vector2(xPush, yPush);
			hasStarted = true;
		}
	}

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
		
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Vector2 newVelocity = new Vector2(UnityEngine.Random.Range(0f,randomFactor),
		UnityEngine.Random.Range(0f, randomFactor));
		
		if(hasStarted)
		{
			AudioClip clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)];
			audioSource.PlayOneShot(clip);
			ballRigidBody.velocity += newVelocity;
		}
	}
}
