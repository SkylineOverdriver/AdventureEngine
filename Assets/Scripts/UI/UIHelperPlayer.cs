using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHelperPlayer : MonoBehaviour
{
	/**The panel that shows up when the player interacts with an entity*/
	public GameObject interactObject;

	/**The class for the image that appears on the right side, when a character speaks to you*/
	public Image characterImage;

	/**The class for the character's name*/
	public Text characterNameText;

	/**The class for the text that appears on the bottom left when a character speaks to you*/
	public Text dialogueText;

	/**Updates the player's stats*/
	public Entity2DPlayer player;

	/**Display's the interaction UI*/
	public void displayInteraction(string description, Sprite interactIcon, string interactName)
	{
		
	}

	/**The image for player mana display*/
	public Image healthImage;
	/***/
	public Image manaImage;

	/***/
	public void UpdateStats()
	{
		
	}

	/**Displays an entity interaction*/
	public void displayDialogue(string text, Sprite icon, string name)
	{
		dialogueText.text = text;
		characterImage.sprite = icon;
		characterNameText.text = name;

	}

	void Start()
	{



	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
