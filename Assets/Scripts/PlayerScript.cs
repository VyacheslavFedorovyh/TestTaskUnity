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
	public PlayerValue playerValue;
	private NavMeshAgent myAgent;

	private void Start()
	{
		transform.position = playerValue.initialValye;
		currentHealth = playerValue.currentHealth != 0 ? playerValue.currentHealth : currentHealth;
		currentExperience = playerValue.currentExperience != 0 ? playerValue.currentExperience : currentExperience;

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
		{
			FindObjectOfType<GameManager>().EndGame();
			OnApplicationQuit();
		}
	}

	public void PositionVectorValue()
	{
		playerValue.initialValye = transform.position;
		playerValue.currentHealth = healthPlayer.slider.value;
		playerValue.currentExperience = experiencePlayer.slider.value;
	}

	void OnApplicationQuit()
	{
		playerValue.initialValye = Vector3.zero;
		playerValue.currentHealth = 0;
		playerValue.currentExperience = 0;
	}
}
