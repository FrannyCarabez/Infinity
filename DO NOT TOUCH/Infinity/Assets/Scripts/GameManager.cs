using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {

	private static GameMode _currentGameMode = GameMode.Procrastinate;

	public static GameMode currentGameMode
	{
		get {
			return _currentGameMode;
		}
		set {
			_currentGameMode = value;
			Debug.Log(currentGameMode);
		}
	}

	public static string gameModeString
	{
		get 
		{
			return _currentGameMode.ToString();
		}
	}

}
