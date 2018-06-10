using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

	[SerializeField] private Text uiText;
	[SerializeField] private float mainTimer;
	[SerializeField] private Text mode;

	private float timer;
	private bool canCount = true;
	private bool doOnce = true;

	private Player player;


	public void Start()
	{
		player = GameObject.FindObjectOfType<Player>();	
		timer = mainTimer;
		GameManager.currentGameMode = GameMode.Procrastinate;
		
		
	}
	public void Update()
	{
		if (timer >= 0.0f && canCount)
		{
			timer -= Time.deltaTime;
			uiText.text = timer.ToString("f");
			mode.text = GameManager.currentGameMode.ToString();
		}
		else if(timer < 0.0f){
			if (doOnce)
			{
				GameManager.currentGameMode = GameMode.Productive;
				doOnce = false;
			}
			else
			{
				GameManager.currentGameMode = (GameMode)Random.Range(0,2);
			}
			timer=mainTimer;
			canCount= true;
			Debug.Log(GameManager.currentGameMode);
		}
	}
}
