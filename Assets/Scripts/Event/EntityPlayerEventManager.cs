using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPlayerEventManager : MonoBehaviour {

	public delegate void StatChange();
	public static event StatChange statsChanged;



	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
