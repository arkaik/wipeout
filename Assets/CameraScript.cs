using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject[] ships;
	public Vector3 initialPosition;
	public Quaternion initialRotation;

	private GameObject target;
	public GameObject mainCamera;

	//private Vector3 diff;
	public float distanceBack = 10f;
	public float distanceUp = 1f;

	// Use this for initialization
	void Start () {
		int chosenShip = PlayerPrefs.GetInt ("ship")-1;
		target = (GameObject) Instantiate (ships [chosenShip], initialPosition, initialRotation);
		GunScript gs = target.GetComponent<GunScript> ();
		GameObject gui = GameObject.Find ("GUI");
		Text tgui = (Text) gui.GetComponentInChildren<Text>();
		gs.shot_text = tgui;
		//diff = new Vector3 (0.0f,1.0f,5); //this.transform.position - target.transform.position;
	}
	
	// LateUpdate is called once per frame after physics
	void LateUpdate () {
		//this.transform.rotation = Quaternion.Euler(0.0f, target.transform.eulerAngles.y, target.transform.eulerAngles.z);

		Vector3 rear = -target.transform.forward;
		Vector3 offset = rear * distanceBack + target.transform.up * distanceUp;
		mainCamera.transform.position = target.transform.position + offset;
		mainCamera.transform.rotation = Quaternion.Euler (target.transform.eulerAngles);
	}
}
