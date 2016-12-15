using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GunScript : MonoBehaviour {

	public GameObject bullet;
	public Text shot_text;
	public Transform ShooterPoint;

	public int max_bullets = 5;
	private int num_bullets = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			Shot ();
		}
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
		shot_text.text = "Shots: "+num_bullets;
	}

	private void Shot (){
		if (num_bullets > 0) {
			GameObject go = (GameObject)Instantiate (bullet, ShooterPoint.position, Quaternion.identity);
			Rigidbody rb = go.GetComponent<Rigidbody> ();
			rb.velocity = transform.forward * 100;
			num_bullets -= 1;
			shot_text.text = "Shots: "+num_bullets;
		}
	}

}
