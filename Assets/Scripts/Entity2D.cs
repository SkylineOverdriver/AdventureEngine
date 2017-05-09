using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity2D : MonoBehaviour
{
	/**Can this entity move*/
	public bool canMove = true;

	/**The hostility of this entity (Now an integer, 0 - 4, 0 = NONE, 1 = PEACFUL, 2 = NEUTRAL, 3 = HOSTILE, 4 = ALLIED)*/
	public int hostility = 0;

	public string entityName = "noName";
	// Use this for initialization
	protected virtual void Start()
	{
		
	}
	
	// Update is called once per frame
	protected virtual void Update()
	{

	}

	/**Teleorts this entity*/
	public void Teleport(IntPosition destination)
	{
		transform.position = destination;
	}

	/**Moves this entity in the direction supplied*/
	public virtual void Move(Vector2 direction)
	{
		transform.Translate(direction);
	}

	/**Smothly moves this entity in the direction supplied, over time*/
	public virtual void MoveSmooth(Vector2 direction, int frames)
	{
		
	}

	/**Called when this entity interacts with another entity*/
	public virtual void OnInteract(Entity2D reciver)
	{
		
	}

	/**Called when this entity is interacted with*/
	public virtual void OnInteracted(Entity2D sender)
	{
		
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
	/**Should integers be used instead of floats*/
	public bool useIntegers = false;

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
		min = float.MinValue;//Mathf.NegativeInfinity;
		max = float.MaxValue;//Mathf.Infinity;
		value = startvalue;
	}

	/**Makes this attriutes min and max true infinity*/
	public EntityAttribute setTrueInfiniteCaps()
	{
		min = Mathf.NegativeInfinity;
		max = Mathf.Infinity;
		return this;
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
		value -= amount;

		if(value < min)
		{
			value = min;
		}
	}

	public override string ToString()
	{
		if(min == float.MinValue && max == float.MaxValue)
			return value.ToString();
		else if(min == 0)
			return value + "/" + max;
		else
			return "(" + min + ", " + value + ", " + max + ")";
		
	}
}

[System.Serializable]
public class EntityIntAttribute : EntityAttribute
{
	/**The minimum value of this attribute*/
	public int min;
	/**The maximum value of this attribute*/
	public int max;
	/**The value of this attribute*/
	public int value;

	/**A empty constructor, sets everything to zero*/
	public EntityIntAttribute()
	{
		min = 0;
		max = 0;
		value = 0;
	}

	/**Creates a new instance of the EntityAttribute class*/
	public EntityIntAttribute(int minValue, int maxValue, int startValue) : base(minValue, maxValue, startValue)
	{
		min = minValue;
		max = maxValue;
		value = startValue;
	}

	/**Creates a new EntityAttribute with infinity min and max values*/
	public EntityIntAttribute(int startvalue)
	{
		min = int.MinValue;//Mathf.NegativeInfinity;
		max = int.MaxValue;//Mathf.Infinity;
		value = startvalue;
	}
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

[System.Serializable]
public class EntityPosition
{
	/**The x position*/
	public float x;
	/**The y position*/
	public float y;
	/**The z position*/
	public int z;

	public EntityPosition()
	{
		x = 0f;
		y = 0f;
		z = 0;
	}

	public EntityPosition(float xPos, float yPos, int layer)
	{
		x = xPos;
		y = yPos;
		z = layer;
	}

	public EntityPosition(Vector3 position)
	{
		x = position.x;
		y = position.y;
		z = (int) position.z;
	}
}