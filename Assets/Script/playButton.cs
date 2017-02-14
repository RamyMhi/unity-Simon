using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playButton : MonoBehaviour {
	[SerializeField]GameManager gm;

	public void Playbtn()
	{
		Debug.Log ("play pished");
		gm.PlayG ();
		Activate (false);
	}

	public void Activate (bool isActive = true)
	{
		gameObject.SetActive(isActive);
	}
}
