using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		HoverScript hs = other.gameObject.GetComponent<HoverScript>;
		if (hs != null) {
			hs.m_forwardAcc = 0;
			other.attachedRigidbody.velocity = 0;
		}

		Destroy (gameObject);
	}
}
