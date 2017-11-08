using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
	public GameObject win;
	public float horizontalSpeed = 5.0F;
	public float verticalSpeed = 5.0F;
	public static bool winStatus = false;
	public GameObject obj;
	bool isShiftKeyDown;

	// Use this for initialization
	void Start () {
		obj = GameObject.Find(this.obj.name);
		win.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		isShiftKeyDown = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
		checkPosition ();
		if (winStatus == false)
			rotateObject ();
		else
			win.SetActive (true);
	}

	void rotateObject(){
		switch (obj.name){
		case "elephant":
			if (Input.GetMouseButton (0)) {
				float x = horizontalSpeed * Input.GetAxis ("Mouse X");
				float y = verticalSpeed * Input.GetAxis ("Mouse Y");
				transform.eulerAngles += new Vector3 (x, y, 0);
			}
			break;
		case "tea_pot" : 
			if (Input.GetMouseButton (0)) {
				float y = verticalSpeed * Input.GetAxis ("Mouse Y");
				transform.eulerAngles += new Vector3 (0, y, 0);
			}
			break;
		case "42_obj":
		case "logo-4":
		case "logo-2": 
			if (Input.GetMouseButton (0)) {
				obj = GameObject.Find("logo-4");
				float x = horizontalSpeed * Input.GetAxis ("Mouse X");
				float y = verticalSpeed * Input.GetAxis ("Mouse Y");
				obj.transform.eulerAngles += new Vector3 (x, y, 0);
			} else if (Input.GetMouseButton (1)) {
				obj = GameObject.Find("logo-2");
				float x = horizontalSpeed * Input.GetAxis ("Mouse X");
				float y = verticalSpeed * Input.GetAxis ("Mouse Y");
				obj.transform.eulerAngles += new Vector3 (x, y, 0);
			}else if (Input.GetMouseButton(2)) {
				obj = GameObject.Find("42_obj");
				float x = horizontalSpeed * Input.GetAxis ("Mouse X");
			//	float z = verticalSpeed * Input.GetAxis ("Mouse Y");
				transform.eulerAngles += new Vector3 (x, 0, 0);
			}
			break;
		}
	}
	void checkPosition(){
		bool four = false;
		bool two = false;
		bool objstatus = false;
		switch (obj.name) {
		case "elephant": 
			if ((transform.eulerAngles.x >= 80 && transform.eulerAngles.x <= 100)
			    && (transform.eulerAngles.y >= 95 && transform.eulerAngles.y <= 100
			    || transform.eulerAngles.y >= -100 && transform.eulerAngles.y <= -95)) {
				winStatus = true;
			}
			break;
		case "tea_pot": 
			if (transform.eulerAngles.y >= 80 && transform.eulerAngles.y <= 90) {
				winStatus = true;
			}
			break;
		case "42_obj":
		case "logo-4":
		case "logo-2": 
			if (obj.name == "42_obj" && transform.eulerAngles.x >= 5 && transform.eulerAngles.x <= 15) {
				objstatus = true;
				Debug.Log ("42 obj =" + objstatus);
			}
			if (obj.name == "logo-2" && (obj.transform.eulerAngles.x >= -170 && obj.transform.eulerAngles.x <= -190)
			           && (obj.transform.eulerAngles.y <= -80 && obj.transform.eulerAngles.y >= -90
			           || obj.transform.eulerAngles.z >= 165 && obj.transform.eulerAngles.z <= 175)) {
				two = true;
				Debug.Log ("two staus = " + two);
			}
			if (obj.name == "logo-4" && (obj.transform.eulerAngles.x >= -175 && obj.transform.eulerAngles.x <= -190)
			         && (obj.transform.eulerAngles.y <= -80 && obj.transform.eulerAngles.y >= -90
			         || obj.transform.eulerAngles.y >= 165 && obj.transform.eulerAngles.y <= 175)) {
				four = true;
				Debug.Log ("four staus = " + four);
			}
			if (four == true && two == true && objstatus == true) {
				winStatus = true;
			} else {
				four = false;
				two = false;
				objstatus = false;
			}
			break;
		}
	}
}