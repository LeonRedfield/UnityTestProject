using UnityEngine;
using System.Collections;

public class BuildingsBehaviour : MonoBehaviour {
	GameObject Road;
	GameObject[] Buildings;
	// Use this for initialization
	void Start () {
		Buildings = GameObject.FindGameObjectsWithTag("Buildings");
		Road = GameObject.FindGameObjectWithTag("Road");
		//Debug.Log("nr of buildings = " + Buildings.Length);


		//setUp Buildings:
		Vector3 roadSize = Road.GetComponent<Collider>().bounds.size;
		//Vector3 roadPos = Road.transform.position;
			//Debug.Log(roadSize);
			//Position:
			for(int i=0;i<Buildings.Length;i++)
			{
				Buildings[i].transform.position = new Vector3((0 - (roadSize.x/2) + (Buildings[i].GetComponent<Collider>().bounds.size.x/2) + (i*25)), 0, 0);
				//Debug.Log(Buildings[i].transform.position);
			}

	}

}
