using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity2D : MonoBehaviour {

	/**The east movement*/
	public Vector2 movementEast;
	/**The west movement*/
	public Vector2 movementWest;
	/**The north movement*/
	public Vector2 movementNorth;
	/**The south movement*/
	public Vector2 movementSouth;

	/**Can this entity move*/
	public bool canMove = true;

	/**This entities health*/
	public EntityAttribute health = new EntityAttribute(0f, 100f, 100f);
	/**The entities strength*/
	public EntityAttribute strength = new EntityAttribute(Mathf.NegativeInfinity, Mathf.Infinity, 0f);

	/**The hostility of this entity (Now an integer, 0 - 4, 0 = NONE, 1 = PEACFUL, 2 = NEUTRAL, 3 = HOSTILE, 4 = ALLIED)*/
	public int hostility = 0;

	// Use this for initialization
	protected virtual void Start () 
	{


	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Move(Vector2 direction)
	{
		transform.Translate (direction);
	}
}

[System.Serializable]
public class EntityAttribute
{
	/**The minimum value of this attribute*/
	public float min;
	/**The maximum value of this attribute*/
	public float max;
	/**The value of this attribute*/
	public float value;

	/**A empty constructor, sets everything to zero*/
	public EntityAttribute()
	{
		min = 0f;
		max = 0f;
		value = 0f;
	}

	/**Creates a new instance of the EntityAttribute class*/
	public EntityAttribute(float minValue, float maxValue, float startValue)
	{
		min = minValue;
		max = maxValue;
		value = startValue;
	}

	/**Creates a new EntityAttribute with infinity min and max values*/
	public EntityAttribute(float startvalue)
	{
		min = Mathf.NegativeInfinity;
		max = Mathf.Infinity;
		value = startvalue;
	}

	/**Gets the value of this attribute*/
	public float getValue()
	{
		return value;
	}

	/**Sets the value of this attribute*/
	public void setValue(float newValue)
	{
		value = newValue;
	}

	/**Adds a value to this attribute*/
	public void addValue(float amount)
	{
		value += amount;

		if(value > max)
		{
			value = max;
		}
	}

	/**Subtracts a value from the attribute*/
	public void subtractValue(float amount)
	{
		value -=amount;

		if(value < min)
		{
			value = min;
		}
	}
}

public class EntityIntAttribute : EntityAttribute
{
	
}

public enum EntityHostility
{
	/**None is entities that dont have AI*/
	NONE,
	/**Peaceful entites will never attack you. If you attack them, they will run away*/
	PEACFUL,
	/**Neutral entities will not attack you unless you attack them first or somehow provoke them*/
	NEUTRAL,
	/**Hostile Entities will attack you on sight. They will keep on attacking you until death*/
	HOSTILE,
	/**Allied npc's will follow you around and attack npc's/players/bosses that attack you*/
	ALLIED,
};