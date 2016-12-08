using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public Camera mainCamera;

	public Canvas creditsMenu;
	public Canvas helpMenu;

	public Button playButton;
	public Button exitButton;
	public Button creditsButton;
	public Button helpButton;

	private Quaternion fromRotation;
	private Quaternion toRotation;
	private float speed = 0.5f;
	private float timer = 0.0f;

	// Use this for initialization
	void Start () {
		playButton = playButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
		creditsButton = exitButton.GetComponent<Button> ();
		helpButton = exitButton.GetComponent<Button> ();

		//creditsMenu.enabled = false;
		//helpMenu.enabled = false;
	}

	public void StartLevel() {
		SceneManager.LoadScene ("s1");
	}

	public void QuitGame() {
		Application.Quit ();
	}

	public void CreditsEnter() {
		timer = 0.0f;
		fromRotation = Quaternion.Euler (0f, 0f, 0f);
		toRotation = Quaternion.Euler (0f, 90f, 0f);
	}

	public void CreditsExit() {
		timer = 0.0f;
		fromRotation = Quaternion.Euler (0f, 90f, 0f);
		toRotation = Quaternion.Euler (0f, 0f, 0f);
	}

	public void HelpEnter() {
		timer = 0.0f;
		fromRotation = Quaternion.Euler (0f, 0f, 0f);
		toRotation = Quaternion.Euler (0f, -90f, 0f);
	}

	public void HelpExit() {
		timer = 0.0f;
		fromRotation = Quaternion.Euler (0f, -90f, 0f);
		toRotation = Quaternion.Euler (0f, 0f, 0f);

	}

	// Update is called once per frame
	void Update () {
		mainCamera.transform.rotation = Quaternion.Slerp(fromRotation, toRotation, timer * speed);

		timer += Time.deltaTime;
	}
}
