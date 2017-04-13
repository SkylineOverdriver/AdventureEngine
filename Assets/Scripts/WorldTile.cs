using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTile : MonoBehaviour {
	
	/**The tile that this tile is based off of*/
	public Tile tile;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	/**Returns the position of this tile*/
	public IntPosition getPosition()
	{
		return tile.position;
	}
}

[System.Serializable]
public class IntPosition
{
	/**The position on the x axis*/
	public int x;
	/**The position on the y axis*/
	public int y;
	/**The position on the z axis*/
	public int z;

	/**Initalizes the IntPosition class with no values*/
	public IntPosition()
	{
		x = 0;
		y = 0;
		z = 0;
	}

	/**Creates a new instance of the IntPosition class, with x, y, and z values*/
	public IntPosition(int xVal, int yVal, int zVal)
	{
		x = xVal;
		y = yVal;
		z = zVal;
	}

	/**Sets the position values on all axes*/
	public void setValues(int xVal, int yVal, int zVal)
	{
		x = xVal;
		y = yVal;
		z = zVal;
	}

	/**Sets the x value*/
	public void setX(int xVal)
	{
		x = xVal;
	}

	/**Sets the y value*/
	public void setY(int yVal)
	{
		y = yVal;
	}

	/**Sets the z value*/
	public void setZ(int zVal)
	{
		z = zVal;
	}

	/**Returns the x value*/
	public int getX()
	{
		return x;
	}

	/**Returns the y value*/
	public int getY()
	{
		return y;
	}

	/**Returns the z value*/
	public int getZ()
	{
		return z;
	}

	/**Adds two IntPositions togther*/
	public static IntPosition operator +(IntPosition posA, IntPosition posB)
	{
		return new IntPosition(posA.x + posB.x, posA.y + posB.y, posA.z + posB.z);
	}

	/**Subtracts an IntPosition from another one*/
	public static IntPosition operator -(IntPosition posA, IntPosition posB)
	{
		return new IntPosition(posA.x - posB.x, posA.y - posB.y, posA.z - posB.z);
	}

	//TODO: Explict & Implict operator converstions from and too Vector3
}

[System.Serializable]
public class IntPosition2D : IntPosition
{
	public IntPosition2D(int xVal, int zVal)
	{
		x = xVal;
		z = zVal;
	}
}

[System.Serializable]
public class Tile
{
	/**The initalization position of this tile*/
	public IntPosition position;
	/**The ID of this tile*/
	public int tileID = 0;
	/**How this tile is rendered*/
	public TileRenderer renderer;
	/**Should this tile render the north face*/
	public bool renderNorth;
	/**Should this tile render the south face*/
	public bool renderSouth;
	/**Should this tile render the east face*/
	public bool renderEast;
	/**Should this tile render the west face*/
	public bool renderWest;
	/**Should this tile render the top face*/
	public bool renderTop;
	/**Should this tile render the bottom face*/
	public bool renderBottom;

	public Tile()
	{
		
	}

	/**Sets which faces to render*/
	public void setFaceRender(bool n, bool s, bool e, bool w, bool t, bool b)
	{
		renderNorth = n;
		renderSouth = s;
		renderEast = e;
		renderWest = w;
		renderTop = t;
		renderBottom = b;
	}

	/**Returns if the game should render that face*/
	public bool getFaceRender(int face)
	{
		switch(face)
		{
		case 0:
			return renderNorth;
		case 1:
			return renderSouth;
		case 2:
			return renderEast;
		case 3:
			return renderWest;
		case 4:
			return renderTop;
		case 5:
			return renderBottom;
		default:
			return false;
		}
	}

	/**How this tile will be rendered*/
	public int getRenderMode()
	{
		return 0;
	}
}

[System.Serializable]
public class TileRenderer
{
	
}
