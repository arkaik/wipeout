using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoToMenu() {
		SceneManager.LoadScene("menu");
	} 
}
