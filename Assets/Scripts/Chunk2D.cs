using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk2D : MonoBehaviour{

	/**The tiles in this chunk*/
	public GameObject[,,] tileGrid = new GameObject[0,0,0]; 
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
		tileGrid = new GameObject[chunkSize,chunkSize,chunkHeight];
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
	public void setTile(Tile id, IntPosition2D pos)
	{
		
	}
}
