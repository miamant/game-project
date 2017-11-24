using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Glow : MonoBehaviour {

	public float targetTime = 4.0f;
	public float saturation = .5f;
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (targetTime > 0.0f) {
			targetTime -= Time.deltaTime;
			saturation -= .35f;
		}
		GetComponent<Image> ().color = new Color (saturation, saturation, saturation, 1);
	}
}
