using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructionSceneController : MonoBehaviour
{
	// Pictures used in the development scene
	GameObject dev1;
	GameObject dev2;
	GameObject dev3;

	// Counters for each picture:
	// - used for timing changes in picture display
	int countDev1 = 0;
	int countDev2 = 0;
	int countDev3 = 0;

	// Subtitles in the scene
	Text subs;

	void Start ()
	{
		dev1 = GameObject.Find ("Dev1");
		dev2 = GameObject.Find ("Dev2");
		dev2.SetActive (false);
		dev3 = GameObject.Find ("Dev3");
		dev3.SetActive (false);

		subs = GameObject.Find ("Subtitles").GetComponent<Text> ();
	}

	void FixedUpdate ()
	{
		// Dev1 clip
		if (countDev1 < 530) {
			MovePic (dev1, "bottom-right", 1.35f, 2.2f);
			ScalePic (dev1, "smaller", 1.2f);

			switch (countDev1) {

			case 50:
				ChangeText ("The construction of the main ship began in 1914.");
				break;

			case 250:
				ChangeText ("");
				break;
			}
		}

		countDev1++;
	}

	void MovePic (GameObject obj, string direction, float speedX, float speedY)
	{
		switch (direction) {

		case "bottom-right":
			obj.GetComponent<Rigidbody2D> ().
				AddForce ((new Vector3 ((1f * speedX), (-1f * speedY), 0)) * 1);
			break;

		case "top-left":
			obj.GetComponent<Rigidbody2D> ().
				AddForce ((new Vector3 ((-1f * speedX), (1f * speedY), 0)) * 1);
			break;
		}
	}

	void ScalePic (GameObject obj, string whichWay, float speed)
	{
		switch (whichWay) {

		case "bigger":
			transform.localScale += new Vector3 ((.0005f * speed), (.0005f * speed), 0);
			break;

		case "smaller":
			obj.transform.localScale -= new Vector3 ((.0005f * speed), (.0005f * speed), 0);
			break;

		}
	}

	void ChangeText (string text)
	{
		subs.text = text;
	}
}
