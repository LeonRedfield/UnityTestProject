using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OpenDoorButton : MonoBehaviour {
	
	private GameObject Player;
	private GameObject[] Buildings;
	private Vector3[] BuildingsPos;
	static bool init = false;
	
	// Use this for initialization
	void Start () {
	
		
	}
	
	// Update is called once per frame
	public void OpenDoor () {
		
		if(!init)
		{
			Player = GameObject.FindGameObjectWithTag("Player");
			Buildings = GameObject.FindGameObjectsWithTag("Buildings");
			BuildingsPos = new Vector3[Buildings.Length];
			
			for(int i=0; i<Buildings.Length;i++)
			{
				BuildingsPos[i] = Buildings[i].transform.position;
			}
			init = true;
		}
		
		for(int i=0;i<Buildings.Length;i++)
		{
			if((Player.transform.position.z >= (BuildingsPos[i].z-7)) && ( (Player.transform.position.x > (BuildingsPos[i].x - 2)) && (Player.transform.position.x < (BuildingsPos[i].x +2))) )
			{
				init = false;
				SceneManager.LoadScene("Start");
				
				Debug.Log ("BuildningZPos=" + BuildingsPos[i].z + " X = " + BuildingsPos[i].x);
				Debug.Log("x =" + Player.transform.position.x + " z=" + Player.transform.position.z);
				Debug.Log ("open door available!!");
			}
		}
		
	}
}
