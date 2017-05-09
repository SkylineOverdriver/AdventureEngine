﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity2DLiving : Entity2D
{
	/**The north movement*/
	public Vector2 movementNorth = new Vector2(0.0f, 0.1f);
	/**The south movement*/
	public Vector2 movementSouth = new Vector2(0.0f, -0.1f);
	/**The east movement*/
	public Vector2 movementEast = new Vector2(0.1f, 0.0f); 
	/**The west movement*/
	public Vector2 movementWest = new Vector2(-0.1f, 0.0f);

	/**This entities health*/
	public EntityAttribute health = new EntityAttribute(0f, 100f, 100f);
	/**The entities strength*/
	public EntityAttribute strength = new EntityAttribute(0f, 20f, 1f);
	/**The entities agility*/
	public EntityAttribute agility = new EntityAttribute(0f, 20f, 1f);
	/**The entities charm (Social Skills)*/
	public EntityAttribute charm = new EntityAttribute(0f, 20f, 1f);
	/**The entities mana (Magical */
	public EntityAttribute mana = new EntityAttribute(0f, 20f, 20f);
	/**The entities knowlege (Wisdom & Intelect)*/
	public EntityAttribute knowlege = new EntityAttribute(0f, 20f, 1f);

	/**Is this living entity dead*/
	public bool isDead = false;

	/**The effects on this entity*/
	public List<EntityEffect> activeEffects;

	// Use this for initialization
	protected override void Start()
	{
		
	}
	
	// Update is called once per frame
	protected override void Update()
	{
		
	}

	/**Moves this entity in a direction with a certan number of units*/
	public override void Move(Vector2 direction)
	{
		if(canMove)
			base.Move(direction * agility.getValue());
	}

	public virtual void addHealth(float amount)
	{
		health.addValue(amount);
	}

	public virtual void removeHealth(float amount)
	{
		health.subtractValue(amount);
	}

	public virtual void die()
	{
		isDead = true;
		this.enabled = false;
		dropItems();
	}

	public virtual void dropItems()
	{
		//TODO: Put item dropping code here
	}
}

[System.Serializable]
public class EntityEffect
{
	
}