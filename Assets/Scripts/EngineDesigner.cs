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
	/**The position (* the spacer) that the next property editor will be placed*/
	public int propertyStackIndex = 0;
	/**The size between each property editor*/
	public int propertyStackSpacing = 65;

	/**An array of all the property editor gameobjects*/
	public List<GameObject> propertyEditorObjects = new List<GameObject>();

	/**A header property editor*/
	public GameObject propertyEditorHeader;
	/**A edit box property editor*/
	public GameObject propertyEditorEditField;
	/**A boolean property editor*/
	public GameObject propertyEditorBoolean;
	/**A custom property editor*/
	public GameObject propertyEditorCustom;
	/**A filler property editor, used for descriptions and other things*/
	public GameObject propertyEditorFiller;
	/**The help panel that will show up when the help button on a property header is pressed*/
	public GameObject helpPanel;

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
		destroyPropertyStack();

		createPropertyStack();
	}

	public void OnGUI2()
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

	/**Creates the property stack, Doesn't know if it already exists*/
	public void createPropertyStack()
	{
		//Populate the behaviour array from the selected object
		foreach(MonoBehaviour monoBehaviour in selectedObject.GetComponents<MonoBehaviour>())
		{
			selectedBehaviours.Add(monoBehaviour);
		}

		//Initalize the empty placeholders for creation
		System.Type type;
		FieldInfo[] fields;

		//Assign and create the property editor window
		foreach(MonoBehaviour monoBehaviour in selectedBehaviours)
		{
			type = monoBehaviour.GetType();
			fields = type.GetFields();

			//Add A header field, it doesn't require any parameters
			addPropertyEditor(0, null, monoBehaviour);

			//Add the other fields
			foreach(FieldInfo field in fields)
			{
				if(field.FieldType == typeof(int) || field.FieldType == typeof(float) || field.FieldType == typeof(string) || field.FieldType == typeof(byte))
				{
					addPropertyEditor(1, field, monoBehaviour);
				}
				else if(field.FieldType == typeof(bool))
				{
					addPropertyEditor(2, field, monoBehaviour);
				}
				else
				{
					addPropertyEditor(4, field, monoBehaviour);
				}

			}
		}
	}

	/**Destroys the existing property stack*/
	public void destroyPropertyStack()
	{
		selectedBehaviours.Clear();

		for(int i = 0; i < propertyStack.transform.childCount; i++)
		{
			Destroy(propertyStack.transform.GetChild(i));
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

	/**Add's a property editor to the UI (Correctly)*/
	public void addPropertyEditor(int type, FieldInfo info, MonoBehaviour monoBehaviour)
	{
		GameObject propertyEditorObj;
		UIDesignerProperty propertyEditor;

		//Create a specific type of property editor
		switch(type)
		{
		case 0:
			propertyEditorObj = Instantiate(propertyEditorHeader, propertyStack.transform);
			propertyEditor = propertyEditorObj.GetComponent<UIDesignerPropertyHeader>();
			((UIDesignerPropertyHeader) propertyEditor).propertyDisplayName = monoBehaviour.GetType().Name;
			break;
		case 1:
			propertyEditorObj = Instantiate(propertyEditorEditField, propertyStack.transform);
			propertyEditor = propertyEditorObj.GetComponent<UIDesignerPropertyEditField>();
			break;
		case 2:
			propertyEditorObj = Instantiate(propertyEditorBoolean, propertyStack.transform);
			propertyEditor = propertyEditorObj.GetComponent<UIDesignerPropertyBoolean>();
			break;
		case 3:
			propertyEditorObj = Instantiate(propertyEditorCustom, propertyStack.transform);
			propertyEditor = propertyEditorObj.GetComponent<UIDesignerPropertyCustom>();
			break;
		case 4:
			propertyEditorObj = Instantiate(propertyEditorFiller, propertyStack.transform);
			propertyEditor = propertyEditorObj.GetComponent<UIDesignerPropertyFiller>();
			((UIDesignerPropertyFiller) propertyEditor).propertyDisplayValue = info.GetValue(monoBehaviour).ToString();
			break;
		default:
			propertyEditorObj = Instantiate(propertyEditorCustom, propertyStack.transform);
			propertyEditor = propertyEditorObj.GetComponent<UIDesignerPropertyCustom>();
			break;
		}

		//Set that property editor's values and position
		propertyEditor.initalize(this, info, monoBehaviour);
		propertyEditor.propertyDisplayName = info.Name;
		propertyEditorObj.GetComponent<RectTransform>().Translate(new Vector2(0, propertyStackIndex * propertyStackSpacing));//.transform.position.Set(0, propertyStackIndex * propertyStackSpacing, 0);
		propertyStackIndex++;
	}

	/**Clears the list of properties*/
	public void clearProperties()
	{
		
	}

	public void updateProperty()
	{
		
	}

	/**Displays the help panel*/
	public void showHelp()
	{
		helpPanel.SetActive(true);
	}
}

public class EngineObjectData
{


}