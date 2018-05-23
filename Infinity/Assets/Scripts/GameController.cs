using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class GameController : MonoBehaviour {

	#region variables
	public Text scoreText;
	int score = 0;

	public GameObject gameOverPanel;
	#endregion

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GameOver()
	{
		Invoke ("ShowOverPanel", 2.0f);
	}

	void ShowOverPanel()
	{
		scoreText.gameObject.SetActive(false);
		gameOverPanel.SetActive(true);
	}

	public void Restart()
	{
		Application.LoadLevel(Application.loadedLevelName);
	}

	void IncrementScore()
	{
		score++;
		scoreText.text = score.ToString();
	}
}
