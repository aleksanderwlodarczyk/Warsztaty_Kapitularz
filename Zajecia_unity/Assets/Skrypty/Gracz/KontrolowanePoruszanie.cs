using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class KontrolowanePoruszanie : MonoBehaviour {

	private Rigidbody2D rb2d;
	private float horizontal;
	private float speedR;
	private bool canJump;

	public float speed;
	public bool jump;
	public float jumpForce;

	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		speedR = speed;
		canJump = true;
	}

	void Update () {
		horizontal = Input.GetAxis ("Horizontal");
		rb2d.AddForce (Vector2.right * horizontal * speedR);

		if (horizontal * rb2d.velocity.x < 0) {
			speedR = -speed * -2;
		} else {
			speedR = speed;
		}

		if (Input.GetKey (KeyCode.Space) && jump && canJump) {
			rb2d.AddForce (Vector2.up * jumpForce);
			canJump = false;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "ground") {
			canJump = true;
		}
	}
}
