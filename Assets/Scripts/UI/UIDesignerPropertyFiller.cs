using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.UI;

public class UIDesignerPropertyFiller : UIDesignerProperty
{
	/**The text that displays the value of this property*/
	public Text propertyValueText;
	/**The value of this property*/
	public string propertyDisplayValue;

	public override void Start()
	{
		base.Start();

		propertyValueText.text = propertyDisplayValue;
	}
}
