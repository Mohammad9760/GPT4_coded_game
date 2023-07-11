using UnityEngine;

public class PassBySFX : MonoBehaviour
{
	public AudioSource audioSource;
	public AudioClip audioClip;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<Car>() != null)
		{
			audioSource.PlayOneShot(audioClip);
		}
	}
}
