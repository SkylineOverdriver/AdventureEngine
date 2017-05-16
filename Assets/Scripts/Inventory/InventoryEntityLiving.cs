using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryEntityLiving : Inventory
{
	/**This entities equipment slots*/
	public List<InventorySlot> equipmentSlots = new List<InventorySlot>();

	/**The item held by this entity*/
	public List<InventorySlot> heldSlots = new List<InventorySlot>();

	public void getModifiyers()
	{
		
	}

	/**Return's the player's currently selected item*/
	public Item2D getItem()
	{
		return heldSlots[0].item;
	}
}
