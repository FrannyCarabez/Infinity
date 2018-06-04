using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	#region variables
	public float speed;
	public bool onGround;
	private Rigidbody rb;

	float posX = 6.63f;
	float posY = 0f;

	bool isGameOver = false;

	private int count;
	public Text countText;
	Spawner mySpawner;

	private CountDown Script; 

	public string tagObjectGood;
	public string tagObjectBad;
	
	#endregion


	#region methods

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		Script = GetComponent<CountDown>();
		//tagObjectGood = "Good";
		//tagObjectBad = "Bad";
		onGround = true;
		rb = GetComponent<Rigidbody>();
		posX = transform.position.x;
		mySpawner = GameObject.FindObjectOfType<Spawner>();

		count=0;
		SetCountText();
	}

	 /// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if(onGround)
		{
			if(Input.GetButtonDown("Jump") && !isGameOver)
			{
				rb.velocity = new Vector3(0f, 8f, 0f);
				onGround = false;
			}

		}

		
		
	}

	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate()
	{
		// creating a variable (getting the horizontal movement)
		float moveHorizontal = Input.GetAxis ("Horizontal");

		// creating another variable that has moving coordinates .
        Vector3 movement = new Vector3 ( 0.0f, 0.0f,moveHorizontal);

        rb.AddForce (movement * speed);

		//Hit face check
		if (transform.position.x > posX)
		{
			GameOver();
		}

		if (transform.position.y < posY)
		{
			GameOver();
		}
	}

	// a function for when the player hits an obstacles
	void GameOver()
	{
		Debug.Log("GameOver");
		isGameOver = true;
		mySpawner.GameOver();
		SceneManager.LoadScene (2);
	}

	void OnCollisionEnter(Collision other) 
	{
		if(other.gameObject.CompareTag ("Ground"))
		{
			onGround = true;
		}
	}

	

	void OnTriggerEnter(Collider other)
	{	
		
		Items item = other.GetComponent<Items>();
		if (item.gameMode == GameManager.currentGameMode)
		{
			count++;
		}
		else
		{
			count--;
		}

		Destroy (other.gameObject);
		SetCountText();
	}

	void SetCountText(){
		countText.text = "Score:" + count.ToString();
	}

	#endregion
	//Script.currentGameMode == GameMode.Procrastinate
}
