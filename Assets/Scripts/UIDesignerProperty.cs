using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.UI;

public class UIDesignerProperty : MonoBehaviour
{
	/**The name to display for this property*/
	public string propertyDisplayName = "";
	/**The text that displays the name of this property*/
	public Text propertyNameText;
	/**The base designer*/
	public EngineDesigner baseDesigner;
	/**The field info for this property*/
	public FieldInfo field;
	/**The index of the monobehaviour that this property belongs to*/
	public MonoBehaviour behaviour;

	// Use this for initialization
	public virtual void Start()
	{
		if(baseDesigner == null || field == null)
		{
			Destroy(this.gameObject); 
			return;
		}
	}

	/**Called whenever the field info is changed*/
	public void updateInfo(FieldInfo newField)
	{
		field = newField;
		propertyNameText.text = field.Name;
		propertyDisplayName = field.Name;
	}

	/**This needs to be called whenever this is created or else the object wil break*/
	public virtual void initalize(EngineDesigner designBase, FieldInfo fieldBase, MonoBehaviour monoBehaviour)
	{
		baseDesigner = designBase;
		field = fieldBase;
		behaviour = monoBehaviour;
	}

	/**Called whenever this property editor is updated*/
	public virtual void activate()
	{

	}

}
