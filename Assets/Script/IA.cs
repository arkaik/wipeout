using UnityEngine;
using System.Collections;

public class IA : MonoBehaviour {
	
	public Transform[] wayPointList;
 
     public int currentWayPoint = 0; 
     Transform targetWayPoint;
 
     public float speed = 4f;
	 
	 public float rdp = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	         // check if we have somewere to walk
         if(currentWayPoint < this.wayPointList.Length)
         {
			 targetWayPoint = wayPointList[currentWayPoint];
             walk();
         }
	}
	
	void walk(){
         // rotate towards the target
         transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed*Time.deltaTime, 0.0f);
 
         // move towards the target
         transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position,   speed*Time.deltaTime);
 
         if(dentroEsfera())
         {
             currentWayPoint ++ ;
         }
    }
	
	bool dentroEsfera() {
	//x+y = rdp es la circumferencia si x^2+y^2 <= rdp^2 esta dentro sino fuera
	Vector3 aux = new Vector3(transform.position.x - targetWayPoint.position.x,transform.position.y - targetWayPoint.position.y,transform.position.z - targetWayPoint.position.z);
	return Mathf.Pow(aux.x,2) + Mathf.Pow(aux.y,2) + Mathf.Pow(aux.z,2) <= Mathf.Pow(rdp,2);
	}
	
}

/*public class IA : MonoBehaviour {
 
     // put the points from unity interface
     
 
     // Use this for initialization
     void Start () {
 
     }
     
     // Update is called once per frame
     void Update () {
         // check if we have somewere to walk
         if(currentWayPoint < this.wayPointList.Length)
         {
             if(targetWayPoint == null)
                 targetWayPoint = wayPointList[currentWayPoint];
             walk();
         }
     }
 
     void walk(){
         // rotate towards the target
         transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed*Time.deltaTime, 0.0f);
 
         // move towards the target
         transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position,   speed*Time.deltaTime);
 
         if(transform.position == targetWayPoint.position)
         {
             currentWayPoint ++ ;
             targetWayPoint = wayPointList[currentWayPoint];
         }
     } 
 }*/
