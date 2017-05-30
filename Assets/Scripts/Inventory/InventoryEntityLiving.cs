using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryEntityLiving : Inventory
{
	/**This entities equipment slots*/
	public List<InventorySlot> equipmentSlots = new List<InventorySlot>();

	/**The item held by this entity*/
	public List<InventorySlot> heldSlots = new List<InventorySlot>();

	/**The entity that has this inventory on it*/
	public Entity2DLiving attachedEntity;

	public void getModifiyers()
	{
		
	}

	/**Return's the player's currently selected item*/
	public Item2D getHeldItem(int slotID)
	{
		return heldSlots[slotID].item;
	}

	/**Returns the player's currently held item*/
	public Item2D getEquipItem(int slotID)
	{
		return equipmentSlots[slotID].item;
	}

	/**Returns the attached entity on this inventory*/
	public Entity2DLiving getEntity()
	{
		return attachedEntity;
	}
}
