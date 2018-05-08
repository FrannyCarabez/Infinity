using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

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

	void OnCollisionEnter(Collision other) 
	{
		if(other.gameObject.CompareTag ("Ground"))
		{
			onGround = true;
		}
	}

	#endregion

}
