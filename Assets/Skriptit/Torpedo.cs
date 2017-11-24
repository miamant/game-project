using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Torpedo : MonoBehaviour
{
	Rigidbody2D rb;
	Vector2 direction;
	public float speed = 10.0f;

	void Start ()
	{
		rb = this.GetComponent<Rigidbody2D> ();
		direction = new Vector2 (CrossPlatformInputManager.GetAxis ("Horizontal_2"),
			CrossPlatformInputManager.GetAxis ("Vertical_2"));
		StartCoroutine ("Scale");
	}

	void Update ()
	{
		rb.AddForce (direction * speed);
	}

	IEnumerator Scale ()
	{
		for (int i = 0; i < 35; i++) {
			transform.localScale += new Vector3 (.013f, .013f, 0);
			yield return new WaitForSeconds (.01f);
		}

		this.GetComponent<CapsuleCollider2D> ().enabled = true;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		Explode ();
	}

	void Explode ()
	{
		Destroy (this.gameObject);
	}
}
