using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk2D : MonoBehaviour
{

	/**The tiles in this chunk*/
	public Tile2D[,,] tileGrid = new Tile2D[0, 0, 0];
	/**The tile list that the gameobject's are loaded from*/
	public GameObject[] tileList = new GameObject[16];
	/**Is the player in this chunk*/
	public bool containsPlayer = false;
	/**Has this chunk generated yet*/
	public bool generated = false;
	/**The number of tiles (width & height) per chunk*/
	public int chunkSize = 8;
	/**The height of the current chunk*/
	public int chunkHeight = 2;

	// Use this for initialization
	void Start()
	{
		for(int x = 0; x < chunkSize; x++)
		{
			for(int y = 0; y < chunkSize; y++)
			{
				for(int z = 0; z < chunkHeight; z++)
				{
					setTile(0, new IntPosition(x,y,z));
				}
			}
		}
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
				///Create Tile\\\
				///


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

	/**Sets a tile at that positon*/
	public void setTile(int id, IntPosition pos)
	{
		if(tileGrid[pos.x, pos.y, pos.z] != null)
			Destroy(tileGrid[pos.x, pos.y, pos.z]);

		GameObject tileObj = Instantiate(tileList[id], this.transform);
		Tile2D tile = tileObj.GetComponent<Tile2D>();
		tile.tileID = id;
	}

	public Tile2D getTile(int id, IntPosition pos)
	{
		return tileGrid[pos.x, pos.y, pos.z];
	}
}