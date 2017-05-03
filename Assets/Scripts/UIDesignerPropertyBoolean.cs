using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class UIDesignerPropertyBoolean : UIDesignerProperty
{
	/**The value of this property*/
	public bool booleanValue = false;

	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}


	public override void activate()
	{
		booleanValue = !booleanValue;
	}
}
