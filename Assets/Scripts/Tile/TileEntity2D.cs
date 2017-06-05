using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEntity2D : MonoBehaviour
{
	/**The position of this tile entity*/
	public IntPosition position;
	/**The name of this tile entity*/
	public string tileEntityName = "tileEntity";
	/**How many ticks per update*/
	public int tickSpeed = 30;
	/**The last time a tile entity tick happened*/
	public float lastTickTime = 0;

	//The update method
	void Update()
	{
		if(tickSpeed <= 0)
		{
			lastTickTime = Time.time;
			OnTileEntityTick(); 
			return;
		}
			
		if(Time.frameCount % tickSpeed == 0)
		{
			lastTickTime = Time.time;
			OnTileEntityTick();
		}
	}

	/**Called whenever this tile entity has a tick called*/
	public virtual void OnTileEntityTick()
	{
		
	}
}
