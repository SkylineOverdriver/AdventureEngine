using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity2DItem : Entity2D
{
	/**The item that this entity is*/
	public Item2D item;
	/**The amount of this item on this entity item*/
	public int itemAmount;

	public override void onInteracted(Entity2D sender)
	{
		if(typeof(Entity2DLiving).Equals(sender.GetType()))
		{
			Entity2DLiving entity = (Entity2DLiving) sender;
			entity.entityInventory.addSlotItem(new InventorySlot(item, itemAmount));
			Destroy(this.gameObject);
		}
	}
}
