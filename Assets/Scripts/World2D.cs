using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World2D : MonoBehaviour {

	/**The tile list for all the tiles*/
	public GameObject[] tileList = new GameObject[16];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**Creates a tile*/
	public void createTile(string tileID)
	{
		
	}

	/**Gets a loaded Tile's gameobject*/
	public Tile getTile(string tileName)
	{
		return EngineControl.loadedRegistry.retriveTile("base", "test");
	}
}
