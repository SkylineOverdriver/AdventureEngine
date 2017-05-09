using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.UI;

public class UIDesignerPropertyEditField : UIDesignerProperty
{
	[System.Obsolete("Use the type on the field value instead")]
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
			int returnVal;
			int.TryParse(inputBase.text, out returnVal);
			value = returnVal;
		}
		else if(field.FieldType == typeof(float))
		{
			float returnVal;
			float.TryParse(inputBase.text, out returnVal);
			value = returnVal;
		}
		else if(field.FieldType == typeof(string))
		{
			value = inputBase.text;
		}
		else if(field.FieldType == typeof(byte))
		{
			byte returnVal;
			byte.TryParse(inputBase.text, out returnVal);
			value = returnVal;
		}
	}

}
