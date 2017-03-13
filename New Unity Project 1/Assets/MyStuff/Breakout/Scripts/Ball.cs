using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(!hasStarted)
		{
			// Lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + (new Vector3(0,paddle.transform.position.y,0));
			//Debug.Log("position: " + this.transform.position);
			//Debug.Log("paddleToBallVector = "+ paddleToBallVector.ToString());
			//Debug.Log ("scale= "+this.transform.localScale.x.ToString());
			//Wait for the mouse to lauch the ball.
			if(Input.GetMouseButton(0))
			{
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
				hasStarted = true;
			}
		}
		
	}
	
	void onCollisionEnter2D(Collision2D collision)
	{
		if(hasStarted)
		{
			GetComponent<AudioSource>().Play();
		}
		
	}
}
