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
	public EntityAttribute strength = new EntityAttribute(0f, Mathf.Infinity, 0f);

	/**The hostility of this entity (Now an integer, 0 - 3, 0 = NONE, 1 = PEACFUL, 2 = NEUTRAL, 3 = HOSTILE)*/
	public int hostility = 0;

	// Use this for initialization
	void Start () 
	{
			

	}
	
	// Update is called once per frame
	void Update () {
		
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


	public EntityAttribute()
	{
		min = 0f;
		max = 0f;
		value = 0f;
	}

	public EntityAttribute(float minValue, float maxValue, float startValue)
	{
		min = minValue;
		max = maxValue;
		value = startValue;
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
	NONE,
	PEACFUL,
	NEUTRAL,
	HOSTILE,
};