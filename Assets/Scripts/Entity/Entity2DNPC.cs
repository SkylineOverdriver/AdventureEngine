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
		ai = new EntityAI();
	}
	
	// Update is called once per frame
	protected override void Update()
	{
		ai.advance();
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		//TODO: Add Entity interaction
	}

	/**Do the AI action for the task type*/
	public void validateAIAction(AITaskType task)
	{
		switch(task)
		{
		case AITaskType.WAIT:
			//Do  nothing, this is a wait command
			break;
		case AITaskType.MOVE:

			break;
		case AITaskType.TURN:

			break;
		case AITaskType.PATROL:

			break;
		case AITaskType.FOLLOW:

			break;
		default:
			
		break;
		}
	}
}

[System.Serializable]
public class EntityAI
{
	/**Thie entities AI*/
	public List<EntityAITask> tasks = new List<EntityAITask>();

	/**Which task is this AI currently on*/
	public int currentTaskIndex = 0;

	/**The value when the AI last started a task*/
	public float lastTaskStartup = 0f;

	/**Adds a taks to this AI's tasks*/
	public void addTask(EntityAITask task)
	{
		tasks.Add(task);
	}

	/**Adds a patrol point to this AI movement points*/
	public void addPatrolPoint(IntPosition position)
	{
		//TODO: Add patroling
	}

	/**Advenaces this entities AI to the next task*/
	public void advance()
	{
		//Check the timer and compare to make sure the wait time is over
		if(Time.time - lastTaskStartup >= tasks[currentTaskIndex].taskLength)
		{
			//Set the last task time to the current time
			lastTaskStartup = Time.time;

			//Run task code here

			currentTaskIndex++;
		}

		if(currentTaskIndex >= tasks.Count)
			currentTaskIndex = 0;
	}
}

[System.Serializable]
public class EntityAITask
{
	/**The task type, this defines what this entity will do*/
	public AITaskType taskType;
	/**How long this task will last for (In seconds)*/
	public float taskLength = 0;
	/**Has the condition for this task been met*/
	public bool taskCondition = true;

	public EntityAITask(AITaskType task)
	{
		taskType = task;
	}

	public EntityAITask(AITaskType task, float time)
	{
		taskType = task;
		taskLength = time;
	}

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
