using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {
	GameObject MainCamera;
	GameObject Player;
	float oldCameraPosX = 0;
	float oldCameraPosZ = -38.0f;
	float oldPlayerPosZ = 0;
	// Use this for initialization
	void Start () {
		MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		Player = GameObject.FindGameObjectWithTag("Player");
		MainCamera.transform.position = new Vector3(Player.transform.position.x, 10.0f, oldCameraPosZ);
		oldPlayerPosZ = Player.transform.position.z;
		//adjustToScreen();
		//Debug.Log("InStart: oldPosX = " + Player.transform.position.x + " cameraposX = " + MainCamera.transform.position.x);
		//MainCamera.transform.position = new Vector3(0, 10,-34); //hardcoded for test, will change in future
		//MainCamera.transform.rotation = Quaternion.Euler(20,0,0);//for test to put default rotation.
	}
	
	// Update is called once per frame
	void Update () {
		if(oldCameraPosX != Player.transform.position.x)//so the camera doesnt update to the same pos even when the player is not moving.
		{
			//Debug.Log("oldPosX = " + Player.transform.position.x + " cameraposX = " + MainCamera.transform.position.x);
			MainCamera.transform.position = new Vector3(Player.transform.position.x, 10.0f, oldCameraPosZ); //hardcoded for test, will change in future
			oldCameraPosX = MainCamera.transform.position.x;
		}
		//Debug.Log("oldPlayerPosZ = " + oldPlayerPosZ);
		//Debug.Log("playerPosZ = " + Player.transform.position.z);
		//Debug.Log("CameraPosZ = " + MainCamera.transform.position.z);
		if(Player.transform.position.z < 0 && Player.transform.position.z > -20)
		{
			//Debug.Log(" playerPosZ - oldCameraPosZ= " + (Player.transform.position.z - oldPlayerPosZ) );
			if(oldCameraPosZ != Player.transform.position.z)
			{
				MainCamera.transform.position = new Vector3(oldCameraPosX, 10.0f, oldCameraPosZ + (Player.transform.position.z - oldPlayerPosZ));
				
			}
		}

		oldCameraPosZ = MainCamera.transform.position.z;
		oldPlayerPosZ = Player.transform.position.z;
		//Debug.Log("CameraPosZ = " + MainCamera.transform.position.z);

	}

	private void adjustToScreen()
	{
		// set the desired aspect ratio (the values in this example are
         // hard-coded for 16:9, but you could make them into public
         // variables instead so you can set them at design time)
         float targetaspect = 16.0f / 9.0f;
  
         // determine the game window's current aspect ratio
         float windowaspect = (float)Screen.width / (float)Screen.height;
  
         // current viewport height should be scaled by this amount
         float scaleheight = windowaspect / targetaspect;
  
         // obtain camera component so we can modify its viewport
         Camera camera = GetComponent<Camera>();
  
         // if scaled height is less than current height, use HorizentalScreen
         if (scaleheight < 1.0f)
         {
             Rect rect = camera.rect;
  
             rect.width = 1.0f;
             rect.height = scaleheight;
             rect.x = 0;
             rect.y = (1.0f - scaleheight) / 2.0f;
  
             camera.rect = rect;
         }
         else // use verticalScreen
         {
             float scalewidth = 1.0f / scaleheight;
  
             Rect rect = camera.rect;
  
             rect.width = scalewidth;
             rect.height = 1.0f;
             rect.x = (1.0f - scalewidth) / 2.0f;
             rect.y = 0;
  
             camera.rect = rect;
         }
	}
} 
 