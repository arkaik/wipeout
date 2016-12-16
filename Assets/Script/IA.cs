using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IA : MonoBehaviour {
	public editorPathScript PathToFollow;
	public Stats stats;
	public int currentPointID = 0;
	float distanceBetPoints = 1.0f;
	public float rotationSpeed = 5.0f;
	public string pathName;
	public string nombreNave;
	public float altura = 10f;
	public float ancho = 10f;
	Vector3 init = new Vector3(0f,-90f,0f);
	int m_layerMask;

	// Use this for initialization
	void Start () {
		PathToFollow = GameObject.Find(pathName).GetComponent<editorPathScript>();
		if (currentPointID < PathToFollow.path_objs.Count) {
			distanceBetPoints = Vector3.Distance(transform.position,PathToFollow.path_objs[currentPointID].position);
			foreach (Transform path_obj in PathToFollow.path_objs) {
				path_obj.position = new Vector3(path_obj.position.x + ancho,path_obj.position.y + altura,path_obj.position.z);
			}
		}
		stats = GameObject.Find(nombreNave).GetComponent<Stats>();
		m_layerMask = 1 << LayerMask.NameToLayer ("Characters");
		m_layerMask = ~m_layerMask;
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		/*if (Physics.Raycast(transform.position, transform.right, out hit, Mathf.Infinity, m_layerMask)) {
			stats.currentVelocity -= 5f;
			transform.position = Vector3.MoveTowards(transform.position,hit.transform.position,stats.currentVelocity*Time.deltaTime);
		}
		else if (Physics.Raycast(transform.position, transform.right, out hit, Mathf.Infinity, m_layerMask)) {
			stats.currentVelocity -= 5f;
			transform.position = Vector3.MoveTowards(transform.position,hit.transform.position,stats.currentVelocity*Time.deltaTime);
		}
		else */followPath();
	}
	
	void followPath() {
		if (currentPointID < PathToFollow.path_objs.Count) {
				 Vector3 targetPosition = PathToFollow.path_objs[currentPointID].position;
				 var rotation = Quaternion.Euler(init.x,init.y,init.z);
				 rotation *= Quaternion.LookRotation(targetPosition - transform.position);
				 transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
				 float distance = Vector3.Distance(targetPosition, transform.position);
				 float delta = stats.acc * Time.deltaTime;
				 stats.currentVelocity = Mathf.Min(stats.currentVelocity + delta,stats.maxVelocity);
				 transform.position = Vector3.MoveTowards(transform.position,targetPosition,stats.currentVelocity*Time.deltaTime);
				 if (distance <= distanceBetPoints*0.05) {
					currentPointID = (currentPointID + 1) % PathToFollow.path_objs.Count;
					if (currentPointID == 0) stats.currentVelocity = 50f;
					distanceBetPoints = Vector3.Distance(PathToFollow.path_objs[currentPointID].position,targetPosition);
					 
				}
			 }
	}
	
}
