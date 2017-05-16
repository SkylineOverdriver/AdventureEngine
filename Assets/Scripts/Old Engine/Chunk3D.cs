using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk3D : MonoBehaviour
{
	/**The internal chunk that is this one*/
	public Chunk chunk;
	/**The tile to generate*/
	public GameObject tile;
	/**Is the player in this chunk*/
	public bool containsPlayer = false;
	/**Has this chunk generated yet*/
	public bool generated = false;
	/**The mesh renderer on this chunk*/
	public MeshRenderer renderer;

	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		if(!generated)
		{
			Generate();
			generated = true;
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

	/**Generates this chunk at it's position*/
	public void Generate()
	{
		for(int x = 0; x < chunk.tiles.GetLength(0); x++)
		{
			for(int y = 0; y < chunk.tiles.GetLength(1); y++)
			{
				for(int z = 0; z < chunk.tiles.GetLength(2); z++)
				{
					GameObject tileObj = (GameObject) Instantiate(tile, this.transform);
					tileObj.transform.position = new Vector3(x, y, z);
					tileObj.name = "Tile (" + x + "," + y + "," + z + ")";
				}
			}
		}
	}

	public void generateMesh()
	{
		
	}
}
