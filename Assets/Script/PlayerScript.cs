﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class PlayerScript : MonoBehaviour {
	Rigidbody m_rb;
	float m_deadZone = 0.1f;
	//float m_gravity = 9.8f;
	float distanceHover = 100.0f;
	//Hover
	public float m_hoverForce = 9.0f;
	public float m_hoverHeight = 2.0f;
	public GameObject[] m_hoverPoints;
	//Forward
	float m_currThrust = 0.0f;

	//Turn
	public float m_turnStrength = 10.0f;
	float m_currTurn = 0.0f;

	int m_layerMask;
	private Vector3 m_gravity = new Vector3 (0,-1,0);

	public int numberLaps = 0;
	private Stats stats;
	// Use this for initialization
	void Start () {
		m_rb = GetComponent<Rigidbody> ();
		m_layerMask = 1 << LayerMask.NameToLayer ("Characters");
		m_layerMask = ~m_layerMask;
		stats = GameObject.Find("Player").GetComponent<Stats>();
	}
	
	// Update is called once per frame
	void Update () {
		m_currThrust = 0.0f;
		float accAxis = Input.GetAxis("Vertical");
		if (accAxis >= m_deadZone) {
			aumentarVelocidad();
			m_currThrust = accAxis * stats.currentVelocity;
		}
		else if (accAxis <= -m_deadZone) {
			reducirVelocidad();
			m_currThrust = accAxis * stats.currentVelocity;
		}
		else {
			if (stats.currentVelocity > 0) stats.currentVelocity = Mathf.Max(stats.currentVelocity - stats.desacc*Time.deltaTime,0);
			else if (stats.currentVelocity < 0) stats.currentVelocity = Mathf.Min(stats.currentVelocity + stats.acc*Time.deltaTime,0);
		}
		//Turning
		m_currTurn = 0.0f;
		float turnAxis = Input.GetAxis ("Horizontal");
		if (Mathf.Abs (turnAxis) > m_deadZone)
			m_currTurn = turnAxis;
	}
	
	void aumentarVelocidad() {
		float delta = stats.acc * Time.deltaTime;
		stats.currentVelocity = Mathf.Min(stats.currentVelocity + delta,stats.maxVelocity);
	}
	
	void reducirVelocidad() {
		float delta = stats.desacc * Time.deltaTime;
		stats.currentVelocity = Mathf.Max(stats.currentVelocity - delta,stats.maxBackVelocity);
	}
	
	void FixedUpdate() {
		Vector3 grav_force = m_gravity * m_rb.mass * 18.81f;
		m_rb.AddForce (grav_force);

		RaycastHit hit;
		for (int i = 0; i < m_hoverPoints.Length; i++) {
			GameObject hov = m_hoverPoints [i];
			if (Physics.Raycast( hov.transform.position, -hov.transform.up, out hit, m_hoverHeight, m_layerMask)) {
				if (hit.distance < distanceHover) {
					m_rb.AddForceAtPosition (hov.transform.up * m_hoverForce * (1.0f - (hit.distance / m_hoverHeight)), hov.transform.position);
				}
				else if (distanceHover < hit.distance) {
					m_rb.AddForceAtPosition (m_gravity, hov.transform.position);
				}
				m_gravity = -transform.up;
			}
			else {
				if (transform.position.y > hov.transform.position.y)
					m_rb.AddForceAtPosition (hov.transform.up * m_hoverForce, hov.transform.position);
				else
					m_rb.AddForceAtPosition (hov.transform.up * -m_hoverForce, hov.transform.position);
			}
		}

		if (m_currThrust > 0)
			m_rb.AddForce (transform.forward*m_currThrust);
		else if (m_currThrust < 0)
			m_rb.AddForce (transform.forward*m_currThrust*-1);

		if (m_currTurn > 0)
			m_rb.AddRelativeTorque (Vector3.up * m_currTurn * m_turnStrength);
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
		}
	}
}


