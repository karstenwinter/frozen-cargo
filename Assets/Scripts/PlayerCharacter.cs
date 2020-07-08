using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
	Rigidbody rb;
	
	public float moveSpeed=0.6f;
	public float slowXwhenReleased=0.7f;

	public Transform GroundCheck;
	float jumpTimeCounter;
	void Start()
	{
	   rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		var hor = Input.GetAxis("Horizontal");
		var curHorMove = Mathf.Abs(rb.velocity.x);
		var curVertMove = Mathf.Abs(rb.velocity.z);
		var vert = Input.GetAxis("Vertical");
	
		if(Mathf.Abs(hor) >= 0.01f||Mathf.Abs(vert) >= 0.01f)
		{
			rb.velocity -= Vector3.right*(moveSpeed-curHorMove)*hor;
			rb.velocity -= Vector3.forward*(moveSpeed-curVertMove)*vert;
		} else {
			rb.velocity = new Vector3(rb.velocity.x*slowXwhenReleased, rb.velocity.y, rb.velocity.z*slowXwhenReleased);
		}
	}
}
