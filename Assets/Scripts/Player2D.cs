using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : Entity2D {

	// Use this for initialization
	protected override void Start () 
	{
		base.Start ();
	}
	
	// Update is called once per frame
	void Update() 
	{
		if (Input.GetKeyDown (KeyCode.W)) 
		{
			Move (movementNorth);
		} 
		else if (Input.GetKeyDown (KeyCode.S)) 
		{
			Move (movementSouth);
		} 
		else if (Input.GetKeyDown (KeyCode.A)) 
		{
			Move (movementWest);
		} 
		else if (Input.GetKeyDown (KeyCode.D)) 
		{
			Move (movementEast);
		}
	}

}
