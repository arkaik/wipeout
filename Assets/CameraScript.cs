using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject target;
	public float deltaRot;
	private Vector3 diff;

	// Use this for initialization
	void Start () {
		diff = this.transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = target.transform.position + diff;
		this.transform.rotation = Quaternion.Euler(0.0f, target.transform.rotation.y, 0.0f);
	}
}
