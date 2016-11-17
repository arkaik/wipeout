﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class HoverScript : MonoBehaviour {

	Rigidbody m_rb;
	float m_deadZone = 0.1f;

	//Hover
	public float m_hoverForce = 9.0f;
	public float m_hoverHeight = 2.0f;
	public GameObject[] m_hoverPoints;

	//Forward
	public float m_forwardAcc = 100.0f;
	public float m_backwardAcc = 25.0f;
	float m_currThrust = 0.0f;

	//Turn
	public float m_turnStrength = 10.0f;
	float m_currTurn = 0.0f;

	int m_layerMask;

	void Start() {
		m_rb = GetComponent<Rigidbody> ();
		m_layerMask = 1 << LayerMask.NameToLayer ("Characters");
		m_layerMask = ~m_layerMask;

	}

	void Update() {
		//Main Thrust
		m_currThrust = 0.0f;
		float accAxis = Input.GetAxis("Vertical");
		if (accAxis > m_deadZone)
			m_currThrust = accAxis * m_forwardAcc;
		else if (accAxis < -m_deadZone)
			m_currThrust = accAxis * m_backwardAcc;

		//Turning
		m_currTurn = 0.0f;
		float turnAxis = Input.GetAxis ("Horizontal");
		if (Mathf.Abs (turnAxis) > m_deadZone)
			m_currTurn = turnAxis;
	}

	void FixedUpdate() {

		RaycastHit hit;
		for (int i = 0; i < m_hoverPoints.Length; i++) {
			GameObject hov = m_hoverPoints [i];
			if (Physics.Raycast( hov.transform.position, Vector3.down, out hit, m_hoverHeight, m_layerMask))
				m_rb.AddForceAtPosition (Vector3.up * m_hoverForce * (1.0f - (hit.distance / m_hoverHeight)), hov.transform.position);
			else {
				if (transform.position.y > hov.transform.position.y)
					m_rb.AddForceAtPosition (hov.transform.up * m_hoverForce, hov.transform.position);
				else
					m_rb.AddForceAtPosition (hov.transform.up * -m_hoverForce, hov.transform.position);
			}
		}

		if (Mathf.Abs (m_currThrust) > 0)
			m_rb.AddForce (transform.forward*m_currThrust);

		if (m_currTurn > 0)
			m_rb.AddRelativeTorque(Vector3.up * m_currTurn * m_turnStrength);
		else if (m_currTurn < 0)
			m_rb.AddRelativeTorque(Vector3.up * m_currTurn * m_turnStrength);
		
	}

	void OnDrawGizmos()
	{
		//  Hover Force
		RaycastHit hit;
		for (int i = 0; i < m_hoverPoints.Length; i++)
		{
			var hoverPoint = m_hoverPoints [i];
			if (Physics.Raycast(hoverPoint.transform.position, 
				-Vector3.up, out hit,
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
		}
	}
}
