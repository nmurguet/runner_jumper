using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_floor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "sensor")
		{
			transform.position = new Vector3(transform.position.x+128,transform.position.y,transform.position.z);
			Debug.Log ("hola");

		}


	}
}



