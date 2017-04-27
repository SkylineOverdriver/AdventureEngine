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
