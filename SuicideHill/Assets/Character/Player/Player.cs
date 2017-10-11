using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	public float jumpHeight;
	public bool isJumping = false;

	public float maxSpeed = 25f;
	public Rigidbody2D bullet;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		movePlayer ();
	}

	void movePlayer(){

		Rigidbody2D rb = GetComponent<Rigidbody2D> ();

		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			transform.Translate (Vector2.right * 2 * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,0); 
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (Vector2.right * 2 * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 180);
		}

		if(Input.GetKeyDown (KeyCode.Space)){ 
			if(isJumping == false)
			{
				rb.AddForce(Vector2.up * jumpHeight);
				isJumping = true;
			}

		}
		if (Input.GetButtonDown("Fire1"))
		{
			Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 1))) as Rigidbody2D;
			bulletInstance.velocity = transform.forward * maxSpeed;

			Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(),  GetComponent<Collider2D>());
	}

	}

	private void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "platform") // GameObject is a type, gameObject is the property
		{
			isJumping = false;
		}
	}
}