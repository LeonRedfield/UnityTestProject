using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelmanager;
	
	void OnTriggerEnter2D(Collider2D trigger)
	{
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
		print("Trigger");
		levelmanager.loadLevel("LooseScreen");
	
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		print("Collision");
	}
}
