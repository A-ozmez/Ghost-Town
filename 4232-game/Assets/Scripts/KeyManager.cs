 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
	public static KeyManager instance;
	public Text text;
	static int score;

	// Use this for initialization
	void Start()
	{
		score = 0;
		if (instance == null)
		{
			instance = this;
		}
	}


	void Update()
	{
		GiveScore();

	}


	public void ChangeScore(int value)
	{
		score += value;
		text.text = score.ToString() + " / 6 keys";

	}

	public static int GiveScore()
	{
		return (int)score;
	}
}
