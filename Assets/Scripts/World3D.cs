using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World3D : MonoBehaviour {

	/**The tile list*/
	public WorldTile[] tileList = new WorldTile[32];

	/**The tile lookup list, used for loading tiles*/
	public static Dictionary<string, Tile> tileLookup = new Dictionary<string, Tile>();

	/**The chunk object to create*/
	public Chunk3D chunkPrefab;

	/**The world chunks currently loaded*/
	public Dictionary<IntPosition, Chunk> chunks = new Dictionary<IntPosition, Chunk>();

	/**Test for world generation*/
	public int worldSize = 1;

	// Use this for initialization
	void Start () 
	{
		//Generate();

		//regions.Add(new IntPosition(0, 0, 0), new WorldChunk()); 

		//TestGeneration();
		/*string packName = "base";
		EngineControl.loadedRegistry = new EngineRegistry();
		EngineControl.loadedRegistry.register(packName, "test", null);
		EngineControl.loadedRegistry.registerTile(packName, "testTile", new Tile());
		EngineControl.loadedRegistry.registerEntity(packName, "testEntity", null);
		EngineControl.loadedRegistry.registerItem(packName, "testItem", null);
		EngineControl.loadedRegistry.registerWorld(packName, "testWorld", null);
		EngineControl.loadedRegistry.registerSound(packName, "testSound", null);
		EngineControl.loadedRegistry.registerModel(packName, "testModel", null);
		EngineControl.loadedRegistry.registerSprite(packName, "testSprite", null);
		EngineControl.loadedRegistry.register(":tile:testTile", new Tile());

		int rcount = 0;

		foreach(string key in EngineControl.loadedRegistry.registry.Keys)
		{
			rcount++;
			Debug.Log("registryID@" + rcount + " - " + key);
		}

		Debug.Log(EngineControl.loadedRegistry.retriveTile("base", "testTile"));
		Debug.Log(EngineControl.loadedRegistry.retriveTile("", "testTile"));*/

		EngineControl.loadedRegistry = new EngineRegistry();
		//Registry Test right here
		EngineControl.loadedRegistry.register("base", "tile", "testGround", new Tile());
		Tile tileAddition = EngineControl.loadedRegistry.retriveTile("base", "testGround");

		for(int px = -5; px <= 5; px++)
		{
			for(int py = -5; py <= 5; py++)
			{
				GameObject tileInstance = Instantiate(EngineControl.genericObject, this.transform);
				tileInstance.AddComponent<WorldTile>().tile = tileAddition;
				tileInstance.transform.position = new Vector3(px, 0, py);
				tileInstance.name = "Tile " + px + " " + py;
				tileInstance.AddComponent<BoxCollider>();
				GameModel model = new GameModel(-4);
				model.setOffset(new Vector3(-0.5f, -0.5f, -0.5f));
				model.addQuad(4);
				tileInstance.AddComponent<MeshFilter>().mesh = model.ToMesh();
				tileInstance.AddComponent<MeshRenderer>();
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	/**This is a secondary test method for generation*/
	public void Generate()
	{
		for (int x = -worldSize; x <= worldSize; x++) 
		{
			for (int y = -worldSize; y <= worldSize; y++) 
			{
				for (int z = -worldSize; z <= worldSize; z++) 
				{
					Chunk chunk = new Chunk();
					chunks.Add(new IntPosition(x, y, z), chunk);
					GameObject chunkObj = (GameObject) Instantiate(chunkPrefab.gameObject, this.transform);
					chunkObj.transform.position = new Vector3(x,y,z);
					chunkObj.name = "Chunk (" + x + "," + y + "," + z + ")";
					Chunk3D chunkWorld = chunkObj.AddComponent<Chunk3D>();
					chunkWorld.chunk = chunk;
					//chunkWorld.Generate();
				}
			}	
		}
	}


	/**This method test's world generation, use it for any generation code that you want to test*/
	public void TestGeneration()
	{
		for(int x = 0; x < 10; x++)
		{
			for(int z = 0; z < 10; z++)
			{
				GameObject created = (GameObject) Instantiate(tileList[1].gameObject, new Vector3(x, 0, z), new Quaternion());
				created.transform.SetParent(this.transform);
				GameModel genModel = new GameModel(-4);
				genModel.setOffset(new Vector3(-0.5f, -0.5f, -0.5f));
				//genModel = this.generateModel("cube"); 
				genModel.addQuad(4);
				if(x == 0)
				{
					genModel.addQuad(2);
				}
				else if(x == 9)
				{
					genModel.addQuad(5);
				}

				if(z == 0)
				{
					genModel.addQuad(0);
				}
				else if(z == 9)
				{
					genModel.addQuad(3);
				}

				Mesh newMesh = new Mesh();
				newMesh.SetVertices(genModel.getVerticies());
				newMesh.SetTriangles(genModel.getTriangles(), 0);
				newMesh.SetUVs(0, genModel.uv0);
				newMesh.RecalculateNormals();
				created.GetComponent<MeshFilter>().mesh = newMesh;
			}
		}
	}

	[System.Obsolete("Model generation is now handled by the chunk class, this should not be used anymore")]
	/**Generates a new model with the specifiyed parameters*/
	public GameModel generateModel(string type)
	{
		GameModel model = new GameModel();
		switch(type)
		{
		case "cube":
			model.addQuad(0);
			model.addQuad(1);
			model.addQuad(2);
			model.addQuad(3);
			model.addQuad(4);
			model.addQuad(5);
			return model;
		//case "pyramid":
		//	model.addQuad(new Vector3[]{new Vector3()});
		//	return model;
		//case "":

		//	return model;
		case "wall":
			model.addQuad(0);
			model.addQuad(1);
			model.addQuad(2);
			model.addQuad(3);
			model.addQuad(5);
			Debug.Log("Wall model generation is incomplete, this should be a check.");
			return model;
		default:
			Debug.Log("Model Generation for \'" + type + "\' is not supported.");
			return model;
		}
	}

	/**Generates a wall model*/
	public GameModel generateModelWall(bool[] connectedSides)
	{
		GameModel model = new GameModel();

		//TODO: Add dungeon Wall support

		if(connectedSides[0])
		{
			
		}
		if(connectedSides[1])
		{

		}
		if(connectedSides[2])
		{

		}
		if(connectedSides[3])
		{

		}
		if(connectedSides[4])
		{

		}
		if(connectedSides[5])
		{

		}

		return model;
	}

	/**Registers a tile in the registry*/
	public static void addTileRegistry(string pack, string name, Tile tile)
	{
		tileLookup.Add(pack + ":tile:" + name, tile);
	}
}

[System.Serializable]
public class GameModel
{
	/**The verticies of this model*/
	public List<Vector3> verticies = new List<Vector3>();
	/**The triangle of this model*/
	public List<int> triangles = new List<int>();
	/**The vertex index*/ //TODO: Fix this, for some reason it needs to be negative four at first
	public int vertIndex = 0;
	/**Has the verticie index been used yet (if so get rid of the first initalzation, that one is wrong)*/
	public bool vertIndexInitalized = false;
	/**The uv 0 map*/
	public List<Vector2> uv0 = new List<Vector2>();
	/**The offset of this mesh's verticies*/
	public Vector3 vertexOffset = new Vector3();

	public GameModel()
	{
		
	}

	/**Initalizes a new model with this starting vertex*/
	public GameModel(int vertStart)
	{
		vertIndex = vertStart;
	}

	/**Adds a vertex to the triangles array*/
	public void addVertex(Vector3 vert)
	{
		verticies.Add(vert + vertexOffset);
		vertIndex++;
	}

	/**Adds a triangle to the triangles array*/
	public void addTriangle(int vert1, int vert2, int vert3)
	{
		triangles.Add(vert1 + vertIndex);
		triangles.Add(vert2 + vertIndex);
		triangles.Add(vert3 + vertIndex);
	}

	/**Adds a uv coordinate to the UV-0 Map*/
	public void addUV0(Vector2 uv)
	{
		uv0.Add(uv);
	}

	/**Sets the vertex offset of the mesh*/
	public void setOffset(Vector3 vertOffset)
	{
		vertexOffset = vertOffset;
	}

	/**Returns the vertex offset of the mesh*/
	public Vector3 getOffset()
	{
		return vertexOffset;
	}

	/**Sets the vertex index*/
	public void setVertIndex(int newIndex)
	{
		vertIndex = newIndex;
	}

	/**Returns the verticies in this mesh*/
	public List<Vector3> getVerticies()
	{
		return this.verticies;
	}

	/**Returns the triangles in this mesh*/
	public List<int> getTriangles()
	{
		return this.triangles;
	}

	/**Returns the UV-0 Map in this mesh*/
	public List<Vector2> getUV0()
	{
		return this.uv0;
	}

	/**Adds a quad to the mesh, uses a cube format with parameters: 
	//0 = +X
	//1 = +Y
	//2 = +Z
	//3 = -X
	//4 = -Y
	//5 = -Z
	//Uses automatic UV mapping (All the same  texture)
	*/
	public void addQuad(int side)
	{
		switch(side)
		{
		case 0:
			this.addVertex(new Vector3(0, 0, 0));
			this.addVertex(new Vector3(1, 0, 0));
			this.addVertex(new Vector3(1, 1, 0));
			this.addVertex(new Vector3(0, 1, 0));
			break;
		case 1:
			this.addVertex(new Vector3(0, 0, 0));
			this.addVertex(new Vector3(0, 0, 1));
			this.addVertex(new Vector3(1, 0, 1));
			this.addVertex(new Vector3(1, 0, 0));
			break;
		case 2:
			this.addVertex(new Vector3(0, 0, 0));
			this.addVertex(new Vector3(0, 1, 0));
			this.addVertex(new Vector3(0, 1, 1));
			this.addVertex(new Vector3(0, 0, 1));
			break;
		case 3:
			this.addVertex(new Vector3(1, 0, 1));
			this.addVertex(new Vector3(0, 0, 1));
			this.addVertex(new Vector3(0, 1, 1));
			this.addVertex(new Vector3(1, 1, 1));
			break;
		case 4:
			this.addVertex(new Vector3(1, 1, 1));
			this.addVertex(new Vector3(0, 1, 1));
			this.addVertex(new Vector3(0, 1, 0));
			this.addVertex(new Vector3(1, 1, 0));
			break;
		case 5:
			this.addVertex(new Vector3(1, 1, 0));
			this.addVertex(new Vector3(1, 0, 0));
			this.addVertex(new Vector3(1, 0, 1));
			this.addVertex(new Vector3(1, 1, 1));
			break;
		default:
			Debug.Log("Cubes cannot have sides at direction " + side + ".");
			return;
		}

		this.addUV0(new Vector2(0, 0));
		this.addUV0(new Vector2(1, 0));
		this.addUV0(new Vector2(1, 1));
		this.addUV0(new Vector2(0, 1));

		this.addTriangle(2, 1, 0);
		this.addTriangle(0, 3, 2);
	}

	/**Add a quad to the mesh facing away from the camera*/
	public void addQuad(Vector3[] points)
	{
		this.addVertex(points[0]);
		this.addVertex(points[1]);
		this.addVertex(points[2]);
		this.addVertex(points[3]);

		this.addTriangle(2, 1, 0);
		this.addTriangle(0, 3, 2);
	}

	/**Add a polygon to the mesh facing away from the camera*/
	public void addPoly(Vector3[] points, int[] triangles)
	{
		for(int i = 0; i < points.Length; i++)
		{
			this.addVertex(points[i]);
		}

		for(int i = 0; i < points.Length; i+=3)
		{
			this.addTriangle(triangles[i], triangles[i + 1], triangles[i + 2]);
		}
	}

	/**Add a polygon to the mesh facing away from the camera, uses UV-0 Mapping*/
	public void addPoly(Vector3[] points, int[] triangles, Vector2[] uv0)
	{
		addPoly(points, triangles);

		for(int i = 0; i < uv0.Length; i+=3)
		{
			this.addUV0(uv0[i]);
		}
	}

	/**Returns this model object as a mesh*/
	public Mesh ToMesh()
	{
		Mesh newMesh = new Mesh();
		newMesh.SetVertices(verticies);
		newMesh.SetTriangles(triangles, 0);
		newMesh.SetUVs(0, uv0);
		newMesh.RecalculateNormals();
		newMesh.RecalculateBounds();
		return newMesh;
	}
}

[System.Serializable]
public class Chunk
{
	/**The tiles in this chunk*/
	public Tile[,,] tiles = new Tile[16,16,16];
	/**The position of this chunk*/
	public IntPosition position = new IntPosition();

	/**Initialize a new Chunk*/
	public Chunk(){}

	/**Initialize a new chunk at that position*/
	public Chunk(IntPosition pos)
	{
		this.position = pos;
	}

	/**Initialize a new chunk at that position (With Integers)*/
	public Chunk(int x, int y, int z)
	{
		this.position = new IntPosition(x,y,z);
	}

	/**Initialize a new chunk with a specific world generator*/
	public Chunk(IntPosition pos, WorldGenerator generator)
	{
		
	}
}

[System.Serializable]
public class WorldGenerator
{
	
}
