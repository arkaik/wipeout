using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {
	public float maxVelocity = 300f;
	public float acc = 50f;
	public float desacc = 10f;
	public float maxBackVelocity = -100f;
	public float currentVelocity = 50f;
	public float backVelocity = 20f;

	// Use this for initialization
	void Start () {
		
	}

	
	// Update is called once per frame
	void Update () {
	/*if (currentVelocity < maxVelocity) {
			float delta = acc * Time.deltaTime;
			currentVelocity = Mathf.Min(currentVelocity + delta,maxVelocity);
			ia.speed = currentVelocity;
		}*/
	}
}
