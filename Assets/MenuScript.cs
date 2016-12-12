using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public Camera mainCamera;

	public Canvas creditsMenu;
	public Canvas helpMenu;

	public Transform trackCarousel;
	public int trackNumber = 2;
	private int actualTrack = 1;

	public Transform carCarousel;
	public int carNumber = 2;
	private int actualCar = 1;

	//public Button playButton;
	//public Button exitButton;
	//public Button creditsButton;
	//public Button helpButton;

	private Quaternion fromRotation;
	private Quaternion toRotation;
	private Vector3 fromPosition;
	private Vector3 toPosition;
	private float speed = 0.5f;
	private float timer = 0.0f;

	// Use this for initialization
	void Start () {
		//playButton = playButton.GetComponent<Button> ();
		//exitButton = exitButton.GetComponent<Button> ();
		//creditsButton = exitButton.GetComponent<Button> ();
		//helpButton = exitButton.GetComponent<Button> ();

		//creditsMenu.enabled = false;
		//helpMenu.enabled = false;
		fromPosition = new Vector3(0, 20, 0);
		toPosition = new Vector3(0, 20, 0);
		fromRotation = Quaternion.Euler (0, 0, 0);
		toRotation = Quaternion.Euler (0, 0, 0);
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

	public void LevelSelectionEnter() {
		timer = 0.0f;
		fromPosition = new Vector3 (0, 20, 0);
		toPosition = new Vector3 (0, 80, 0);
	}

	public void LevelSelectionExit() {
		timer = 0.0f;
		fromPosition = new Vector3 (0, 80, 0);
		toPosition = new Vector3 (0, 20, 0);
	}

	public void BackToTrackMenu() {
		timer = 0.0f;
		fromPosition = new Vector3 (0, 160, 0);
		toPosition = new Vector3 (0, 80, 0);
	}


	public void NextTrack() {
		if (actualTrack < trackNumber) {
			trackCarousel.Translate (-100, 0, 0);
			actualTrack += 1;
		}
	}

	public void PrevTrack() {
		if (actualTrack > 1) {
			trackCarousel.Translate (100, 0, 0);
			actualTrack -= 1;
		}
	}

	public void SelectTrack() {
		timer = 0.0f;
		fromPosition = new Vector3 (0, 80, 0);
		toPosition = new Vector3 (0, 160, 0);
	}

	public void NextCar() {
		if (actualCar < carNumber) {
			carCarousel.Translate (-100, 0, 0);
			actualCar += 1;
		}
	}

	public void PrevCar() {
		if (actualCar > 1) {
			carCarousel.Translate (100, 0, 0);
			actualCar -= 1;
		}
	}

	public void SelectCar() {
		PlayerPrefs.SetInt ("Car", actualCar);
		SceneManager.LoadScene ("s" + actualTrack);
	}


	// Update is called once per frame
	void Update () {

		mainCamera.transform.rotation = Quaternion.Slerp(fromRotation, toRotation, timer * speed);
		mainCamera.transform.position = Vector3.Lerp (fromPosition, toPosition, timer * speed);

		timer += Time.deltaTime;
	}
}
