using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

	Transform target;
	float speed = 2;
	Rigidbody2D rb;
	public int health;
	private TextMesh statusText;

	// Use this for initialization
	void Start ()
	{
		target = GameObject.Find ("SubPod").GetComponent<Transform> ();
		rb = this.GetComponent<Rigidbody2D> ();
		this.health = 50;
		this.statusText = GameObject.Find ("EnemyStatusText").GetComponent<TextMesh> ();
	}

	void FixedUpdate ()
	{
		FollowPlayer ();
	}

	void LastUpdate ()
	{
		if (this.health == 0)
			Destroy (this.gameObject);
	}

	void FollowPlayer ()
	{
		transform.position = Vector2.MoveTowards (transform.position, target.position,
			speed * Time.deltaTime);
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		// enemy loses health when hit by torpedo
		if (col.gameObject.tag.Equals ("Torpedo")) {
			this.health--;
			this.statusText.text = this.health.ToString ();
		}
	}
}
