using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	[SerializeField] int score=0;
	[SerializeField] int hscore=0;
	[SerializeField]Text scoreText;
	[SerializeField]Text Hscore;


	void Start()
	{
		Set ();
		loadHighScore ();
	}

	void updateScore()
	{
		scoreText.text = score.ToString ();
	}

	public void add (int s = 1)
	{
		score+=s;
		updateScore ();
	}

	public void Set(int s= 0)
	{
		score = s;
		updateScore ();
	}

	void loadHighScore()
	{
		hscore = PlayerPrefs.GetInt ("highScore", 0);
		updateHighScore ();
	}

	void saveHighScore()
	{
		PlayerPrefs.SetInt ("highScore", hscore);
		updateHighScore ();
	}
	void updateHighScore()
	{
		Hscore.text = hscore.ToString ();
	}

	public void CheckHighScore()
	{
		if (score > hscore) {
			hscore = score;
			saveHighScore ();
		}
	}
}
