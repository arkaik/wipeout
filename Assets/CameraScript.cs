using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject target;
	private Vector3 diff;

	// Use this for initialization
	void Start () {
		diff = this.transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = target.transform.position + diff;
	}
}
