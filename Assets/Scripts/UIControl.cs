using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour {


	/**Generates a UI Screen*/
	public void generateUI(string baseUI)
	{
		switch(baseUI.ToLower())
		{
		case "pause":
			break;
		case "crafting":
			break;
		case "container":
			break;
		case "character_creation":
			break;
		case "inventory":
			break;
		case "crafting_synthesis":
			break;
		case "":
			break;
		default:
			return;
		}
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
