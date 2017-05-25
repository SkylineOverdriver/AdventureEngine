using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity2DEnemy : Entity2DNPC
{
	//TODO: Finish this class

	protected override void Start()
	{
		base.Start();
		//Temporary code to make this entity wait forever
		//ai.addTask(new EntityAITask(AITaskType.WAIT, float.MaxValue));
	}
}
