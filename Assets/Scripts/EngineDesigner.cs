using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class EngineDesigner : MonoBehaviour {

	/**The current object selected for editing*/
	public GameObject selectedObject;

	/**The current behaviour selected for editing*/
	public MonoBehaviour selectedBehavior;
	/**A list of all the monobehaviours on the selected object*/
	public List<MonoBehaviour> selectedBehaviours = new List<MonoBehaviour>();
	/**The fields on the behaviours*/
	public FieldInfo[] selectedBehavioursFields;

	/**The objects that can be selected*/
	public GameObject[] objectList;

	/**How to search all objects, 1 is */
	public int searchType = 0;

	/**The gameobject which holds all the property editors*/
	public GameObject propertyStack;

	/**An array of all the property editor gameobjects*/
	public List<GameObject> propertyEditorObjects = new List<GameObject>();

	public GameObject propertyEditorHeader;

	public GameObject propertyEditorEditBox;

	public GameObject propertyEditorBoolean;

	public GameObject propertyEditorCustom;

	// Use this for initialization
	void Start () 
	{
		onSelectionChanged();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
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

	public void onSelectionChanged()
	{
		selectedBehaviours.Clear();
		foreach(MonoBehaviour monoBehaviour in selectedObject.GetComponents<MonoBehaviour>())
		{
			selectedBehaviours.Add(monoBehaviour);
		}
	}

	public void OnGUI()
	{
		System.Type type = selectedBehavior.GetType();
		FieldInfo[] fields = type.GetFields();

		foreach(MonoBehaviour monoBehaviour in selectedBehaviours)
		{
			type = monoBehaviour.GetType();
			fields = type.GetFields();

			foreach(FieldInfo field in fields)
			{
				if(field.FieldType == typeof(float))
				{
					float floatValue = (float) field.GetValue(monoBehaviour);
					field.SetValue(monoBehaviour, float.Parse(GUILayout.TextArea(floatValue.ToString(), GUILayout.Width(100))));
				}
				else if(field.FieldType == typeof(int))
				{
					int intValue = (int) field.GetValue(monoBehaviour);
					field.SetValue(monoBehaviour, int.Parse(GUILayout.TextArea(intValue.ToString(), GUILayout.Width(100))));
				}
				else if(field.FieldType == typeof(string))
				{
					string stringValue = (string) field.GetValue(monoBehaviour);
					field.SetValue(monoBehaviour, (GUILayout.TextArea(stringValue, GUILayout.Width(100))));
				}
				else if(field.FieldType == typeof(byte))
				{
					byte byteValue = (byte) field.GetValue(monoBehaviour);
					field.SetValue(monoBehaviour, byte.Parse(GUILayout.TextArea(byteValue.ToString(), GUILayout.Width(100))));
				}
				else if(field.FieldType == typeof(bool))
				{
					bool boolValue = (bool) field.GetValue(monoBehaviour);
					field.SetValue(monoBehaviour, GUILayout.Toggle(boolValue, field.Name, GUILayout.Width(100f)));
				}
				/*else if(field.FieldType == typeof(long))
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

				}*/
				else if(field.FieldType == typeof(Vector2))
				{
					Vector2 vec2 = (Vector2) field.GetValue(monoBehaviour);
					//This is a mess, reflection does that :(
					field.SetValue(monoBehaviour, new Vector2(float.Parse(GUILayout.TextArea(vec2.x.ToString(), new GUILayoutOption[]{GUILayout.Width(100), GUILayout.Height(20)})), float.Parse(GUILayout.TextArea(vec2.y.ToString(), new GUILayoutOption[]{GUILayout.Width(100), GUILayout.Height(20)}))));
				}
				else if(field.FieldType == typeof(EntityAttribute))
				{
					EntityAttribute entityAttr = (EntityAttribute) field.GetValue(monoBehaviour);
					field.SetValue(monoBehaviour, new EntityAttribute(entityAttr.min, entityAttr.max, GUILayout.HorizontalSlider(entityAttr.getValue(), entityAttr.min, entityAttr.max, GUILayout.Width(100f))));
				}
				else if(field.FieldType == typeof(EntityIntAttribute))
				{
					EntityIntAttribute entityAttr = (EntityIntAttribute) field.GetValue(monoBehaviour);
					field.SetValue(monoBehaviour, new EntityIntAttribute(entityAttr.min, entityAttr.max, (int) GUILayout.HorizontalSlider(entityAttr.getValue(), entityAttr.min, entityAttr.max, GUILayout.Width(100f))));
				}
				else if(field.FieldType == typeof(PlayerClass))
				{
					GUILayout.Box("Class: " + field.GetValue(monoBehaviour), GUILayout.Width(100));
				}
				else if(field.FieldType == typeof(PlayerAspect))
				{
					GUILayout.Box("Aspect: " + field.GetValue(monoBehaviour), GUILayout.Width(100));
				}
				else
				{
					GUILayout.Box("No Property Editor for type " + field.FieldType.Name, GUILayout.Width(300));
				}
			}
		}
	}

	/**Adds a property editor to the UI*/
	public void addPropertyEditor(string name, int type, FieldInfo info)
	{
		GameObject propertyEditorObj = Instantiate(propertyEditorObjects[type]);
		UIDesignerProperty propertyEditor = propertyEditorObj.GetComponent<UIDesignerProperty>();
		propertyEditor.field = info;
		propertyEditor.propertyDisplayName = info.Name;
	}

	/**Clears the list of properties*/
	public void clearProperties()
	{
		
	}

	public void updateProperty()
	{
		
	}
}

public class EngineObjectData
{


}