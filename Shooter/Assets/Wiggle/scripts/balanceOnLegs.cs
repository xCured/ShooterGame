using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balanceOnLegs : MonoBehaviour {


	//Attach this script to the legs
	public bool isgrounded;

	public ConstantForce torso;

	void Start()
	{
		isgrounded = false;
	}

	void FixedUpdate()
	{
		if (isgrounded == true)
		{
			//Do your action Here...
			torso.enabled = true;
		}

		if (isgrounded == false)
		{
			//Do your action Here...
			torso.enabled = false;
		}
	}

	#region ground detection layer 1
	// if legs are on the "floor" (tag) toggle isgrounded bool which controls constant force component on the torso..
	//make sure u replace "floor" with your gameobject name on which player is standing
	void OnCollisionEnter(Collision theCollision)
	{
		if (theCollision.gameObject.tag == "floor")
		{
			isgrounded = true;
		}
	}

	//consider when character's legs are not on the floor.. it will exit collision.
	void OnCollisionExit(Collision theCollision)
	{
		if (theCollision.gameObject.tag == "floor")
		{
			isgrounded = false;
		}
	}
	#endregion
}
