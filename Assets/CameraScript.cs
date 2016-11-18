﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject target;
	private Vector3 diff;
	private float dist;
	private float height;
	public float prev_angle;

	// Use this for initialization
	void Start () {
		diff = this.transform.position - target.transform.position;
		dist = Mathf.Sqrt (diff.x * diff.x + diff.z * diff.z);
		height = diff.y;
		prev_angle = target.transform.eulerAngles.y;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 rear = -target.transform.forward;
		Vector3 offset = new Vector3 (rear.x, 0.0f, rear.z) * dist + Vector3.up * height;
		this.transform.position = target.transform.position + offset; 
		this.transform.rotation = Quaternion.Euler(0.0f, target.transform.eulerAngles.y, 0.0f);
		//float ang_diff = target.transform.eulerAngles.y - prev_angle;
		//prev_angle = target.transform.eulerAngles.y;
		//this.transform.RotateAround(target.transform.position, Vector3.up, ang_diff);

	}
}
