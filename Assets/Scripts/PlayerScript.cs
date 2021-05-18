using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour
{
	[SerializeField] public ValueBar healthPlayer;
	[SerializeField] private float maxHealth = 100f;
	[SerializeField] private float currentHealth = 100f;

	[SerializeField] public ValueBar experiencePlayer;
	[SerializeField] private float maxExperience = 1000f;
	[SerializeField] private float currentExperience = 0;

	public LayerMask whatCanBeClickedOn;
	private NavMeshAgent myAgent;

	private void Start()
	{
		healthPlayer.Setup(currentHealth, maxHealth);
		experiencePlayer.Setup(currentExperience, maxExperience);

		myAgent = GetComponent<NavMeshAgent>();
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;

			if (Physics.Raycast(myRay, out hitInfo, 100, whatCanBeClickedOn))
			{
				myAgent.SetDestination(hitInfo.point);
			}
		}

		if (healthPlayer.slider.value <= 0)
			FindObjectOfType<GameManager>().EndGame();
	}
}
