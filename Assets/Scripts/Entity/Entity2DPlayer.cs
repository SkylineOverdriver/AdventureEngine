using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity2DPlayer : Entity2DLiving
{
	/**The north movement keycode*/
	public KeyCode keyNorth = KeyCode.W;
	/**The south movement keycode*/
	public KeyCode keySouth = KeyCode.S;
	/**The east movement keycode*/
	public KeyCode keyEast = KeyCode.D;
	/**The west movement keycode*/
	public KeyCode keyWest = KeyCode.A;
	/**The keycode that makes the player move quickly*/
	public KeyCode keyQuickMove = KeyCode.LeftShift;
	/**The keycpde that makes the player rotate instead of move*/
	public KeyCode keyRotate = KeyCode.LeftControl;
	/**The keycode that the pplayer presses to interact with the entity at that direction*/
	public KeyCode keyInteract = KeyCode.E;
	/**The keycode that the player presses to attack an entity in that direction*/
	public KeyCode keyAttack = KeyCode.Z;

	/**The class of this player (Integer, 0 - 15, 0 = PAGE, 1 = PRINCE, 2 = BARD, 3 = SUMMONER, 4 = KING,
	 5 = MAID, 6 = SYLPH, 7 = WITCH, 8 = MARTYR, 9 = QUEEN, 10 = HEIR, 11 = MAGE, 12 = KNIGHT, 13 = ROUGE
	 14 = SAGE, 15 = HOST)*/
	public PlayerClass playerClass = 0; 

	/**The aspect of this player (Integer, 0 - 10, 0 = TIME, 1 = SPACE, 2 = LIGHT, 3 = VOID, 4 = LIFE, 5 = DOOM
	 6 = BREATH, 7 = BLOOD, 8 = RAGE, 9 = SOUL, 10 = MIND)*/
	public PlayerAspect playerAspect = 0;

	//Start is called when this monoBehaviour is enabled
	protected override void Start()
	{
		base.Start();
	}
	
	//Update is called once per frame
	protected override void Update()
	{
		if((Input.GetKey(keyQuickMove) && Input.GetKey(keyNorth)) || Input.GetKeyDown(keyNorth))
		{
			RotateNoTransform(ObjectDirection.NORTH);
			MoveSmooth(movementNorth);
		}

		if((Input.GetKey(keyQuickMove) && Input.GetKey(keySouth)) || Input.GetKeyDown(keySouth))
		{
			RotateNoTransform(ObjectDirection.SOUTH);
			MoveSmooth(movementSouth);
		}

		if((Input.GetKey(keyQuickMove) && Input.GetKey(keyEast)) || Input.GetKeyDown(keyEast))
		{
			RotateNoTransform(ObjectDirection.EAST);
			MoveSmooth(movementEast);
		}

		if((Input.GetKey(keyQuickMove) && Input.GetKey(keyWest)) || Input.GetKeyDown(keyWest))
		{
			RotateNoTransform(ObjectDirection.WEST);
			MoveSmooth(movementWest);
		}

		if(Input.GetKey(keyInteract))
		{
			interact();
		}

		if(Input.GetKeyDown(keyAttack))
		{
			attack();
		}
	}
}

[System.Serializable]
public enum PlayerClass : byte
{

	/* MALE */

	PAGE = 0,
	//Weak in the beginning, stronger later on in game. Risk reward system
	//if they manage to become powerful, they become REALLY powerful.
	PRINCE = 1,
	// Active Destruction class which is powerful throughout the game.  Sort
	//of like a tank, decent at diplomacy.
	BARD = 2,
	//Great at smooth talking though relatively weak in combat.
	SUMMONER = 3,
	//Can summon a guardian of their aspect, they themselves are not strong
	KING = 4,
	//Very powerful class
	//!!! Only obtainalbe by evolving from an Heir

	/* FEMALE */

	MAID = 5,
	//Creation class, weak early strong later on
	SYLPH = 6,
	//healing class, support player
	WITCH = 7,
	//Magic class, powerful but potentially destructive
	MARTYR = 8,
	//One who suffers for their aspect.  A trade off of suffering and power.
	QUEEN = 9,
	//Very powerful class
	//!!! Only obtainalbe by evolving from an Heir

	/* NEUTRAL*/

	HEIR = 10,
	//Possessing class, best with their aspect given. Usually powerful aspect abilities.
	//!!! WILL EVOLVE INTO A KING OR QUEEN LATER ON IN THE GAME
	MAGE = 11,
	//Magic user, tends to have an excess amount of the aspect they represent and it causes
	//debuffs/disadvantages
	KNIGHT = 12,
	//Also good with their aspect.  However other team members will struggle with the aspect the Knight has.
	ROUGE = 13,
	//Sneak class that tends to be powerful if successful in sneak and other endeavours.
	SAGE = 14,
	//One who can control others through their aspect
	HOST = 15,
	//One who can be possessed by their aspect

	//The character that has specaliatiy in all weapons
	ULTIMATE = 16,
};

[System.Serializable]
public enum PlayerAspect : byte
{
	TIME = 0,
	//Ability to control time and endings
	SPACE = 1,
	//Ability of creation and laws of physics etc...
	LIGHT = 2,
	//Luck, Knowledge (acting as a SpotLIGHT) and literal light
	VOID = 3,
	//Mystery, the unknown, deception
	LIFE = 4,
	//Living things/Healing
	DOOM = 5,
	//Death and destruction
	BREATH = 6,
	//freedom/wind/air
	BLOOD = 7,
	//Flesh/blood/responsibility
	RAGE = 8,
	//Anger, fear, stubbornness
	SOUL = 9,
	//Personality, ideals morals, literal souls
	MIND = 10,
	//Logic, the brain, mind readers
};