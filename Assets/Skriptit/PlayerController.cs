using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
	Rigidbody2D myBody;
	public float playerSpeed = 10, boostMultiplier = 2;
	private int health;
	private Text healthCount;
	private int count;
	GameObject playerGunChild;

	void Start ()
	{
		myBody = this.GetComponent<Rigidbody2D> ();
		this.health = 100;
		this.healthCount = GameObject.Find ("HealthCount").GetComponent<Text> ();
		this.count = 0;
		playerGunChild = GameObject.Find ("PlayerGunChild");
	}

	void FixedUpdate ()
	{
		//player movement direction
		Vector2 moveVec = new Vector2 (CrossPlatformInputManager.GetAxis ("Horizontal"),
			                  CrossPlatformInputManager.GetAxis ("Vertical")) * playerSpeed;

		//player rotation direction
		Vector3 lookVec = new Vector3 (CrossPlatformInputManager.GetAxis ("Horizontal_2"),
			                  CrossPlatformInputManager.GetAxis ("Vertical_2"), 4000);

		//boost feature (not in use)
		bool isBoosting = CrossPlatformInputManager.GetButton ("Boost");
		myBody.AddForce (moveVec * (isBoosting ? boostMultiplier : 1));

		//flips player graphics when going right
		if (CrossPlatformInputManager.GetAxis ("Horizontal") > 0) {
			this.GetComponent<SpriteRenderer> ().flipX = false;
			//this.GetComponent<Animator> ().Play ("PlayerMovement");
			playerGunChild.GetComponent<SpriteRenderer> ().flipX = false;
			playerGunChild.transform.localPosition = new Vector2 (0, 0);
		}

		//flips player graphics when going left
		if (CrossPlatformInputManager.GetAxis ("Horizontal") < 0) {
			this.GetComponent<SpriteRenderer> ().flipX = true;
			//this.GetComponent<Animator> ().Play ("PlayerMovement");
			playerGunChild.GetComponent<SpriteRenderer> ().flipX = true;
			playerGunChild.transform.localPosition = new Vector2 (1.6f, 0);
		}
	}

	void Update ()
	{
		//acts as a timer for losing health steadily while in touch
		//with an enemy
		if (this.count > 50)
			this.count = 0;
		this.count++;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		//player cannot collide with torpedo
		if (col.gameObject.tag.Equals ("Torpedo")) {
			Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (),
				col.collider);
		}

		//player loses health when colliding with enemy
		if (col.gameObject.tag.Equals ("Enemy")) {
			Debug.Log ("Ouch!");
			this.health--;
			this.healthCount.text = this.health.ToString ();
		}
	}

	void OnCollisionStay2D (Collision2D col)
	{
		//player loses health steadily while in touch
		//with an enemy
		if (this.count == 50) {
			if (col.gameObject.tag.Equals ("Enemy")) {
				this.health--;
				this.healthCount.text = this.health.ToString ();
			}
		}
	}
}
