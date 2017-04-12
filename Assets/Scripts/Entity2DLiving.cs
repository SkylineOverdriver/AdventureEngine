using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity2DLiving : Entity2D
{

	/**This entities health*/
	public EntityAttribute health = new EntityAttribute(0f, 100f, 100f);
	/**The entities strength*/
	public EntityAttribute strength = new EntityAttribute(0f);
	/**The entities agility*/
	public EntityAttribute agility = new EntityAttribute(0f);
	/**The entities charm (Social Skills)*/
	public EntityAttribute charm = new EntityAttribute(0f);
	/**The entities mana (Magical */
	public EntityAttribute mana = new EntityAttribute(0f, 20f, 20f);
	/**The entities knowlege (Wisdom & Intelect)*/
	public EntityAttribute knowlege = new EntityAttribute(0f);



	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
