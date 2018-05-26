using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

	[SerializeField] private Text uiText;
	[SerializeField] private float mainTimer;

	private float timer;
	private bool canCount = true;
	private bool doOnce = false;

	private Player player;
	public GameMode currentGameMode;

	

	public enum GameMode
	{
		Productive, 
		Procrastinate
	}

	public void Start()
	{
		
		timer = mainTimer;
		currentGameMode = GameMode.Procrastinate;
		
	}
	public void Update()
	{
		player = GetComponent<Player>();
		if (timer >= 0.0f && canCount)
		{
			timer -= Time.deltaTime;
			uiText.text = timer.ToString("f");
		}

		else if(timer <= 0.0f && !doOnce){
			/*canCount=false;
			doOnce = true;
			uiText.text= "0.00";
			timer= 0.0f;*/
			timer=mainTimer;
			canCount= true;
			doOnce = false;
			currentGameMode = (GameMode)Random.Range(0,2);
		}

		switch (currentGameMode)
		{
			case GameMode.Procrastinate:
				Debug.Log("procrastinating");
				player.tagObjectGood = "Good";
				player.tagObjectBad = "Bad";
				break;
			case GameMode.Productive:
				Debug.Log("producing");
				player.tagObjectGood = "Bad";
				player.tagObjectBad = "Good";
				break;
		}
	}
}
