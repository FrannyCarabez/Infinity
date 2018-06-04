using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	public int posScore = 10;
	public int negScore = -10;

	public int GetScore(GameMode gm)
	{
		if (gm == GameMode.Productive) {
			return posScore;
		} else {
			return negScore;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
