using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2DConsumable : Item2D
{
	/**How long does the player have to wait to use this item again after it has been used*/
	public int cooldownTime = 0;

	// Use this for initialization
	public override void Start()
	{
		
	}
	
	// Update is called once per frame
	public override void Update()
	{
		
	}

	public override void itemUse(KeyCode useButton)
	{
		base.itemUse(useButton);
	}
}