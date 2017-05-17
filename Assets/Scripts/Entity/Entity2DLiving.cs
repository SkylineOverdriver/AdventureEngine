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
		
	}
	
	// Update is called once per frame
	protected override void Update()
	{
		
	}

	/**Use's this entities currently held item*/
	public void useItem()
	{
		entityInventory.getItem().itemUse(KeyCode.Mouse0);
	}

	/**Moves this entity in a direction with a certan number of units*/
	public override void Move(Vector2 direction)
	{
		if(canMove)
			base.Move(direction * agility.getValue());
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

	/**Called when this entity dies*/
	public virtual void die()
	{
		isDead = true;
		this.enabled = false;
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
		
	}

	/**Called when this entity is interacted with*/
	public virtual void onInteract()
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