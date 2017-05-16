using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2DArmor : Item2D
{
	/**The defense that this armor adds*/
	public float defenseValue = 1.0f;

	public override void itemCrafted()
	{
		addModifiyer(new AttributeModifiyer("base.defense.value", defenseValue, AttributeModType.ADD));
	}
}
