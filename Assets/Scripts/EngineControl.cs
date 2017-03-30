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
	/**A generic object to instantiate other objects onto*/
	public static GameObject genericObject;

	// Use this for initialization
	void Start () 
	{
		genericObject = Instantiate(new GameObject(), this.transform);
		genericObject.name = "Game Object";
	}
	
	// Update is called once per frame
	void Update () 
	{
		
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

	/**The game registry, (For tiles)*/
	//public Dictionary<string, Tile> tileRegistry = new Dictionary<string, Tile>();
	/**The game registry, (For items)*/
	//public Dictionary<string, Item> itemRegistry = new Dictionary<string, Item>();
	/**The game registry, (For Worlds) (Broken)*/
	//public Dictionary<string, World> worldRegistry = new Dictionary<string, World>();
	/**The game registry, (For ENtities) (Broken)*/
	//public Dictionary<string, Entity> entityRegistry = new Dictionary<string, Entity>();

	/**Registers an object from a pack*/
	public void register(string pack, string name, object obj)
	{
		registry.Add(pack + ":" + name, obj);
	}

	/**Registers an object with a direct location*/
	public void register(string location, object obj)
	{
		registry.Add(location, obj);
	}

	/**Registers an object with a type, and a name from a pack*/
	public void register(string pack, string type, string name, object obj)
	{
		registry.Add(pack + ":" + type + ":" + name, obj);
	}

	//TODO: Add registry code that's missing
	/**Registers a tile from a pack*/
	public void registerTile(string pack, string name, Tile obj) 
	{
		registry.Add(pack + ":tile:" + name, obj);
	}

	/**Registers an item from a pack*/
	public void registerItem(string pack, string name, Item obj) 
	{
		registry.Add(pack + ":item:" + name, obj);
	}

	/**Registers an entity from a pack*/
	public void registerEntity(string pack, string name, object obj) 
	{
		registry.Add(pack + ":entity:" + name, obj);
	}

	/**Registers a world from a pack*/
	public void registerWorld(string pack, string name, object obj) 
	{
		registry.Add(pack + ":gameWorld:" + name, obj);
	}

	/**Registers a sound from a pack*/
	public void registerSound(string pack, string name, object obj) 
	{
		registry.Add(pack + ":sound:" + name, obj);
	}

	/**Registers a structure from a pack*/
	public void registerStructure(string pack, string name, object obj) 
	{
		registry.Add(pack + ":structure:" + name, obj);
	}

	/**Registers a model from a pack*/
	public void registerModel(string pack, string name, object obj) 
	{
		registry.Add(pack + ":model:" + name, obj);
	}

	/**Registers a sprite from a pack*/
	public void registerSprite(string pack, string name, object obj) 
	{
		registry.Add(pack + ":sprite:" + name, obj);
	}

	/**Retrives a value from the registry, if there is none, then null is returned*/
	public object retrive(string name)
	{
		object retrivedObject = null;
		registry.TryGetValue(name, out retrivedObject);
		return retrivedObject;
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

	/**Retrives a loaded tile*/
	public Tile retriveTile(string pack, string name)
	{
		return (Tile) retrive(pack + ":tile:" + name);
	}

	/**Retrives a loaded item*/
	public Item retriveItem(string pack, string name)
	{
		return (Item) retrive(pack + ":item:" + name);
	}

	/**Retrives a loaded entity*/
	public object retriveEntity(string pack, string name)
	{
		//TODO: Implement the entity revtival system
		return (object) retrive(pack + ":entity:" + name);
	}

	/**Retrives a loaded world*/
	public object retriveWorld(string pack, string name)
	{
		//TODO: Implement the world revtival system
		return (object) retrive(pack + ":gameWorld:" + name);
	}

	/**Retrives a loaded structure*/
	public object retriveStructure(string pack, string name)
	{
		//TODO: Implement the structure revtival system
		return (object) retrive(pack + ":structure:" + name);
	}
		
	/**Retrives a loaded sound*/
	public object retriveSound(string pack, string name)
	{
		//TODO: Implement the structure revtival system
		return (object) retrive(pack + ":sound:" + name);
	}

	/**Retrives a loaded model*/
	public object retriveModel(string pack, string name)
	{
		//TODO: Implement the model revtival system
		return (object) retrive(pack + ":model:" + name);
	}

	/**Retrives a loaded sprite*/
	public object retriveSprite(string pack, string name)
	{
		//TODO: Implement the sprite revtival system
		return (object) retrive(pack + ":sprite:" + name);
	}
}