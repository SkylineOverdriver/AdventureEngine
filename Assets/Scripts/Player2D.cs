using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : Entity2D
{
	/**These variables control the movement keys. They are changeable*/
	public KeyCode keyNorth = KeyCode.W;
	public KeyCode keySouth = KeyCode.S;
	public KeyCode keyEast = KeyCode.D;
	public KeyCode keyWest = KeyCode.A;

	//Start is called when this monoBehaviour is enabled
	protected override void Start()
	{
		base.Start();
	}
	
	//Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(keyNorth))
		{
			Move(movementNorth);
		}
		else
		if(Input.GetKeyDown(keySouth))
		{
			Move(movementSouth);
		}
		else
		if(Input.GetKeyDown(keyEast))
		{
			Move(movementEast);
		}
		else
		if(Input.GetKeyDown(keyWest))
		{
			Move(movementWest);
		}
	}
}
