using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	/**The inventory slots in this inventory*/
	public List<InventorySlot> inventorySlots = new List<InventorySlot>();

	/**Adds a slot's amount of items to this invetory*/
	public void addSlotItem(InventorySlot slot)
	{
		inventorySlots.Add(slot);
	}

	/**Add's an item to this inventory*/
	public void addItem(Item2D item, int amount)
	{
		item.setInentory(this);
		inventorySlots.Add(new InventorySlot(item, amount));
	}

	/**Removes a certan amount of an item from the inventory*/
	public void removeItem(Item2D item, int amount)
	{
		for(int i = 0; i < inventorySlots.Count; i++)
		{
			if(inventorySlots[i].item == item)
			{
				inventorySlots[i].amount -= amount;
			}
		}
	}

	/**Gets rid of an item from this inventort, by slotID*/
	public void removeItem(int slotID)
	{
		inventorySlots[slotID].item.removeInventory();
		inventorySlots.RemoveAt(slotID);
	}

	// Use this for initialization
	public virtual void Start()
	{
		
	}
	
	// Update is called once per frame
	public virtual void Update()
	{
		
	}
}

[System.Serializable]
public class InventorySlot
{
	/**The Item in this inventory slot*/
	public Item2D item;
	/**The amount of the item in this inventory slot*/
	public int amount;

	public InventorySlot()
	{
		
	}

	public InventorySlot(Item2D setItem, int setAmount)
	{
		item = setItem;
		amount = setAmount;
	}

	public InventorySlot setItemData(object newItemData)
	{
		item.addModifiyer(new AttributeModifiyer("base.health.max", 15.0f, AttributeModType.ADD));
		return this;
	}

	/**Gets the item in this itemslot*/
	public Item2D getItem()
	{
		return item;
	}
}