using UnityEngine;
using System.Collections;

public class LoopScript : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		HoverScript hso = other.GetComponent<HoverScript> ();
		Rigidbody rb = other.GetComponent<Rigidbody>();
		hso.m_forwardAcc = 5000;
		hso.m_maximumAcc = 5000;
		rb.drag = 4.75f;
	}

	void OnTriggerExit(Collider other) {
		HoverScript hso = other.GetComponent<HoverScript> ();
		Rigidbody rb = other.GetComponent<Rigidbody>();
		hso.m_forwardAcc = 1500;
		hso.m_forwardAcc = 1500;
		rb.drag = 2.5f;

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
