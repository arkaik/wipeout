﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class editorPathScript : MonoBehaviour {
	public Color rayColor = Color.red;
	public List<Transform> path_objs = new List<Transform>();
	Transform[] theArray;
	public float tamEsf = 10f;
	
	void Start() {
		theArray = 	GetComponentsInChildren<Transform>();
		path_objs.Clear();
		foreach	(Transform path_obj in theArray) {
			if (path_obj != this.transform) path_objs.Add(path_obj);
		}
	}
	
	void OnDrawGizmos() {
		Gizmos.color = rayColor;
		//Unir los puntos con una linea y ponerles una bolita
		for (int i = 0; i < path_objs.Count;++i) {
			Vector3 position = path_objs[i].position;
			if (i > 0) {
				Vector3 previous = path_objs[i - 1].position;
				Gizmos.DrawLine(previous,position);
				Gizmos.DrawWireSphere(position,tamEsf);
			}
		}
	}
}
