using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class UIDesignerPropertyHeader : UIDesignerProperty 
{
	public override void Start()
	{
		propertyNameText.text = propertyDisplayName;
	}

	/**Button command for displaying the help menu*/
	public virtual void helpActivate()
	{
		baseDesigner.showHelp();
	}

	/**Button command for reseting the selected object to it's default behaviour*/
	public virtual void resetActivate()
	{
		Debug.Log("Unimplmented Method: Reset");
	}

	/**Button command for copying the selected property*/
	public virtual void copyActivate()
	{
		Debug.Log("Unimplmented Method: Copy");
	}

	/**Button command for cutting the selected property*/
	public virtual void cutActivate()
	{
		Debug.Log("Unimplmented Method: Cut");
	}

	/**Button command for pasting the selected property*/
	public virtual void pasteActivate()
	{
		Debug.Log("Unimplmented Method: Paste");
	}

	/**Button command for displaying the menu*/
	public virtual void menuActivate()
	{
		Debug.Log("Unimplmented Method: Menu");
	}

	public override void activate()
	{
		base.activate();
	}

	public override void initialize(EngineDesigner designBase, FieldInfo fieldBase, MonoBehaviour monoBehaviour)
	{
		baseDesigner = designBase;
		field = fieldBase;
		behaviour = monoBehaviour;
	}
}
