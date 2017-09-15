using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_manager : MonoBehaviour {

	private Rigidbody2D rb; 

	private Animator anim; 


	public float moveSpeed; 

	public float jumpForce; 

	private float store_grav; 
	private float jump_grav = 0.1f;

	//groundeck stuff

	public Transform groundCheckPoint; 
	public bool isGrounded; 
	public float groundCheckRadius; 
	public LayerMask whatIsGround; 



	//Timer

	public float timer; 
	private float store_timer; 



	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> (); 
		anim = GetComponent<Animator> (); 

		store_grav = rb.gravityScale; 

		store_timer = timer; 
	}
	
	// Update is called once per frame
	void Update () {
		ManageAnimation ();
		Movement (); 
		
	}


	void ManageAnimation()
	{
		//manejo de animacion
		anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
		anim.SetBool ("Grounded", isGrounded);


	}

	void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle (groundCheckPoint.position, groundCheckRadius, whatIsGround);

	}


	void Movement()
	{
		rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);

		if (Input.GetKey (KeyCode.Space)&&isGrounded) {
				timer -= Time.deltaTime;
				if (timer > 0) {
					rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
					rb.gravityScale = jump_grav;
				} else {
					rb.gravityScale = store_grav; 

			
				}
			}

			if (Input.GetKeyUp (KeyCode.Space)) {
				rb.gravityScale = store_grav; 
				timer = store_timer;
			}

		}


}
