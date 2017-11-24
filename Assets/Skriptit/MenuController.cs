using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    Button buttonPlay;
    Button buttonExit;
    Button buttonCredits;
    RawImage background;

	void Start () {
        // Finding gameobjects
        background = GameObject.Find("Background").GetComponent<RawImage>();
        buttonPlay = GameObject.Find("ButtonPlay").GetComponent<Button>();
        buttonExit = GameObject.Find("ButtonExit").GetComponent<Button>();
        buttonCredits = GameObject.Find("ButtonCredits").GetComponent<Button>();

        // Adding Listeners to buttons
        buttonPlay.onClick.AddListener(() => Aaa("play"));
        buttonExit.onClick.AddListener(() => Aaa("exit"));
        buttonCredits.onClick.AddListener(() => Aaa("credits"));
	}
    private void Aaa(string startgame)
    {
        // Starting game by changing scene
        if (startgame.Equals("play"))
        {
            SceneManager.LoadScene("");
        }
        // Exit game
        if (startgame.Equals("exit"))
        {
            Application.Quit();
        }
        else
        {
            // Changing to credits scene
            SceneManager.LoadScene("Credits");
        }
    }
}
