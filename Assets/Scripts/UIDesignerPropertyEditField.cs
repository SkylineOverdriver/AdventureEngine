using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.UI;

public class UIDesignerPropertyEditField : UIDesignerProperty
{
	/**The type that this edit field is*/
	public System.Type editType;
	/**The inputfield that's text is gotten fron when activate() is called*/
	public InputField inputBase;
	/**The value of this object*/
	public object value;

	public override void activate()
	{
		if(field.FieldType == typeof(int))
		{
			field.SetValue(baseDesigner.selectedObject, field);	
		}

	}

}
