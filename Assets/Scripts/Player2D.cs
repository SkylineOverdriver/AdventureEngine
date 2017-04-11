using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player2D : Entity2D {

	/** Use this for initialization */


	/**These variables control the movement keys. They are changeable*/
	public KeyCode keyNorth = KeyCode.W;
	public KeyCode keySouth = KeyCode.S;
	public KeyCode keyEast = KeyCode.D;
	public KeyCode keyWest = KeyCode.A;

	protected override void Start () 
	{
		base.Start ();
	}
	
	/** Update is called once per frame */
	void Update() 
	{
		if (Input.GetKeyDown (keyNorth)) 
		{
			Move (movementNorth);
		} 
		else if (Input.GetKeyDown (keySouth)) 
		{
			Move (movementSouth);
		} 
		else if (Input.GetKeyDown (keyWest)) 
		{
			Move (movementWest);
		} 
		else if (Input.GetKeyDown (keyEast)) 
		{
			Move (movementEast);
		}
	}
	/**This subroutine is called for when the user is changing the UI control button*/
	public void changeKey(string direction)
	{
		if (direction == "North")
		{
			Input.GetKeyDown = keyNorth;
		}
		else if (direction == "South")
		{
			Input.GetKeyDown = keySouth;
		}
		else if (direction == "East")
		{
			Input.GetKeyDown = keyEast;
		}
		else if (direction == "West")
		{
			Input.GetKeyDown = keyWest;
		}
		else
		{
			print ("Change Key Direction Error");
		}
	}
}
