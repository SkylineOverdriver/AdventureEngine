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