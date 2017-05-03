using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class EngineDesigner : MonoBehaviour {

	public GameObject selectedObject;

	public MonoBehaviour selectedBehavior;

	public GameObject[] objectList;

	/**How to search all objects, 1 is */
	public int searchType = 0;

	/**The gameobject which holds all the property editors*/
	public GameObject propertyStack;

	/**An array of all the property editor gameobjects*/
	public GameObject[] propertyEditorObjects;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateSearch(string search)
	{
		
	}

	public void saveObject(string name, EngineObjectData data)
	{
		
	}

	public void loadObject(string name)
	{
		
	}

	public void OnGUI()
	{
		System.Type type = selectedBehavior.GetType();
		FieldInfo[] fields = type.GetFields();

		foreach(FieldInfo field in fields)
		{
			if(field.FieldType == typeof(float))
			{
				
			}
			else if(field.FieldType == typeof(int))
			{
				
			}
			else if(field.FieldType == typeof(string))
			{

			}
			else if(field.FieldType == typeof(byte))
			{

			}
			else if(field.FieldType == typeof(bool))
			{

			}
			else if(field.FieldType == typeof(long))
			{

			}
			else if(field.FieldType == typeof(ulong))
			{

			}
			else if(field.FieldType == typeof(uint))
			{

			}
			else if(field.FieldType == typeof(char))
			{

			}
			else if(field.FieldType == typeof(double))
			{

			}
			else if(field.FieldType == typeof(decimal))
			{

			}
			else if(field.FieldType == typeof(sbyte))
			{

			}
			else if(field.FieldType == typeof(short))
			{

			}
			else if(field.FieldType == typeof(ushort))
			{

			}
			else if(field.FieldType == typeof(KeyCode))
			{

			}
			else if(field.FieldType == typeof(Vector2))
			{
				Vector2 vec2 = (Vector2) field.GetValue(selectedBehavior);
				//This is a mess, reflection does that :(
				field.SetValue(selectedBehavior, new Vector2(float.Parse(GUILayout.TextArea(vec2.x.ToString(), new GUILayoutOption[]{GUILayout.Width(100), GUILayout.Height(20)})), float.Parse(GUILayout.TextArea(vec2.y.ToString(), new GUILayoutOption[]{GUILayout.Width(100), GUILayout.Height(20)}))));
			}
			else if(field.FieldType == typeof(EntityAttribute))
			{
				EntityAttribute entityAttr = (EntityAttribute) field.GetValue(selectedBehavior);
				field.SetValue(selectedBehavior, new EntityAttribute(entityAttr.min, entityAttr.max, GUILayout.HorizontalSlider(entityAttr.getValue(), entityAttr.min, entityAttr.max, GUILayout.Width(100f))));
			}
			else if(field.FieldType == typeof(EntityIntAttribute))
			{
				EntityIntAttribute entityAttr = (EntityIntAttribute) field.GetValue(selectedBehavior);
				field.SetValue(selectedBehavior, new EntityIntAttribute(entityAttr.min, entityAttr.max, (int) GUILayout.HorizontalSlider(entityAttr.getValue(), entityAttr.min, entityAttr.max, GUILayout.Width(100f))));
			}
			else if(field.FieldType == typeof(EntityAI))
			{
				EntityAI entityAI = (EntityAI) field.GetValue(selectedBehavior);
				field.SetValue(selectedBehavior, new EntityAI());
			}
			else if(field.FieldType == typeof(PlayerClass))
			{
				GUILayout.Box("Class: " + field.GetValue(selectedBehavior), GUILayout.Width(100));
			}
			else if(field.FieldType == typeof(PlayerAspect))
			{
				GUILayout.Box("Aspect: " + field.GetValue(selectedBehavior), GUILayout.Width(100));
			}
			else
			{
				GUILayout.Box("No Property Editor for type " + field.FieldType.Name, GUILayout.Width(300));
			}
		}

	}

	/**Adds a property editor to the UI*/
	public void addPropertyEditor(string name, int type)
	{
		Instantiate(propertyEditorObjects[type]);
	}

	/**Clears the list of properties*/
	public void clearProperties()
	{
		
	}
}

public class EngineObjectData
{


}