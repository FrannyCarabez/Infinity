using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	// the speed of the objects (used in ScrollChallenge())
	public float scrollSpeed = 5.0f;

	// an array that will hold our challenges (obstacles) so we can spawn random ones using GenerateRandomChallenge() 
	public GameObject[] challenges;

	public float frequency = 0.5f;

	float counter = 0.0f;

	public Transform challengesSpawnPoint;

	bool isGameOver = false;
	GameObject currentChild;
	// Use this for initialization
	void Start () {
		GenerateRandomChallenge();
	}
	
	// Update is called once per frame
	void Update () {

		if(isGameOver) return;

		//Generate Objects() 
		if (counter <= 0.0f)
		{
			// generate new object if counter is under or equal to 0
			GenerateRandomChallenge();
		}
		else{
			// the counter will start to decrease.
			counter -= Time.deltaTime * frequency;
		}
		
		//Scrolling
		
		for (int i = 0; i < transform.childCount; i++)
		{
			// the objects being generated will become the child of the challenge scroller and start to move
			currentChild = transform.GetChild(i).gameObject;
			ScrollChallenge(currentChild);

			// destroying the object when it goes out the screen
			if (currentChild.transform.position.x >= 15.0f)
			{
				Destroy(currentChild);
			}
		}
	}

	// to move the object towards the player
	void ScrollChallenge (GameObject currentChallenge){

		// the challanges (obstacles) will start to move towards the player
		currentChallenge.transform.position -= Vector3.back * (scrollSpeed * Time.deltaTime);

	}


	void GenerateRandomChallenge()
	{
		// newChallenge is the one that will start spawning, random ones from the array.
		GameObject newChallenge =  Instantiate (challenges[Random.Range(0, challenges.Length)], challengesSpawnPoint.position,Quaternion.identity) as GameObject;
		newChallenge.transform.parent = transform;
		
		// set counter 1 so it starts to go down to spawn another one after it goes under 0
		counter = 1.5f;
	}

	public void GameOver()
	{
		isGameOver = true;
		
	}
}
