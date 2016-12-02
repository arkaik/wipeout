using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public Canvas creditsMenu;
	public Canvas helpMenu;

	public Button playButton;
	public Button exitButton;
	public Button creditsButton;
	public Button helpButton;

	// Use this for initialization
	void Start () {
		playButton = playButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
		creditsButton = exitButton.GetComponent<Button> ();
		helpButton = exitButton.GetComponent<Button> ();

		creditsMenu.enabled = false;
		helpMenu.enabled = false;
	}

	public void StartLevel() {
		SceneManager.LoadScene ("s1");
	}

	public void QuitGame() {
		Application.Quit ();
	}

	public void CreditsEnter() {
		creditsMenu.enabled = true;
	}

	public void CreditsExit() {
		creditsMenu.enabled = false;
	}

	public void HelpEnter() {
		helpMenu.enabled = true;
	}

	public void HelpExit() {
		helpMenu.enabled = false;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
