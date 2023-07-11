using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomPrefab : MonoBehaviour
{
	public List<GameObject> prefabs;
	public List<Transform> spawnPoints;
	public float minDelay = 1f;
	public float maxDelay = 3f;
	public Vector3 rotation = new Vector3(-90f, 0f, 90f);
	public int poolSize = 10;

	private List<GameObject> objectPool;

	void Start()
	{
		objectPool = new List<GameObject>();

		for (int i = 0; i < poolSize; i++)
		{
			int randomIndex = Random.Range(0, prefabs.Count);
			GameObject prefab = prefabs[randomIndex];

			GameObject obj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
			obj.SetActive(false);

			objectPool.Add(obj);
		}

		StartCoroutine(SpawnPrefabs());
	}

	IEnumerator<object> SpawnPrefabs()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

			int randomIndex = Random.Range(0, prefabs.Count);
			GameObject prefab = prefabs[randomIndex];

			int randomSpawnIndex = Random.Range(0, spawnPoints.Count);
			Transform spawnPoint = spawnPoints[randomSpawnIndex];

			GameObject obj = GetObjectFromPool();
			obj.transform.position = spawnPoint.position;
			obj.transform.rotation = Quaternion.Euler(rotation);
			obj.SetActive(true);

			StartCoroutine(ReturnObjectToPoolCoroutine(obj));
		}
	}

	GameObject GetObjectFromPool()
	{
		foreach (GameObject o in objectPool)
		{
			if (!o.activeInHierarchy)
			{
				return o;
			}
		}

		int randomIndex = Random.Range(0, prefabs.Count);
		GameObject prefab = prefabs[randomIndex];

		GameObject obj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
		obj.SetActive(false);

		objectPool.Add(obj);

		return obj;
	}

	IEnumerator<object> ReturnObjectToPoolCoroutine(GameObject o)
	{
		yield return new WaitForSeconds(Random.Range(5f, 15f));

		o.SetActive(false);
	}
}
