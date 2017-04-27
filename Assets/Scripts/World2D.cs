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

	/**The currently loaded world*/
	public static World2D theWorld;

	/**The current player in the world*/
	public Entity2DPlayer thePlayer;

	// Use this for initialization
	void Awake() 
	{
		theWorld = this;
		thePlayer = GameObject.Find("Player").GetComponent<Entity2DPlayer>();
	}

	void Start()
	{
		createChunk(new IntPosition(0,0,0));
	}
	
	// Update is called once per frame
	//void Update () 
	//{
		
	//}

	/**Creates a tile*/
	public void createTile(string tileID)
	{
		
	}

	/**Get's the currently loaded world*/
	public World2D getWorld()
	{
		return theWorld;
	}

	/**Returns a loaded tile*/
	public Tile2D getTile(IntPosition position)
	{
		Chunk2D chunk;
		loadedChunks.TryGetValue(getTileChunkPos(position), out chunk);
		return chunk.getTile(getTileLocalPos(position));
	}

	/**Returns the chunk position of the input tile*/
	public IntPosition getTileChunkPos(IntPosition globalPosition)
	{
		IntPosition chunkPosition = new IntPosition();

		chunkPosition.x = Mathf.FloorToInt((float) globalPosition.x / Chunk2D.chunkSize);
		chunkPosition.y = Mathf.FloorToInt((float) globalPosition.y / Chunk2D.chunkSize);
		chunkPosition.z = Mathf.FloorToInt((float) globalPosition.z / Chunk2D.chunkSize);

		return chunkPosition;
	}

	/**Returns the local position of the input tile*/
	public IntPosition getTileLocalPos(IntPosition globalPosition)
	{
		IntPosition localPosition = new IntPosition();
		IntPosition chunkPosition = new IntPosition();

		chunkPosition = getTileChunkPos(globalPosition);

		localPosition.x = globalPosition.x - (chunkPosition.x * Chunk2D.chunkSize);
		localPosition.y = globalPosition.y - (chunkPosition.y * Chunk2D.chunkSize);
		localPosition.z = globalPosition.z - (chunkPosition.z * Chunk2D.chunkSize);

		return localPosition;
	}

	/**Returns a tile from its name*/
	public Tile2D getTileIDFromName(string tileName)
	{
		foreach(GameObject go in tileList)
		{
			if(go.GetComponent<Tile2D>().name == tileName)
				return go.GetComponent<Tile2D>();
		}

		return null;
	}

	/**Gets a loaded Tile's gameobject*/
	public Tile2D getTileFromName(string tileName)
	{
		return EngineControl.loadedRegistry.retriveTile("base", "test");
	}

	/**Creates a new chunk at this position (Times the chunk size)*/
	public void createChunk(IntPosition position)
	{
		Chunk2D chunk = Instantiate(chunkObject, this.transform).GetComponent<Chunk2D>();
		chunk.chunkPos = position;
		loadedChunks.Add(position, chunk);
	}
}
