using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject target;
	public GameObject mainCamera;

	private Vector3 diff;
	public float dist_back=15f;
	public float dist_up=1f;

	// Use this for initialization
	void Start () {
		//diff = new Vector3 (0.0f,1.0f,5); //this.transform.position - target.transform.position;
	}
	
	// LateUpdate is called once per frame after physics
	void LateUpdate () {
		//this.transform.rotation = Quaternion.Euler(0.0f, target.transform.eulerAngles.y, target.transform.eulerAngles.z);

		Vector3 rear = -target.transform.forward;
		Vector3 offset = rear * dist_back + target.transform.up * dist_up;
		mainCamera.transform.position = target.transform.position + offset;
		mainCamera.transform.rotation = Quaternion.Euler (target.transform.eulerAngles);
	}
}
