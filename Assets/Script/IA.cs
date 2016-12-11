using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IA : MonoBehaviour {
	public editorPathScript PathToFollow;
	public int currentPointID = 0;
	public float reachDistance = 1.0f;
	public float rotationSpeed = 5.0f;
	public string pathName;
	public float altura = 10f;
	
 
     public float speed = 50f;

	// Use this for initialization
	void Start () {
		PathToFollow = GameObject.Find("Path").GetComponent<editorPathScript>();
		transform.rotation = Quaternion.Euler(0, 180f, 0);
		foreach (Transform path_obj in PathToFollow.path_objs) {
			path_obj.position = new Vector3(path_obj.position.x,path_obj.position.y + altura,path_obj.position.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
	         // check if we have somewere to walk
			 if (currentPointID < PathToFollow.path_objs.Count) {
				 Vector3 targetPosition = PathToFollow.path_objs[currentPointID].position;
				 var rotation = Quaternion.LookRotation(targetPosition - transform.position);
				 transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
				 float distance = Vector3.Distance(targetPosition, transform.position);
				 transform.position = Vector3.MoveTowards(transform.position,targetPosition,speed*Time.deltaTime);
				 if (distance <= reachDistance) {
					 currentPointID = (currentPointID + 1) % PathToFollow.path_objs.Count;
				 }
			 }
			
	}
	
}
