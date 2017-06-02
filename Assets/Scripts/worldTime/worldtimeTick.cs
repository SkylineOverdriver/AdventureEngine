using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeTick : MonoBehaviour 
{

	// Use this for initialization

	public float cycleLength = 1200;
	public float cycleCount = 1;
	public float saveTime = 0;
	public float currentTime = 0;
	public float getTime()
	{
		return Time.time + saveTime;
	}
	//Day 1
	void Start () 
	{
		


	}
	
	// Update is called once per frame
	void Update () 
	{
		if ( getTime() > (cycleLength * cycleCount)  )
		{
			cycleCount++;
		}

	}
}
