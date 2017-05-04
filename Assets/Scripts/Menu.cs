using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour 
{
	/**TODO
	-MAKE MENU WORK
	-MAKE VOLUME BUTTON SLASH THRU ON CLICK
	-ADD A BACKGROUND
	*/


	public bool isMainMenu;
	public bool isOptionsMenu;
	public Canvas mainCanvas;
	public Canvas optionsCanvas;


	void Awake()
	{
		optionsCanvas.enabled = false;
	}


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
