using UnityEngine;

public class TilingAnimator : MonoBehaviour
{
	public float speed = 1f;
	public Vector2 direction = Vector2.right;

	private Renderer renderer;

	void Start()
	{
		renderer = GetComponent<Renderer>();
	}

	void Update()
	{
		float offset = Time.time * speed;
		Vector2 offsetVector = direction * offset;
		renderer.material.mainTextureOffset = offsetVector;
	}
}
