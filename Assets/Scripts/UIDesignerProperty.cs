using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class UIDesignerProperty : MonoBehaviour
{
	/**The to display for this property*/
	public string propertyDisplayName = "";
	/**The base designer*/
	public EngineDesigner baseDesigner;
	/**The field info for this property*/
	public FieldInfo field;

	// Use this for initialization
	void Start()
	{
		if(baseDesigner == null || field == null)
			Destroy(this.gameObject);
	}

	/**Called whenever the field info is changed*/
	public void updateInfo(FieldInfo newField)
	{
		field = newField;
		propertyDisplayName = field.Name;
	}

	/**This needs to be called whenever this is created or else the object wil; break*/
	public virtual void initalize(EngineDesigner designBase, FieldInfo fieldBase)
	{
		baseDesigner = designBase;
		field = fieldBase;
	}

	/**Called whenever this property editor is updated*/
	public virtual void activate()
	{

	}

}
