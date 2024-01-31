using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialBar : MonoBehaviour
{
	public Image barImage;
	public void UpdateBar(float percent)
	{
		if (percent < 0) percent = 0;
		if (percent > 1.0f) percent = 1.0f;
		barImage.fillAmount = percent;
	}
}
