using UnityEngine;
using System.Collections;

public class FirePowerUpScript : MonoBehaviour {

	public float timeOffset = 2;
	private float timer;

	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (gameObject.activeSelf == false) {
			timer += Time.deltaTime;
			if (timer >= timeOffset) {
				timer = 0;
				gameObject.SetActive (true);
			} 
		}*/

	}

	void OnTriggerEnter(Collider other) {
		GunScript gs = other.gameObject.GetComponent<GunScript> ();
		if (gs != null) {
			int numb = gs.NumBullets ();
			if (numb < gs.max_bullets)
				gs.SetNumBullets (numb + 1);

		//	gameObject.SetActive (false);
		}
	}
}
