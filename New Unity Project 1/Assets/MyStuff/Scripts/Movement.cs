using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public GameObject cube;
	public JoystickScript joystick;
	public float moveSpeed;
	public float jumpSpeed;
	//private CharacterController controller;

	// Use this for initialization
	void Start () {
		cube = GameObject.FindGameObjectWithTag("Player");
		moveSpeed = 10f;
		jumpSpeed = 10f;
		//controller = GetComponent<CharacterController>();
		//Physics.gravity = new Vector3(0,-50,0);
	}
	
	// Update is called once per frame
	void Update () {

		cube.transform.Translate(new Vector3(moveSpeed*joystick.Horizontal()*Time.deltaTime, 0f,moveSpeed*joystick.Vertical()*Time.deltaTime));



		/*
		if(Input.GetKey(KeyCode.UpArrow)){
				cube.transform.position += new Vector3(0,0,0.1f);
			}

		if(Input.GetKey(KeyCode.DownArrow)){
			cube.transform.position -= new Vector3(0,0,0.1f);
		
		}
		if(Input.GetKey(KeyCode.RightArrow)){
				cube.transform.position += new Vector3(0.1f,0,0);
		}

		if(Input.GetKey(KeyCode.LeftArrow)){
			cube.transform.position -= new Vector3(0.1f,0,0);
		}

		if(Input.GetKey(KeyCode.Space) && cube.transform.position.y < 5)
		{
			cube.transform.position += new Vector3(0,0.3f,0);
		}*/

	}

	public void Jump()
	{
		if(cube.transform.position.y <= 1)
		{	

			GetComponent<Rigidbody>().velocity += new Vector3(0,jumpSpeed,0);
		}
	}
}