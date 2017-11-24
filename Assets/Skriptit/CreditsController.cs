using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour {

    RawImage background;
    Text madeBy;
    Text names;
    Button backToMenu;

	void Start () {
        // Finding gameobjects
        background = GameObject.Find("Background").GetComponent<RawImage>();
        madeBy = GameObject.Find("MadeBy").GetComponent<Text>();
        names = GameObject.Find("Names").GetComponent<Text>();
        backToMenu = GameObject.Find("BackToMenu").GetComponent<Button>();

        // Adding listener to button
        backToMenu.onClick.AddListener(() => goMenu("Back"));
	}
    private void goMenu (string back)
    {
        // Changing Scene menu back
        if (back.Equals("Back"))
            SceneManager.LoadScene("Menu");
    }
}
