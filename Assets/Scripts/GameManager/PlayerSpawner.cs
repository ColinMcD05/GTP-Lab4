using Unity.Cinemachine;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
	//References
	[SerializeField] GameObject playerPrefab;
	[SerializeField] CinemachineCamera cinCam;
	public GameObject player;

	public void SpawnPlayer()
	{
		player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

		// Makes Camera follow the player
		if (cinCam != null)
		{
			cinCam.Target.TrackingTarget = player.transform;
		}
	}
}
