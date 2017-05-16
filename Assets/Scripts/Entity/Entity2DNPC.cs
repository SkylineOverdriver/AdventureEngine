using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity2DNPC : Entity2DLiving
{
	/**The atrificial intelligence that this entity has*/
	public EntityAI ai;

	// Use this for initialization
	protected override void Start()
	{
		base.Start();
	}
	
	// Update is called once per frame
	protected override void Update()
	{
		
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		
	}
}

[System.Serializable]
public class EntityAI
{
	/**Thie entities AI*/
	public List<EntityAITask> tasks;

	/**Which task is this AI currently on*/
	public int currentTaskIndex = 0;

	/***/
	public void addTask(EntityAITask task)
	{
		tasks.Add(task);
	}

	/**Advenaces this entities AI to the next task*/
	public void advance()
	{


		currentTaskIndex++;
	}
}

[System.Serializable]
public class EntityAITask
{
	/**The task type, this defines what this entity will do*/
	public AITaskType taskType;

}

public enum AITaskType : byte
{
	WAIT = 0,
	MOVE = 1,
	TURN = 2,
	PATROL = 3,
	FOLLOW = 4,
	FLEE = 5,
	ATTACK = 6,
	DEFEND = 7,
	RANDOM = 8,
	ITEMUSELEFT = 9,
	ITEMUSERIGHT = 10,
};
