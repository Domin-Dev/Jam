using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceSatisfaction : MonoBehaviour
{
    public Sprite[] faceSprites = new Sprite[0];
	public Image image;

	public void UpdateBar(float percent)
	{
		const float val = 0.1428f;
		int index = 0;
		if (percent < val *1) index = 0;
		else if (percent < val *2) index = 1;
		else if (percent < val *3) index = 2;
		else if (percent < val *4) index = 3;
		else if (percent < val *5) index = 4;
		else if (percent < val *6) index = 5;
		else index = 6;

		//Debug.Log("FacePercent = " + percent + ", index = " + index);

		image.sprite = faceSprites[index];
	}
}
