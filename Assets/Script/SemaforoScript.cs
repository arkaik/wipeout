using UnityEngine;
using System.Collections;

public class SemaforoScript : MonoBehaviour {
	
	GameObject circulo1,circulo2,circulo3;
	public bool empezar;
	private float contador;

	// Use this for initialization
	void Start () {
		empezar = false;
		contador = 0f;
		circulo1 = GameObject.Find("Circle001");
		circulo2 = GameObject.Find("Circle002");
		circulo3 = GameObject.Find("Circle003");
	}
	
	// Update is called once per frame
	void Update () {
		if (!empezar) {
			if (contador >= 0 && contador < 3) {
				circulo1.GetComponent<Renderer>().material.color = Color.red;
			}
			else if (contador >= 3 && contador < 6) {
				circulo2.GetComponent<Renderer>().material.color = Color.red;
			}
			else if (contador >= 9 && contador < 12) {
				circulo3.GetComponent<Renderer>().material.color = Color.red;
			}
			else {
				circulo1.GetComponent<Renderer>().material.color = Color.green;	
				circulo2.GetComponent<Renderer>().material.color = Color.green;	
				circulo3.GetComponent<Renderer>().material.color = Color.green;
				empezar = true;
			}
			contador += Time.deltaTime;
		}
	}
}
