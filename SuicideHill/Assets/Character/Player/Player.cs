using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	public float jumpHeight;
	public bool isJumping = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		if(Input.GetKeyDown (KeyCode.Space)){ 
			if(isJumping == false)
			{
			rb.AddForce(Vector2.up * jumpHeight);
				isJumping = true;
				Debug.Log ("jumping  = " + isJumping);

				//OnCollisionEnter2D (col);
			}
		}
	}
	private void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Platform") // GameObject is a type, gameObject is the property
		{
			isJumping = false;
			Debug.Log ("jumping again  = " + isJumping);

		}
	}
}