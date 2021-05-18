using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandlerDestroyEnemy : MonoBehaviour
{
	[SerializeField] private GameObject Enemy;
	[SerializeField] private int HealthEnemy;

	private void OnMouseDown()
	{
		if (--HealthEnemy <= 0)
			Destroy(Enemy);
	}
}
