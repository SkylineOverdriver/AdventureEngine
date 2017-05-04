using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class UIDesignerPropertyBoolean : UIDesignerProperty
{
	/**The value of this property*/
	public bool booleanValue = false;

	public override void activate()
	{
		booleanValue = !booleanValue;
	}
}
