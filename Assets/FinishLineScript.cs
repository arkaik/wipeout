using UnityEngine;
using System.Collections;

public class FinishLineScript : MonoBehaviour {

	public Canvas endMenu;
	private int max_num_rounds = 1;

	void OnTriggerExit(Collider other) {
		endMenu.enabled = true;
		other.attachedRigidbody.velocity = Vector3.zero;
	}

	// Use this for initialization
	void Start () {
		endMenu.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
