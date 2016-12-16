using UnityEngine;
using System.Collections;

public class FirePowerUpScript : MonoBehaviour {

	public float timeOffset = 2;
	private float timer;
	private bool obtainable = true;
	MeshRenderer mr;
	public Material activeMaterial;
	public Material inactiveMaterial;

	// Use this for initialization
	void Start () {
		timer = 0;
		mr = gameObject.GetComponent<MeshRenderer> ();
		mr.material = activeMaterial;
	}
	
	// Update is called once per frame
	void Update () {
		if (!obtainable) {
			timer += Time.deltaTime;
			if (timer >= timeOffset) {
				timer = 0;
				obtainable = true;
				mr.material = activeMaterial;
			} 
		}

	}

	void OnTriggerEnter(Collider other) {
		GunScript gs = other.gameObject.GetComponent<GunScript> ();
		if (gs != null && obtainable) {
			int numb = gs.NumBullets ();
			if (numb < gs.max_bullets)
				gs.SetNumBullets (numb + 1);
			obtainable = false;
			mr.material = inactiveMaterial;
		//	gameObject.SetActive (false);
		}
	}
}
