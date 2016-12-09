using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IA : MonoBehaviour {
	public editorPathScript PathToFollow;
	public int currentPointID = 0;
	public float reachDistance = 1.0f;
	public float rotationSpeed = 5.0f;
	public string pathName;
	
	Vector3 lastPosition;
	Vector3 currentPosition;
	
	public Transform[] wayPointList;
 
     public int currentWayPoint = 0; 
     Transform targetWayPoint;
 
     public float speed = 50f;
	 
	 public float rdp = 10f;

	// Use this for initialization
	void Start () {
		lastPosition = transform.position;
		PathToFollow = GameObject.Find("Path").GetComponent<editorPathScript>();
	}
	
	// Update is called once per frame
	void Update () {
	         // check if we have somewere to walk
			 if (currentPointID < PathToFollow.path_objs.Count) {
				 Vector3 targetPosition = PathToFollow.path_objs[currentPointID].position;
				 float distance = Vector3.Distance(targetPosition, transform.position);
				 transform.position = Vector3.MoveTowards(transform.position,targetPosition,speed*Time.deltaTime);
				 var rotation = Quaternion.LookRotation(targetPosition - transform.position);
				 transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
				 if (distance <= reachDistance) {
					 currentPointID = (currentPointID + 1) % PathToFollow.path_objs.Count;
				 }
			 }
			
	}
	
}
