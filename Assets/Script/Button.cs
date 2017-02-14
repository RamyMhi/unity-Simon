using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
public class Button : MonoBehaviour {

	public int buttenIndex{ get; set;}

	#region private 
	[SerializeField]Color defaultColor;
	[SerializeField]Color highlightedColor;
	[SerializeField]float resetTimer=0.8f;
	[SerializeField]GameManager gm;
	AudioSource sound;

	#endregion

	#region private function

	void Awake()
	{
		sound = GetComponent<AudioSource> ();
	}


	void Start()
	{
		resetButton ();
	}

	// push button and change button color
	void OnMouseDown()
	{
		gm.PlayerPick (buttenIndex);
		pressButton ();
	}


	// reset button color
	void resetButton()
	{
		GetComponent<MeshRenderer> ().material.color = defaultColor;
	}

	#endregion

	#region public function
	//press button make it pulic for use in game manager
	public void pressButton()
	{
		GetComponent<MeshRenderer> ().material.color = highlightedColor;
		sound.Play ();
		Invoke ("resetButton", resetTimer);
	}

	#endregion
}
