using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerFire : MonoBehaviour
{
	[SerializeField] GameObject laserPrefab;

	[SerializeField] float coolDown = 1f;
	private bool canShoot = true;

	public void Fire(InputAction.CallbackContext context)
	{
		if(!canShoot)
		{
			return;
		}
		Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        canShoot = false;
        StartCoroutine(CoolDown());
	}

	private IEnumerator CoolDown()
	{
		yield return new WaitForSeconds(coolDown);
        canShoot = true;
	}
}
