using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2D : MonoBehaviour
{
	// Use this for initialization
	public virtual void Start()
	{
		
	}
	
	// Update is called once per frame
	public virtual void Update()
	{
		
	}

	/**The amount of damage this item does*/
	public EntityAttribute damage = new EntityAttribute(0).setTrueInfiniteCaps();

	/**The amount of defense this item gives*/
	public EntityAttribute defense = new EntityAttribute(0).setTrueInfiniteCaps();

	/**The maximum number of uses this item has*/
	public EntityAttribute uses = new EntityAttribute(0).setTrueInfiniteCaps();

	/**The entity modifiyerss this item has*/
	public List<AttributeModifiyer> modifiyers = new List<AttributeModifiyer>();

	/**Called whenever this item has started being used*/
	public virtual void itemUseStart(KeyCode useButton) {}
		
	/**Called whenever this item is being used*/
	public virtual void itemUse(KeyCode useButtonn) {}

	/**Called whenever this item has finished being used*/
	public virtual void itemUseEnd(KeyCode useButton) {}

	/**Called whenever this item is crafted*/
	public virtual void itemCrafted() {}

	/**Called whenever the player hovers over this item in the inventory*/
	public virtual void itemMouseOver() {}

	/**Called whenever this item is selected in game*/
	public virtual void itemSelected() {}

	/**Called when this item has it's info added*/
	public virtual void addItemInfo() {}

	/**Called when this item is updated (TODO: Move this to it's own class)*/
	public virtual void itemUpdate() {}

	/**Adds a modifiyer to the entities modifiyer list*/
	public void addModifiyer(AttributeModifiyer modifiyer)
	{
		modifiyers.Add(modifiyer);
	}

	/**Removes a modifiyer from the modifiyer list*/
	public void removeModifiyer(int index)
	{
		modifiyers.RemoveAt(index);
	}
}

public enum DamageType : byte
{
	NONE = 0,		//No damage is done from the item this is on
	SLICING = 1,		//Slicing Damage
	PIERCING = 2,		//Piercing Damage
	BLUDGEONING = 3,	//Bludgeoning Damage
	MAGIC = 4,		//Magic Damage
	EXPLOSIVE = 5,		//Explosive Damage
	THERMAL = 6,		//Thermal Damage
	RADIATION = 7,		//Radiation Damage
	CHEMICAL = 8,		//Chemical Damage
	VIRAL = 9,		//Viral Damage
	PSYCHOLOGICAL = 126,	//Psychological Damage (Used on some magic spells)
	EMOTONIAL = 127,	//Emotional Damage (Used only on some magic spells)
}

public interface IItemUse
{
	/**Called when this item has started being used*/
	void OnItemUseStart();

	/**Called when this item is being used*/
	void OnItemUse();

	/**Called when this item has ended being used*/
	void OnItemUseEnd();
}

public interface IItemUpdates
{
	/**Called when this item is updated*/
	void OnItemUpdate();
}

public interface IItemDamage
{
	/**Called when this item is damaged*/
	void OnItemDamaged();

	/**Called when this item breaks*/
	void OnItemBreak();
}

[System.Serializable]
public class AttributeModifiyer
{
	//TODO: Add attribute modiifiyers
	/**The name of the modifiyed attribute*/
	public string attributeName = "";
	/**The amound that this attribute modifies*/
	public float attributeValue = 0.0f;
	/**The type of modifiyer that this is*/
	public AttributeModType modifiyerType;

	public AttributeModifiyer()
	{
		
	}

	public AttributeModifiyer(string name, float value, AttributeModType type)
	{
		attributeName = name;
		attributeValue = value;
		modifiyerType = type;
	}
}

public enum AttributeModType : byte
{
	ADD = 0,
	PERCENT_ADD = 1,
	PERCENT_MULTIPLY = 2,
	SET = 3,
}