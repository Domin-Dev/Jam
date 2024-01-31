using UnityEngine;
using System.Collections;

public class SimpleBar : MonoBehaviour {

	public GameObject barImage;

	public void UpdateBar (float percent) {
		if(percent < 0) percent = 0;
		if(percent > 1.0f) percent = 1.0f;
		barImage.transform.localScale = new Vector3 (percent,1,1);
	}
}
