using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity2DPlayer : Entity2DLiving
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
	protected override void Update()
	{
		if(Input.GetKey(keyNorth))
		{
			Move(movementNorth);
		}

		if(Input.GetKey(keySouth))
		{
			Move(movementSouth);
		}

		if(Input.GetKey(keyEast))
		{
			Move(movementEast);
		}

		if(Input.GetKey(keyWest))
		{
			Move(movementWest);
		}
	}
}
