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
		if(ai == null)
			ai = new EntityAI();
	}
	
	// Update is called once per frame
	protected override void Update()
	{
		if(ai.advance()) 
			validateAIAction(ai.getCurrentTask().taskType);
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
		case AITaskType.MOVEFORWARD:
			MoveForwardNoTransform(1);
			break;
		case AITaskType.TURNLEFT:
			RotateLocalNoTransform(1);
			break;
		case AITaskType.TURNRIGHT:
			RotateLocalNoTransform(-1);
			break;
		case AITaskType.ATTACK:
			attack();
			break;
		case AITaskType.PATROL:
			//TODO: Add patrol code
			break;
		case AITaskType.FOLLOW:
			//TODO: Add follow coden
			break;
		case AITaskType.MOVERANDOM:

			break;
		case AITaskType.TURNRANDOM:
			RotateLocalNoTransform((sbyte) Random.Range(-1, 2));
			break;
		default:
			Debug.LogWarning("AI Command " + task + " is unregistered. It could be an old command, if so, please update it!", this);
			//Log the error
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

	/**Removes a task from this entity's AI tasks*/
	public void removeTask(int taskID)
	{
		tasks.RemoveAt(taskID);
		if(currentTaskIndex > 0) 
			currentTaskIndex--;
	}

	/**Clears all AI tasks from the entity's index*/
	public void clearTasks()
	{
		tasks.Clear();
		currentTaskIndex = 0;
	}

	/**Adds a patrol point to this AI movement points*/
	public void addPatrolPoint(IntPosition position)
	{
		//TODO: Add patroling
	}

	/**Advenaces this entities AI to the next task*/
	public bool advance()
	{
		//Debug.Log("Time: " + Time.time + ", LastTask: " + lastTaskStartup + ", CurrentID: " + currentTaskIndex);

		//Check the timer and compare to make sure the wait time is over
		if(Time.time - lastTaskStartup >= tasks[currentTaskIndex].taskLength)
		{
			//Set the last task time to the current time
			lastTaskStartup = Time.time;

			//Run task code here

			currentTaskIndex++;

			//Check for task overflow
			if(currentTaskIndex >= tasks.Count)
				currentTaskIndex = 0;

			return true;
		}

		return false;
	}

	/**Gets the currently running AI task*/
	public EntityAITask getCurrentTask()
	{
		return tasks[currentTaskIndex];
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

	public virtual void runTask()
	{
		
	}


}

public enum AITaskType : byte
{
	WAIT = 0, //Default action
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

	TURNLEFT = 40,
	TURNRIGHT = 41,
	TURNBACK = 42,
	TURNRANDOM = 43,

	MOVEFORWARD = 50,
	MOVEBACKWARD = 51,
	MOVELEFT = 52,
	MOVERIGHT = 53,
	MOVERANDOM = 54,

	INTERACT = 70,
};
