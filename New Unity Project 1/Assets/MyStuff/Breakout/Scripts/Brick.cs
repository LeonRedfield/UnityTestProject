using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	private int maxHits;
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable; 
	public AudioClip crack;
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		//keep track of breakable bricks
		if(isBreakable)
		{
			breakableCount++;
			print (breakableCount);
		}
		
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		
		if(isBreakable)
		{
			handleHits();
		}		
	}
	
	void handleHits()
	{
		timesHit++;
		maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits)
		{
			breakableCount--;
			levelManager.brickDestroyed();
			Destroy(gameObject);
		}
		else
		{
			loadSprites();
		}
	}
	
	 void loadSprites()
	{
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex])
		{
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else
		{
			print("can't load sprite");
		}
		
	}
	
	// 	TODO remove this method once we can actually win!
	void SimulateWin()
	{
		levelManager.loadNextLevel();
	}
}
