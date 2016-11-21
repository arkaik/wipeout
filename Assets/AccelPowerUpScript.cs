using UnityEngine;
using System.Collections;

public class AccelPowerUpScript : MonoBehaviour {

	public float accel = 7500;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {
		HoverScript hs = other.gameObject.GetComponent<HoverScript> ();
		hs.m_forwardAcc = accel;
	}
}
