using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void loadLevel(string name)
	{
		Debug.Log("Level load requested for: " + name);
		SceneManager.LoadScene(name);
	}
	
	public void quitRequest()
	{
		Debug.Log("I want to quit");
		SceneManager.LoadScene("MainGame");
	}
	
	public void loadNextLevel()
	{
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1);
	}
	
	public void brickDestroyed()
	{
		if(Brick.breakableCount <= 0)
		{
			SceneManager.LoadScene("Win");	
		}
	}
}
