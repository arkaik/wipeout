﻿using UnityEngine;
using System.Collections;

public class HoverScript : MonoBehaviour {

	Rigidbody m_rb;
	float m_deadZone = 0.1f;
	float distanceHover = 5.0f;
	float gravity = 9.8f;
	private float angulo = 0.0f;

	//Hover
	public float m_hoverForce = 9.0f;
	public float m_hoverHeight = 2.0f;
	public GameObject[] m_hoverPoints;
	public GameObject hoverPoint;

	//Forward
	public float m_forwardAcc = 5000.0f;
	public float m_backwardAcc = 500.0f;
	float m_currThrust = 0.0f;

	private float m_fAcc; 

	//Turn
	public float m_turnStrength = 10.0f;
	float m_currTurn = 0.0f;

	int m_layerMask;

	void Start() {
		m_rb = GetComponent<Rigidbody> ();
		m_layerMask = 1 << LayerMask.NameToLayer ("Characters");
		m_layerMask = ~m_layerMask;
		//hoverPoint = GameObject.Find("h5");
		m_fAcc = m_forwardAcc;

	}

	void Update() {
		//Main Thrust
		m_currThrust = 0.0f;
		float accAxis = Input.GetAxis("Vertical");
		if (accAxis > m_deadZone)
			m_currThrust = accAxis * m_forwardAcc;
		else if (accAxis < -m_deadZone)
			m_currThrust = accAxis * m_backwardAcc;

		if (m_forwardAcc > m_fAcc)
			m_forwardAcc -= 50;

		//Turning
		m_currTurn = 0.0f;
		float turnAxis = Input.GetAxis ("Horizontal");
		if (Mathf.Abs (turnAxis) > m_deadZone)
			m_currTurn = turnAxis;
	}

	void FixedUpdate() {
		RaycastHit hit;
		GameObject hov = GameObject.Find("h5");
		Vector3 newPos = transform.position;
		if (Physics.Raycast(transform.position,-hov.transform.up, out hit,Mathf.Infinity,m_layerMask)) {
			if (hit.distance < distanceHover) {
				newPos.y += (distanceHover - hit.distance);
			}
			else if (distanceHover < hit.distance) {
				newPos.y -= gravity;
			}
		}
		/*RaycastHit hit;
		for (int i = 0; i < m_hoverPoints.Length; i++) {
			GameObject hov = m_hoverPoints [i];
			if (Physics.Raycast( hov.transform.position, -hov.transform.up, out hit, m_hoverHeight, m_layerMask))
				if (hit.distance < distanceHover) {
					transform.position.y += (hit.distance - transform.position.y);
				}
				//m_rb.AddForceAtPosition (hov.transform.up * m_hoverForce * (1.0f - (hit.distance / m_hoverHeight)), hov.transform.position);
			else {
				if (transform.position.y > hov.transform.position.y)
					m_rb.AddForceAtPosition (hov.transform.up * m_hoverForce, hov.transform.position);
				else
					m_rb.AddForceAtPosition (hov.transform.up * -m_hoverForce, hov.transform.position);
			}
		}*/
		if (m_currTurn != 0) {
			float a = angulo * Mathf.PI / 180;
			newPos.y = newPos.y*Mathf.Cos(a) - newPos.x*Mathf.Sin(a);
			newPos.x = newPos.y*Mathf.Sin(a) + newPos.x*Mathf.Cos(a);
		}
		if (Mathf.Abs (m_currThrust) > 0)
			transform.forward += transform.forward*m_currThrust;
		transform.position = newPos;
		//m_rb.rotation = Quaternion.Euler (0,0,m_currTurn);
	}

	void OnDrawGizmos()
	{
		//  Hover Force
		RaycastHit hit;
		GameObject hoverPoint = GameObject.Find("/Ship/h5");
		if (Physics.Raycast(hoverPoint.transform.position, 
			-hoverPoint.transform.up, out hit,
			m_hoverHeight, 
			m_layerMask))
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(hoverPoint.transform.position, hit.point);
			Gizmos.DrawSphere(hit.point, 0.5f);
		}
		/*for (int i = 0; i < m_hoverPoints.Length; i++)
		{
			var hoverPoint = m_hoverPoints [i];
			if (Physics.Raycast(hoverPoint.transform.position, 
				-hoverPoint.transform.up, out hit,
				m_hoverHeight, 
				m_layerMask))
			{
				Gizmos.color = Color.blue;
				Gizmos.DrawLine(hoverPoint.transform.position, hit.point);
				Gizmos.DrawSphere(hit.point, 0.5f);
			} else
			{
				Gizmos.color = Color.red;
				Gizmos.DrawLine(hoverPoint.transform.position, 
					hoverPoint.transform.position - Vector3.up * m_hoverHeight);
			}
		}*/
	}
}
