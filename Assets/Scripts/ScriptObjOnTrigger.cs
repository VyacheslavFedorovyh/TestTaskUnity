using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptObjOnTrigger : MonoBehaviour
{
	[SerializeField] private GameObject indicatorUI;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
			indicatorUI.gameObject.SetActive(true);
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
			indicatorUI.gameObject.SetActive(false);
	}
}
