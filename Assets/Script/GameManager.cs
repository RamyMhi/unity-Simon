using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	[SerializeField]playButton playbtn;
	[SerializeField] Button[] button;
	[Header("Color Order")]
	[SerializeField]List<int> colorOrder;
	[SerializeField]float delaySec=1f;
	[SerializeField]int pickNumber=0;
	[SerializeField]Score score;

	// Use this for initialization
	void Start () {
		resetGame ();
		setButtonIndex ();


	}
	public void PlayG()
	{
		StartCoroutine ("PlayGame");
	}

	IEnumerator PlayGame()
	{
		pickNumber = 0;
		yield return new WaitForSeconds (delaySec);

		//play  color that are stored
		foreach (int colorIndex in colorOrder) {
			button [colorIndex].pressButton ();
			yield return new WaitForSeconds (delaySec);
		}
		randomColor ();
	}

	void randomColor()
	{
		int rnd = Random.Range (0, button.Length);
		colorOrder.Add (rnd);
		button [rnd].pressButton ();
	}


	void setButtonIndex()
	{
		for (int i = 0; i < button.Length; i++) {
			button [i].buttenIndex = i;
		}
	}

	public void PlayerPick(int pick)
	{
		if (pick == colorOrder [pickNumber]) {
			pickNumber++;
			if (pickNumber == colorOrder.Count) {
				// update score
				score.add();
				StartCoroutine ("PlayGame");
			}
			Debug.Log ("success");
		} else {
			Debug.Log ("unsucces");
			playbtn.Activate (true);
			resetGame ();
		}
	}
	 void resetGame()
	{
		score.CheckHighScore ();
		score.Set ();
		colorOrder.Clear ();
	}
}
