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
		//Fires if player can shoot
		if(!canShoot)
		{
			return;
		}
		Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        canShoot = false;

		//Start cooldown
        StartCoroutine(CoolDown());
	}

	//Sets canShoot after an amount of time
	private IEnumerator CoolDown()
	{
		yield return new WaitForSeconds(coolDown);
        canShoot = true;
	}
}
