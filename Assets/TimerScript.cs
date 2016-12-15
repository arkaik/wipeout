using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScript : MonoBehaviour {

	private Text target;
	private float seconds;
	private int minutes;
	private int hours;
	// Use this for initialization
	void Start () {
		target = gameObject.GetComponent<Text> ();
		target.text = "00:00:00";

		seconds = 0;
		minutes = 0;
		hours = 0;
	}
	
	// Update is called once per frame
	void Update () {
		seconds += Time.deltaTime;
		if (seconds > 60) {
			seconds -= 60;
			minutes += 1;
		}

		if (minutes > 60) {
			minutes -= 60;
			hours += 1;
		}

		int sec = (int) seconds;
		string c = "";
		if (sec < 10)
			c = "0" + sec;
		else
			c = sec.ToString ();

		string b = "";
		if (minutes < 10)
			b = "0" + minutes;
		else
			b = minutes.ToString ();

		string a = "";
		if (hours < 10)
			a = "0" + hours;
		else
			a = hours.ToString ();

		target.text = a+ ":" + b + ":" + c;
	}
}
