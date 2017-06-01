using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2DWeapon : Item2D
{
	/**The damage that this weapon will do*/
	public float weaponDamage = 0.0f;

	public override void itemCrafted()
	{
		addModifiyer(new AttributeModifiyer("base.strength.value", weaponDamage, AttributeModType.ADD));
	}

	public override void itemUse(KeyCode useButton)
	{
		if(useButton == KeyCode.Mouse0)
		{
			
		}
		else if(useButton == KeyCode.Mouse1)
		{
				
		}
	}
}
