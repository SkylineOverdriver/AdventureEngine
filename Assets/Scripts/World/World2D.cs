using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World2D : MonoBehaviour 
{
	/**The tile list for all the tiles*/
	public GameObject[] tileList = new GameObject[16];
	/**The entity list for all the entitities*/
	public GameObject[] entityList = new GameObject[8];
	/**The item list for all the items*/
	public GameObject[] itemList = new GameObject[16];

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
		//TODO: move day/night cycle code to here
	}

	/**Creates a tile*/
	public void createTile(string tileID)
	{
		
	}

	/**Creates an entity in the world*/
	public void createEntity(Entity2D entity, IntPosition position)
	{
		Instantiate(entity);
		//TODO: Add code for entity creation
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
			GameObject tile = Instantiate(this.tileList[5], position, new Quaternion());
			Destroy(tile, 2);
			return tile.GetComponent<Tile2D>();
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

	/**Returns an entity from its name*/
	public Entity2D getEntityIDFromName(string entityName)
	{
		foreach(GameObject go in entityList)
		{
			if(go.GetComponent<Entity2D>().name == entityName)
				return go.GetComponent<Entity2D>();
		}

		return null;	
	}

	/**Returns an entity from its name*/
	public Item2D getItemIDFromName(string itemName)
	{
		foreach(GameObject go in itemList)
		{
			if(go.GetComponent<Item2D>().name == itemName)
				return go.GetComponent<Item2D>();
		}

		return null;	
	}

	/**Creates a dropped item from its existing item*/
	public Entity2DItem createDroppedItem(Item2D item)
	{
		//TODO: Add code here
		throw new System.NotImplementedException("CreateDropppedItem is not finished!");
		return null;//Instantiate(entityList[3]);
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

	/**Sets the position of an entity in the world*/
	public void setEntityAt(Entity2D entity, IntPosition tilePos)
	{
		getTile(tilePos).setEntity(entity);
	}

	/**Returns the entity at the specifiyed position*/
	public Entity2D getEntityAt(IntPosition tilePos)
	{
		return getTile(tilePos).getEntity();
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

	/**Adds an IntPosition to a Vector3*/
	public static Vector3 operator +(Vector3 vecA, IntPosition posA)
	{
		return new Vector3(posA.x + posA.x, posA.y + posA.y, posA.z + posA.z);
	}

	/**Adds an IntPosition to a Vector2*/
	public static Vector2 operator +(Vector2 vecA, IntPosition posA)
	{
		return new Vector2(vecA.x + posA.x, posA.y + posA.y);
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

	/**Shotthand for (0,0,0)*/
	public static IntPosition zero = new IntPosition(0,0,0);
	/**Shotthand for (1,0,0)*/
	public static IntPosition east = new IntPosition(1,0,0);
	/**Shotthand for (0,1,0)*/
	public static IntPosition north = new IntPosition(0,1,0);
	/**Shotthand for (-1,0,0)*/
	public static IntPosition west = new IntPosition(-1,0,0);
	/**Shotthand for (0,-1,0)*/
	public static IntPosition south = new IntPosition(0,-1,0);
	/**Shotthand for (1,1,0)*/
	public static IntPosition northEast = new IntPosition(1,1,0);
	/**Shotthand for (-1,1,0)*/
	public static IntPosition northWest = new IntPosition(-1,1,0);
	/**Shotthand for (-1,-1,0)*/
	public static IntPosition southWest = new IntPosition(-1,-1,0);
	/**Shotthand for (1,-1,0)*/
	public static IntPosition southEast = new IntPosition(1,-1,0);
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
	NONE = 127,
};

public enum ObjectDirectionRotation : sbyte
{
	//Relative directions
	RIGHT = 1,
	LEFT = -1,
	NONE = 0,
};
