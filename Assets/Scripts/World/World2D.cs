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

	/**The ui helper to update the up for the player*/
	public UIHelperPlayer playerUIHelper;

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
	void Update () 
	{
		//TODO: Timer code here
	}

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
		Chunk2D chunk = null;
		loadedChunks.TryGetValue(getTileChunkPos(position), out chunk);
		if(chunk != null)
		{
			return chunk.getTile(getTileLocalPos(position));
		}
		else
		{
			//Debug.Log("Chunk Not Found @ " + getTileChunkPos(position));
			//Debug.Log("Chunk Exists: " + loadedChunks.ContainsKey(getTileChunkPos(position)));
			//listChunks();
			return null;
		}

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

	//NOTE, THIS IS A DEBUG
	/**Lists all the existing chunks*/
	public void listChunks()
	{
		foreach(Chunk2D c in loadedChunks.Values)
		{
			Debug.Log("Chunk @ " + c.chunkPos);
		}
	}

	/**Creates the entity*/
	public void CreateEntity(Entity2D entity)
	{
		//TODO: Put entity creation code here
		//Instantiate();
	}
}

[System.Serializable]
public class IntPosition : System.IEquatable<IntPosition>
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

	/**Creates a new instance of the IntPosition class, with x and y values, and a z value of 0*/
	public IntPosition(int xVal, int yVal)
	{
		x = xVal;
		y = yVal;
		z = 0;
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

	/**Converts an IntPositon into a Vector3*/
	public static implicit operator Vector3(IntPosition posA)
	{
		return new Vector3(posA.x, posA.y, posA.z);
	}

	/**Converts a Vector3 to an IntPosition*/
	public static implicit operator IntPosition(Vector3 vecA)
	{
		return new IntPosition(Mathf.RoundToInt(vecA.x), Mathf.RoundToInt(vecA.y), Mathf.RoundToInt(vecA.z));
	}

	/**Converts an IntPositon into a Vector2*/
	public static implicit operator Vector2(IntPosition posA)
	{
		return new Vector2(posA.x, posA.y);
	}

	/**Converts a Vector2 to an IntPosition*/
	public static implicit operator IntPosition(Vector2 vecA)
	{
		return new IntPosition(Mathf.RoundToInt(vecA.x), Mathf.RoundToInt(vecA.y));
	}

	/**Adds a Vector3 to an IntPosition*/
	public static IntPosition operator +(IntPosition posA, Vector3 vecA)
	{
		return new IntPosition(Mathf.RoundToInt(posA.x + vecA.x), Mathf.RoundToInt(posA.y + vecA.y), Mathf.RoundToInt(posA.z + vecA.z));
	}

	/**Adds a Vector2 to an IntPosition*/
	public static IntPosition operator +(IntPosition posA, Vector2 vecA)
	{
		return new IntPosition(Mathf.RoundToInt(posA.x + vecA.x), Mathf.RoundToInt(posA.y + vecA.y), posA.z);
	}

	/**Multiplies an IntPosition by a float*/
	public static  IntPosition operator *(IntPosition posA, float floA)
	{
		return new IntPosition(Mathf.RoundToInt(posA.x * floA), Mathf.RoundToInt(posA.y * floA), Mathf.RoundToInt(posA.z * floA));
	}

	/**Divides an IntPosition by a float*/
	public static IntPosition operator /(IntPosition posA, float floA)
	{
		return new IntPosition(Mathf.RoundToInt(posA.x / floA), Mathf.RoundToInt(posA.y / floA), Mathf.RoundToInt(posA.z / floA));
	}

	public override int GetHashCode()
	{
		//return base.GetHashCode();
		return x & y & z;
	}

	public bool Equals(IntPosition obj)
	{
		return x == obj.x && y == obj.y && z == obj.z;
	}

	public override string ToString()
	{
		return string.Format("(" + x + "," + y + "," + z + ")");
	}
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
public class WorldTime
{
	
}

/**A directional enum for object's to face*/
public enum ObjectDirection : sbyte
{
	//Absolute Directions
	EAST = 0,
	NORTH = 1,
	WEST = 2,
	SOUTH = 3,
	NORTH_EAST = 4,
	NORTH_WEST = 5,
	SOUTH_WEST = 6,
	SOUTH_EAST = 7,
	//Used for no rotation parameters
	NONE = -128,
};

public enum ObjectDirectionRotation : sbyte
{
	//Relative directions
	RIGHT = 1,
	LEFT = -1,
	NONE = 0,
};
