using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour
{
	public float playerSpeed = 10;
	Rigidbody2D myBody;
	private int health;
	private Text healthCount;
	private int count;
	public float rotationSpeed = 10;
	public float movePlayerUpDown;
	public float movePlayerLeftRight;

	void Start ()
	{
		myBody = this.GetComponent<Rigidbody2D> ();
		this.health = 100;
		this.healthCount = GameObject.Find ("HealthCount").GetComponent<Text> ();
		this.count = 0;
	}

	void FixedUpdate ()
	{
		if (Input.GetAxis("Vertical") !=0){
			movePlayerUpDown = Input.GetAxis ("Vertical");
			GetComponent<Rigidbody2D> ().velocity = transform.up * playerSpeed * movePlayerUpDown;
			Debug.Log (transform.up + " " + movePlayerUpDown);
		}

		if (Input.GetAxis ("Horizontal") != 0) {
			movePlayerLeftRight = Input.GetAxis ("Horizontal");
			GetComponent<Rigidbody2D> ().velocity = transform.right * playerSpeed * movePlayerLeftRight;
			Debug.Log (transform.right + " " + movePlayerLeftRight);
		}
	}

	void Update ()
	{

	}

	void OnCollisionEnter2D (Collision2D col)
	{
		// player cannot collide with torpedo
		if (col.gameObject.tag.Equals ("Torpedo")) {
			Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (),
				col.collider);
		}

		// player loses health when colliding with enemy
		if (col.gameObject.tag.Equals ("Enemy")) {
			Debug.Log ("Ouch!");
			this.health--;
			this.healthCount.text = this.health.ToString ();
		}
	}

	void OnCollisionStay2D (Collision2D col)
	{
		if (this.count == 50) {
			if (col.gameObject.tag.Equals ("Enemy")) {
				this.health--;
				this.healthCount.text = this.health.ToString ();
			}
		}
	}
}
