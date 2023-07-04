using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 10.0f;
	public float rotateSpeed = 10.0f;
	public float resetSpeed = 1.0f;
	public Transform child;
	private Rigidbody rb;
	private Quaternion originalRotation;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		originalRotation = child.rotation;
	}

	void FixedUpdate()
	{
		if (Input.GetMouseButton(0))
		{
			float moveHorizontal = Input.GetAxis("Mouse X");

			Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

			rb.MovePosition(rb.position + movement * speed * Time.deltaTime);

			float rotateHorizontal = Input.GetAxis("Mouse X");

			Vector3 rotation = new Vector3(0.0f, rotateHorizontal * rotateSpeed, 0.0f);

			child.Rotate(rotation * Time.deltaTime);
		}

		child.rotation = Quaternion.Slerp(child.rotation, originalRotation, resetSpeed * Time.deltaTime);
	}
}
