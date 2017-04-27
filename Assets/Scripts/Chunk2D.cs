using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk2D : MonoBehaviour
{
	/**The tiles in this chunk*/
	public Tile2D[,,] tileGrid = new Tile2D[0, 0, 0];
	/**Is the player in this chunk*/
	public bool containsPlayer = false;
	/**Has this chunk generated yet*/
	public bool generated = false;
	/**The number of tiles (width & height) per chunk*/
	public static int chunkSize = 8;
	/**The height of the current chunk*/
	public int chunkHeight = 2;
	/**The position of this chunk*/
	public IntPosition chunkPos = new IntPosition();
	/**Can entities move on non-integral increments on this chunk*/
	public bool allowAbsoluteMovement = false;

	// Use this for initialization
	void Awake()
	{
		//Set the chunk size according to the set values
		tileGrid = new Tile2D[chunkSize, chunkSize, chunkHeight];
		//Generate this chunk
		Generate();
	}

	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	/**Generates the part of the world*/
	public void Generate()
	{
		//TODO: Generates the world at the position

		for(int x = 0; x < chunkSize; x++)
		{
			for(int y = 0; y < chunkSize; y++)
			{
				/*for(int z = 0; z < chunkHeight; z++)
				{
					setTile(1, new IntPosition(x,y,z));
				}*/

				setTile(1, new IntPosition(x,y,0));
				setTile(0, new IntPosition(x,y,1));
			}	
		}
	}

	//When any gameobject enters the trigger
	public void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			containsPlayer = true;
		}
	}

	//When any gameobject exits the trigger8
	public void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			containsPlayer = false;
		}
	}

	/**Sets a tile at a position to another tile*/
	public void setTile(int id, IntPosition pos)
	{
		if(tileGrid[pos.x, pos.y, pos.z] != null)
			Destroy(tileGrid[pos.x, pos.y, pos.z]);

		GameObject tileObj = Instantiate(World2D.theWorld.tileList[id], this.transform);
		tileObj.transform.position = (Vector3) pos + transform.position;
		Tile2D tile = tileObj.GetComponent<Tile2D>();
		tile.tileID = id;
		tile.tilePosition = pos;
	}

	/**Returns a tile at that position*/
	public Tile2D getTile(IntPosition pos)
	{
		return tileGrid[pos.x, pos.y, pos.z];
	}

	/**Returns the globall position of the input tile*/
	public IntPosition getTileGlobalPos(IntPosition localPosition)
	{
		IntPosition globalPosition = new IntPosition();
		globalPosition.x = (globalPosition.x * Chunk2D.chunkSize) + localPosition.x;
		globalPosition.y = (globalPosition.y * Chunk2D.chunkSize) + localPosition.y;
		globalPosition.z = (globalPosition.z * Chunk2D.chunkSize) + localPosition.z;
		return null;
	}

	/**Gets this object's hash code*/
	public override int GetHashCode()
	{
		return chunkPos.x & chunkPos.y & chunkPos.z;
		//return base.GetHashCode();
	}
}