using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity2DNPC : Entity2DLiving
{
	// Use this for initialization
	protected override void Start()
	{
		base.Start();
	}
	
	// Update is called once per frame
	protected override void Update()
	{
		
	}
}


public class EntityAI
{
	/**Thie entities AI*/
	public List<EntityAITask> tasks;


}

public class EntityAITask
{
	
}
