using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackLoader : MonoBehaviour {

	/**The current path of the loaded story pack*/
	public static string currentPackPath = "";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

[System.Serializable]
public class StoryPack
{
	//TODO: Do this after the base game has been coded, this will load assets into the game

	/**The registry for this pack*/
	public EngineRegistry registry = new EngineRegistry();

	/**The models in this story pack*/
	public GameModel models;

	
}

[System.Serializable]
public class ModelLoader
{
	
}

[System.Serializable]
public class SpriteLoader
{

}
	
[System.Serializable]
public class TileLoader
{
	
}

[System.Serializable]
public class ItemLoader
{
	
}

[System.Serializable]
public class ReciepeLoader
{
	
}

[System.Serializable]
public class EntityLoader
{
	
}

[System.Serializable]
public class WorldLoader
{
	
}

[System.Serializable]
public class SoundLoader
{
	
}

[System.Serializable]
public class CutsceneLoader
{
	
}

[System.Serializable]
public class CustomObjectLoader
{
	
}