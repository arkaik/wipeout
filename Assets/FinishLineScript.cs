using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinishLineScript : MonoBehaviour {

	public Canvas endMenu;
	public Text pos;
	public int maxNumberLaps = 1;
	public int shipNumber = 2;
	private int shipsLap = 0;

	void OnTriggerExit(Collider other) {
		HoverScript hs = other.gameObject.GetComponent<HoverScript>();
		if (hs != null) {

			shipsLap += 1;

			if (hs.numberLaps == maxNumberLaps && other.tag == "Player") {
				endMenu.enabled = true;
				pos.text = "Position: " + shipsLap;
				other.attachedRigidbody.velocity = Vector3.zero;
			} else {
				hs.numberLaps += 1;
			}

			if (shipsLap == shipNumber)
				shipsLap = 0;
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
