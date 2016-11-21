using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour {

	public int max_bullets = 5;
	private int num_bullets = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public int NumBullets() {
		return num_bullets;
	}

	public void SetNumBullets(int nb) {
		if (nb > max_bullets)
			num_bullets = 5;
		else if (nb < 0)
			num_bullets = 0;
		else
			num_bullets = nb;

		//Get canvas and update the text 
	}
}
