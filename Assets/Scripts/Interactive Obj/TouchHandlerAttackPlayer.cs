using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandlerAttackPlayer : MonoBehaviour
{
	[SerializeField] private PlayerScript playerScript;
	[SerializeField] private float healthPoints = 10f;

	private void OnMouseDown()
	{
		playerScript.healthPlayer.RemoveValue(healthPoints);			
	}
}
