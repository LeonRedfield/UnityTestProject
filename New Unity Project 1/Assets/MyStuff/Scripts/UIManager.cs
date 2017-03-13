using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public GameObject pausePanel;
	public GameObject controls;
	public bool isPaused;
	private Vector3[] PosOfControls;

	// Use this for initialization
	void Start () {
		isPaused = false;
		InitControls();

	}
	
	// Update is called once per frame
	void Update () {
		if(isPaused)
		{
			PauseGame(true); //will show pause menu
		}
		else
		{
			PauseGame(false);
		}

		/*if(Input.GetButtonDown("ConfigurateButton"))
		{
			SwitchPause();
		}*/
	}

	void PauseGame(bool state)
	{
		if(state)
		{
			Time.timeScale = 0.0f; // paused
		}
		else{
			Time.timeScale = 1.0f;	// normal speed
		}
		//Debug.Log("state = " + state );
		pausePanel.SetActive(state);
		controls.SetActive(!state);

	}

	public void SwitchPause()
	{
		if(isPaused)
		{
			isPaused = false;
		}
		else{
			isPaused = true;
		}
	}

	public void SwitchControlsSide()
	{
		//Debug.Log("amount of child: " + controls.transform.childCount);
		int index= 0;
		Vector3[] tmpPos = new Vector3[PosOfControls.Length];

		for(int i=controls.transform.childCount-1; i>=0;i--)
		{
			tmpPos[index] = controls.transform.GetChild(index).transform.position = PosOfControls[i];
			//Debug.Log ("tmpPos=" + tmpPos[index]);	
			index++;
			//Debug.Log("Posof = "+ PosOfControls[i]);
		}
		PosOfControls = tmpPos;
	}

	private void InitControls()
	{
		PosOfControls = new Vector3[controls.transform.childCount]; // creates an array with the lenght of amount of childs.
		int i = 0;
		foreach(Transform controlchild in controls.transform)
		{
			PosOfControls[i++] = controlchild.transform.position;
		}
		
	}
}
