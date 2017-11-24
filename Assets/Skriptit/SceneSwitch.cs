using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitch : MonoBehaviour {

	// Use this for initialization
	public Object nextscene;
	public float targetTime = 60.0f;
	public float alphaLevel = .5f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (targetTime > 0.0f) {
			targetTime -= Time.deltaTime;
			alphaLevel += .005f;
		} else {
			Application.LoadLevel(nextscene.name);
		}
		GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, alphaLevel);
	}
}
