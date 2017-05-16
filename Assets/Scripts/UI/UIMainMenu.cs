using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour 
{
	/**TODO
	-MAKE MENU WORK
	-MAKE VOLUME BUTTON SLASH THRU ON CLICK
	-ADD A BACKGROUND
	*/

	/*
		TODO:
		|==========================================================|
		 Please put meaningful comments on any variabled or methods
		|==========================================================|
	*/

	public bool isMainMenu;

	public bool isOptionsMenu;

	public Canvas mainCanvas;

	public Canvas optionsCanvas;


	void Awake()
	{
		//TODO: This canvas can be disabled on start in the editor instead of in code...
		optionsCanvas.enabled = false;
	}

	//This is good, but could be made into a better method
	public void optionsOn()
	{
		optionsCanvas.enabled = true;
		mainCanvas.enabled = false;
	}

	public void menuOn()
	{
		optionsCanvas.enabled = false;
		mainCanvas.enabled = true;
	}

	public void loadOn()
	{
		SceneManager.LoadScene(1);
	}

	/**Loads a scene when activated*/
	public void loadScene(string name)
	{
		SceneManager.UnloadSceneAsync("Menu");
		SceneManager.LoadScene(name);
	}
}
