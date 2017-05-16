using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageUtilities : MonoBehaviour
{
	public Texture2D[] testImages;

	public Texture2D returnImage;

	public Sprite testSprite;

	// Use this for initialization
	void Start()
	{
		returnImage = generateTexture(testImages);
		testSprite = Sprite.Create(returnImage, new Rect(0,0, returnImage.width, returnImage.height), new Vector2(0.5f, 0.5f));
		GetComponent<SpriteRenderer>().sprite = testSprite;
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	/**Layers textures on top of eachother to make a new texture*/
	public Texture2D generateTexture(Texture2D[] inputTextures)
	{
		Texture2D returnTex = new Texture2D(inputTextures[0].width, inputTextures[0].height);
		returnTex = clearTexture(returnTex);

		Color[] curTexPixels;

		Color[] returnTexPixels = returnTex.GetPixels();

		foreach(Texture2D tex in inputTextures)
		{
			curTexPixels = tex.GetPixels();

			for(int i = 0; i < curTexPixels.Length; i++)
			{
				if(curTexPixels[i].a == 1)
				{
					returnTexPixels[i] = curTexPixels[i];
				}
				else if(curTexPixels[i].a == 0 && returnTexPixels[i].a != 0)
				{
					//returnTexPixels[i].a = 0;
				}
				else
				{
					returnTexPixels[i] = new Color(returnTexPixels[i].r + curTexPixels[i].r, returnTexPixels[i].g + curTexPixels[i].g, returnTexPixels[i].b + curTexPixels[i].b, returnTexPixels[i].a + curTexPixels[i].a);
				}
			}
		}

		returnTex.SetPixels(returnTexPixels);

		returnTex.Apply();

		returnTex.filterMode = FilterMode.Point;

		return returnTex;
	}

	/**Sets all the pixels to fully transparent*/
	public Texture2D clearTexture(Texture2D inputTexture)
	{
		Color[] texturePixels = inputTexture.GetPixels();

		for(int i = 0; i < texturePixels.Length; i++)
		{
			texturePixels[i] = new Color(0,0,0,0);
		}

		inputTexture.SetPixels(texturePixels);
		inputTexture.Apply();

		return inputTexture;
	}
}
