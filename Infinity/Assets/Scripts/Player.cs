using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed;

	#region variables
	public bool onGround;
	private Rigidbody rb;
	#endregion


	#region methods

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		onGround = true;
		rb = GetComponent<Rigidbody>();
	}

	 /// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if(onGround)
		{
			if(Input.GetButtonDown("Jump"))
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
		float moveHorizontal = Input.GetAxis ("Horizontal");

        Vector3 movement = new Vector3 ( 0.0f, 0.0f,moveHorizontal);

        rb.AddForce (movement * speed);
	}

	void OnCollisionEnter(Collision other) 
	{
		if(other.gameObject.CompareTag ("Ground"))
		{
			onGround = true;
		}
	}

	#endregion

}
