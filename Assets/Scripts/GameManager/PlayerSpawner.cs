using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
	[SerializeField] GameObject playerPrefab;

	public void SpawnPlayer()
	{
		Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
	}
}
