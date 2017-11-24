using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GunController : MonoBehaviour
{
	public Transform torpedoSpawn;
	public GameObject torpedoPrefab;
	public int i = 0;

	// Use this for initialization
	void Start ()
	{

	}

	void FixedUpdate ()
	{
		Vector3 lookVec = new Vector3 (CrossPlatformInputManager.GetAxis ("Horizontal_2"),
			                  CrossPlatformInputManager.GetAxis ("Vertical_2"), 4000);

		if (lookVec.x != 0 && lookVec.y != 0) {
			transform.rotation = Quaternion.LookRotation (lookVec, Vector3.left);
			if (i == 50) {
				Fire ();
				i = 0;
			}
			i++;
		} else {
			transform.rotation = Quaternion.LookRotation (lookVec, Vector3.forward);
			i = 0;
		}
	}

	void Fire ()
	{
		// Create the Bullet from the Bullet Prefab
		var torpedo = (GameObject)Instantiate (
			              torpedoPrefab,
			              torpedoSpawn.transform.position,
			              torpedoSpawn.transform.rotation);

		// Destroy the bullet after 2 seconds
		Destroy (torpedo, 2.0f);  
	}
}