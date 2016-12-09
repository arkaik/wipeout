using UnityEngine;
using System.Collections;

public class FinishLineScript : MonoBehaviour {

	public Canvas endMenu;
	public int maxNumberLaps = 1;

	void OnTriggerExit(Collider other) {
		HoverScript hs = other.gameObject.GetComponent<HoverScript>();
		if (hs.numberLaps == maxNumberLaps) {
			endMenu.enabled = true;
			other.attachedRigidbody.velocity = Vector3.zero;
		} else {
			hs.numberLaps += 1;
		}
	}

	// Use this for initialization
	void Start () {
		endMenu.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
