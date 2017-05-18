using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile2D : MonoBehaviour
{
	/**The ID of this tile*/
	public int tileID = 0;
	/**The position of this tile*/
	public IntPosition tilePosition = new IntPosition();

	/**Is an entity on this tile*/
	public bool hasEntity = false;
	/**The entity on this tile (null if no entity)*/
	public Entity2D entity = null;

	/**Can entities move through this tile (solid?)*/
	public bool solidAll = true;
	/**Is none of this tile solid*/
	public bool solidNone = false;
	/**The solidity of the tile*/
	public int solidity = 0x0000 & 0x0001 & 0x0002 & 0x0004;

	//Checked if solidAll is false
	/**Is the north side of this tile solid*/
	public bool solidNorth = true;
	/**Is the south side of this tile solid*/
	public bool solidSouth = true;
	/**Is the east side of this tile solid*/
	public bool solidEast = true;
	/**Is the west side of this tile solid*/
	public bool solidWest = true;

	/**Is this tile a floor tile (Renders one layer down)*/
	public bool isFloor = false;

	/**Can this tile hurt enemies or players*/
	public bool hurtEntities = false;

	/**Is this tile made up of multiple tiles*/
	public bool multiTile = false;
	/**Does this tile have extra data to define it (Can it do more than a normal tile can?)*/
	public bool hasData = false;
	/**The extra data on this tile*/
	//public TileData2D data = null;

	// Use this for initialization
	public virtual void Start()
	{
		
	}
	
	// Update is called once per frame
	public virtual void Update()
	{
		
	}

	/**Returns if this tile is movable*/
	public void getMovability(ObjectDirection direction)
	{
		 
	}

	/**Get's a direction from a vector2*/
	public void getDirectionFromVector2()
	{
			
	}
}

[System.Serializable]
public class TileData2D
{
	/**The stored data (That is this tile's data)*/
	public Dictionary<string, object> storedData = new Dictionary<string, object>();

	/**Sets a key in the data map*/
	public void setKey(string name, object value)
	{
		if(!storedData.ContainsKey(name))
			storedData.Add(name, value);
		else
			storedData[name] = value;
	}

	/**Returns a key from the data map*/
	public object getKey(string name)
	{
		object returnVal;
		storedData.TryGetValue(name, out returnVal);
		return returnVal;
	}

	/**Adds an integer to the data map*/
	public void setInteger(string name, int value)
	{
		if(!storedData.ContainsKey(name))
			storedData.Add(name, value);
		else
			storedData[name] = value;
	}

	/**Tries to get an integer from the data map*/
	public int getInteger(string name)
	{
		object returnVal;
		storedData.TryGetValue(name, out returnVal);
		return (int) returnVal;
	}
}