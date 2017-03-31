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
	/**The registry for this storypack*/
	public EngineRegistry storyRegistry;
	/**The storypack render mode*/
	public EngineRenderMode packRenderMode = EngineRenderMode.BUILTIN;
	/**The pack paly mode*/
	public EngineGamePlayMode packPlayMode;
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
public class StructureLoader
{
	//Structures are generated in worlds, they can be random or defined
}

[System.Serializable]
public class MaterialLoader
{

}

[System.Serializable]
public class CraftingLoader
{
	
}

[System.Serializable]
public class UILoader
{
	
}

[System.Serializable]
public class CustomObjectLoader
{
	
}