using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineControl : MonoBehaviour {

	/**The current version of the engine (For StoryPack loading)*/
	public static int version = 0;

	//first - public released versions
	//second - any major changes
	//third - any minor changes
	//fourth - any build changes
	/**The build id of this current game*/
	public static string build = "0.0.0.0";

	/**The currently registry*/
	public static EngineRegistry loadedRegistry;
	/**The currently loaded StoryPack*/
	public static StoryPack loadedPack;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public enum EngbliineRenderMode
{
	BUILTIN,
	OPENGL,
};

public enum EngineGamePlayMode
{
	MODE_2D,
	MODE_2D_TOPDOWN,
	MODE_2D_ISOMETRIC,
	MODE_3D,
};

[System.Serializable]
public class EngineRegistry
{
	/**The engine object registery*/
	public Dictionary<string, object> registry = new Dictionary<string, object>();

	/**Registers an object from a pack*/
	public void register(string pack, string name, object obj)
	{
		registry.Add(pack + ":" + name, obj);
	}

	/**Retrives a value from the registry, if there is none, then null is returned*/
	public object retrive(string pack, string name)
	{
		object retrivedObject = null;
		registry.TryGetValue(pack + ":" + name, out retrivedObject);
		return retrivedObject;
	}

	/**Loads this registry into the game*/
	public void loadRegistry()
	{
		
	}
}