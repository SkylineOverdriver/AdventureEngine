using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity2DPlayer : Entity2DLiving
{
	/**These variables control the movement keys. They are changeable*/
	public KeyCode keyNorth = KeyCode.W;
	public KeyCode keySouth = KeyCode.S;
	public KeyCode keyEast = KeyCode.D;
	public KeyCode keyWest = KeyCode.A;

	/**The gender of the player (Integer, 0 - 1, 0 = Male, 1 = Female)*/
	public int playerGender = 0;

	/**The class of this player (Integer, 0 - 15, 0 = PAGE, 1 = PRINCE, 2 = BARD, 3 = SUMMONER, 4 = KING,
	 5 = MAID, 6 = SYLPH, 7 = WITCH, 8 = MARTYR, 9 = QUEEN, 10 = HEIR, 11 = MAGE, 12 = KNIGHT, 13 = ROUGE
	 14 = SAGE, 15 = HOST)*/
	public int plrClass = 0; 

	/**The aspect of this player (Integer, 0 - 10, 0 = TIME, 1 = SPACE, 2 = LIGHT, 3 = VOID, 4 = LIFE, 5 = DOOM
	 6 = BREATH, 7 = BLOOD, 8 = RAGE, 9 = SOUL, 10 = MIND)*/
	public int plrAspect = 0;

	//Start is called when this monoBehaviour is enabled
	protected override void Start()
	{
		base.Start();
	}
	
	//Update is called once per frame
	protected override void Update()
	{
		if(Input.GetKey(keyNorth))
		{
			Move(movementNorth);
		}

		if(Input.GetKey(keySouth))
		{
			Move(movementSouth);
		}

		if(Input.GetKey(keyEast))
		{
			Move(movementEast);
		}

		if(Input.GetKey(keyWest))
		{
			Move(movementWest);
		}
	}

	[System.Serializable]

	public enum playerClass
	{

		/** MALE */

		PAGE,
		//Weak in the beginning, stronger later on in game. Risk reward system
		//if they manage to become powerful, they become REALLY powerful.
		PRINCE,
		// Active Destruction class which is powerful throughout the game.  Sort
		//of like a tank, decent at diplomacy.
		BARD,
		//Great at smooth talking though relatively weak in combat.
		SUMMONER,
		//Can summon a guardian of their aspect, they themselves are not strong
		KING,
		//Very powerful class
		//!!! Only obtainalbe by evolving from an Heir

		/** FEMALE */

		MAID,
		//Creation class, weak early strong later on
		SYLPH,
		//healing class, support player
		WITCH,
		//Magic class, powerful but potentially destructive
		MARTYR,
		//One who suffers for their aspect.  A trade off of suffering and power.
		QUEEN,
		//Very powerful class
		//!!! Only obtainalbe by evolving from an Heir

		/**NEUTRAL*/

		HEIR,
		//Possessing class, best with their aspect given. Usually powerful aspect abilities.
		//!!! WILL EVOLVE INTO A KING OR QUEEN LATER ON IN THE GAME
		MAGE,
		//Magic user, tends to have an excess amount of the aspect they represent and it causes
		//debuffs/disadvantages
		KNIGHT,
		//Also good with their aspect.  However other team members will struggle with aspect Knight has.
		ROUGE,
		//Sneak class that tends to be powerful if successful in sneak and other endeavours.
		SAGE,
		//One who can control others through their aspect
		HOST,
		//One who can be possessed by their aspect
	};

	public enum playerAspect
	{
		TIME,
		//Ability to control time and endings
		SPACE,
		//Ability of creation and laws of physics etc...
		LIGHT,
		//Luck, Knowledge (acting as a SpotLIGHT) and literal light
		VOID,
		//Mystery, the unknown, deception
		LIFE,
		//Living things/Healing
		DOOM,
		//Death and destruction
		BREATH,
		//freedom/wind/air
		BLOOD,
		//Flesh/blood/responsibility
		RAGE,
		//Anger, fear, stubbornness
		SOUL,
		//Personality, ideals morals, literal souls
		MIND,
		//Logic, the brain, mind readers
	};
}