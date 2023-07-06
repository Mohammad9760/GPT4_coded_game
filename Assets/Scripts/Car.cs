using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
	public float minSpeed;
	public float maxSpeed;
	public Vector3 direction;
	private Rigidbody rb;
	private float speed;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		speed = Random.Range(minSpeed, maxSpeed);
	}

	void FixedUpdate()
	{
		rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
	}
}

