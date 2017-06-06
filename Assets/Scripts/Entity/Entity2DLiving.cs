using System.Collections;
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

	/**The gender of the entity*/
	public EntityGender entityGender = 0;

	/**This entities health*/
	public EntityAttribute health = new EntityAttribute(0f, 100f, 100f);
	/**The entities strength*/
	public EntityAttribute strength = new EntityAttribute(0f, 25f, 1f);
	/**The entities agility*/
	public EntityAttribute agility = new EntityAttribute(0f, 25f, 1f);
	/**The entities charm (Social Skills)*/
	public EntityAttribute charm = new EntityAttribute(0f, 25f, 1f);
	/**The entities mana (Magical */
	public EntityAttribute mana = new EntityAttribute(0f, 20f, 20f);
	/**The entities knowlege (Wisdom & Intelect)*/
	public EntityAttribute knowlege = new EntityAttribute(0f, 25f, 1f);
	/**The entities defense*/
	public EntityAttribute defense = new EntityAttribute(0f, 25f, 1f);

	/**Is this living entity dead*/
	public bool isDead = false;

	/**The effects on this entity*/
	public List<EntityEffect> activeEffects;

	/**This entitie's inventory*/
	public InventoryEntityLiving entityInventory;

	// Use this for initialization
	protected override void Start()
	{
		entityInventory.setEntity(this);
	}
	
	// Update is called once per frame
	protected override void Update()
	{
		
	}

	/**Use's this entities currently held item*/
	public void useItem()
	{
		entityInventory.getHeldItem(0).itemUse(KeyCode.Mouse0);
	}

	/**Moves this entity in a direction with a certan number of units*/
	public override void Move(IntPosition location)
	{
		if(canMove)
			base.Move(location * agility.getValue());
	}

	/**Smothly moves this entity in the direction supplied, over time*/
	public override void MoveSmooth(IntPosition direction)
	{
		if(canMove)
			base.MoveSmooth(direction);
	}

	/**Heals the Entity*/
	public virtual void addHealth(float amount)
	{
		health.addValue(amount);
	}

	/**Hurts the Entity*/
	public virtual void removeHealth(float amount)
	{
		health.subtractValue(amount);
	}

	/**Give the entity mana*/
	public virtual void addMana(float amount)
	{
		mana.addValue(amount);
	}

	/**Removes mana from the entity*/
	public virtual void removeMana(float amount)
	{
		mana.subtractValue(amount);
	}

	/**Sets the entity's defense*/
	public virtual void setDefense(float amount)
	{
		defense.setValue(amount);
	}

	/**Sets the entity's agility*/
	public virtual void setAgility(float amount)
	{
		agility.setValue(amount);
		moveStep = moveStepBase - (amount / 2);
		if(moveStep < 1)
			moveStep = 1;
	}

	/**Called when this entity dies*/
	public override void die()
	{
		base.die();
		isDead = true;
		dropItems();
	}

	/**Called when this entity dies or drops it's items*/
	public virtual void dropItems()
	{
		//TODO: Put item dropping code here
		//World2D.CreateEntity(new Entit2dItem);
	}

	/**Called to make this entity interact with the entity in fron of it*/
	public virtual void interact()
	{
		if(World2D.theWorld.getTile(position + getDirection()).getEntity() != null)
			World2D.theWorld.getTile(position + getDirection()).getEntity().onInteracted(this);
	}

	/**Attacks the entity in front of this one*/
	public virtual void attack()
	{
		if(World2D.theWorld.getTile(position + getDirection()).getEntity() != null)
			World2D.theWorld.getTile(position + getDirection()).getEntity().onAttacked(this.getAttackDamage());
	}

	/**Called when this entity is attacked*/
	public override void onAttacked(float damageIn)
	{
		//Calculates how much danage this entity will get 
		float damageVal = damageIn - (defense.getValue() * 0.5f);
		this.hurt(damageVal > 0 ? damageVal : 1);
	}

	/**Returns this entitites attack*/
	public virtual float getAttackDamage()
	{
		return this.strength.getValue() + this.entityInventory.getHeldItem(0).damage.getValue();
	}

	/**Hurts this entity*/
	public virtual void hurt(float amount)
	{
		this.removeHealth(amount);

		if(this.health.getValue() <= health.min)
		{
			this.die();
		}
	}
	/**Called when this entity is interacted with*/
	public virtual void onInteract()
	{
		//World2D.theWorld.playerUIHelper.displayText("Testing", this.GetComponent<SpriteRenderer> ().sprite, this.entityName);
	}

	/**Updates all of this entities UI stats*/
	public virtual void updateEntityStatUI()
	{
		
	}
}
	
public enum EntityGender : byte
{
	NONE = 0,
	MALE = 1,
	FEMALE = 2,
	OTHER = 3,
	TRANS = 4,
};

[System.Serializable]
public class EntityEffect
{
	/**How many ticks untill this effect wears off*/
	public int effectTimer = 0;
	/**How much this effect is amplifiyed*/
	public int effectStrength = 0;

	/**Called whenever this effect is activated*/
	public void OnEffect(Entity2DLiving entity)
	{
		
	}
}