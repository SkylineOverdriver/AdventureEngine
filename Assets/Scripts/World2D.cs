using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World2D : MonoBehaviour 
{
	/**The tile list for all the tiles*/
	public GameObject[] tileList = new GameObject[16];

	/**The chunks that are loaded in the world*/
	public Dictionary<IntPosition, Chunk2D> loadedChunks = new Dictionary<IntPosition, Chunk2D>();
	/**The chunk gameobject, this is used to instantiate new chunks*/
	public GameObject chunkObject;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	/**Creates a tile*/
	public void createTile(string tileID)
	{
		
	}

	/**Returns a loaded tile*/
	public Tile getTile(IntPosition position)
	{
		return null;
	}

	/**Gets a loaded Tile's gameobject*/
	public Tile getTileFromName(string tileName)
	{
		return EngineControl.loadedRegistry.retriveTile("base", "test");
	}

	/**Creates a new chunk at this position (Times the chunk size)*/
	public void createChunk(IntPosition position)
	{
		Chunk2D chunk = Instantiate(chunkObject, this.transform).GetComponent<Chunk2D>();
		loadedChunks.Add(position, chunk);
	}
}
