using UnityEngine;
using System.Collections;

public class BorderBehaviour : MonoBehaviour {
	GameObject Road;
	GameObject BorderN; //North of camera
	GameObject BorderS; //South -||-
	GameObject BorderW; //West -||-
	GameObject BorderE; //East -||-

	// Use this for initialization
	void Start () {
		Road = GameObject.FindGameObjectWithTag("Road");
		BorderN = GameObject.FindGameObjectWithTag("BorderNorthOfCamera");
		BorderS = GameObject.FindGameObjectWithTag("BorderSouthOfCamera");
		BorderW = GameObject.FindGameObjectWithTag("BorderWestOfCamera");
		BorderE = GameObject.FindGameObjectWithTag("BorderEastOfCamera");
		 
		Vector3 roadSize = Road.GetComponent<Collider>().bounds.size;
		Vector3 roadPos = Road.transform.position;
		float borderH = 12;
		//Debug.Log("roadSize = " + roadSize);
		//Debug.Log("BorderS = " + BorderS.GetComponent<Collider>().bounds.size);


		//SetUp Scenario:
			//Scale:

			BorderN.transform.localScale = new Vector3(roadSize.x,borderH,1);
			BorderS.transform.localScale = new Vector3(roadSize.x,borderH,1);
			BorderW.transform.localScale = new Vector3(1,borderH,roadSize.z);
			BorderE.transform.localScale = new Vector3(1,borderH,roadSize.z);

			//Position:
			/*
				the roadPosZ = -10 and it's width = 30 (same measurement as the pos). 
				North-end of road:
				So if we take the width/2 of the road, we get the position of the width-end of the road(Z-position) which is 15.
				and because the posZ of the road starts at -10, we must add that to the width-end position. Result = 5.

				South-end of road pos: 
				same as North-end of road but the width-end position must be negative(-15).
			*/
		BorderN.transform.position = new Vector3(0,(BorderN.GetComponent<Collider>().bounds.size.y/2) -0.5f,((roadSize.z/2) + roadPos.z));
			BorderS.transform.position = new Vector3(0,0,((-roadSize.z/2) + roadPos.z));
			BorderE.transform.position = new Vector3(((roadSize.x/2) + roadPos.x),0,roadPos.z);
			BorderW.transform.position = new Vector3(((-roadSize.x/2) + roadPos.x),0, roadPos.z);




	}
}
