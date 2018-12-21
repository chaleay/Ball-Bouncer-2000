using UnityEngine;

public class Block : MonoBehaviour {

	//Block params
	[SerializeField] AudioClip breakSound;
	[SerializeField] GameObject blockDestroyVFX;
	[SerializeField] int maxHealth = 1;
	[SerializeField] Sprite [] hitSprites;
	[SerializeField] bool isRandomColor;
	int spriteIndex;
	int currentHealth;
	int healthLevels;	
	
	//Cached references
	Level level;
	GameStatus gameStatus;

	private void Start()
	{
		spriteIndex = -1;
		if(isRandomColor)
		{
		 Color newColor = new Color(Random.Range(0,1.0f),Random.Range(0,1.0f),Random.Range(0,1.0f));
		 GetComponent<SpriteRenderer>().color = newColor;
		}
		if(tag == "Breakable")
			blockHealthCalculations();
		
		level = FindObjectOfType<Level>();
		gameStatus = FindObjectOfType<GameStatus>();
		if(tag == "Breakable")
		{
			level.CountBreakableBlocks();
		}
	}

	private void blockHealthCalculations()
	{
		currentHealth = maxHealth;
		healthLevels = (int) Mathf.Ceil( (float) maxHealth / (hitSprites.Length + 1) );
		Debug.Log(healthLevels);
	}
	private void OnCollisionEnter2D(Collision2D col)
	{
		if(tag == "Breakable")
		{
			HandleHit();
		}
	}

	private void HandleHit()
	{
		currentHealth--;
		int currentHits = maxHealth - currentHealth;
		int transition = currentHits % healthLevels;
		if(currentHealth == 0)
		{
			DestroyBlock();
		}
		else if(transition == 0)
		{
			spriteIndex++;
			GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}

	//operations conducted upon destroying a block
	private void DestroyBlock()
	{
		TriggerEffects();
		level.DecrementNumBlocks();
		Destroy(gameObject);
		gameStatus.addToScore();
	}

	private void TriggerEffects()
	{
		AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
		GameObject sparkles = Instantiate(blockDestroyVFX, transform.position, transform.rotation);
		Destroy(sparkles, 1f);
	}

}
