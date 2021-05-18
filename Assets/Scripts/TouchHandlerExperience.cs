using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandlerExperience : MonoBehaviour
{
	[SerializeField] private PlayerScript playerScript;
	[SerializeField] private float experiencePoints = 200f;

	private void OnMouseDown()
	{
		playerScript.experiencePlayer.AddValue(experiencePoints);
	}
}
