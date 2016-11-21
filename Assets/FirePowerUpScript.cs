using UnityEngine;
using System.Collections;

public class FirePowerUpScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		GunScript gs = other.gameObject.GetComponent<GunScript> ();
		int numb = gs.NumBullets ();
		if (numb < gs.max_bullets)
			gs.SetNumBullets(numb+1);
	}
}
