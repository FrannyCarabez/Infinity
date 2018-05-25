using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

	void onCollisionEnter(Collision collision) 
	{
		Destroy (collision.gameObject);
	}

}
