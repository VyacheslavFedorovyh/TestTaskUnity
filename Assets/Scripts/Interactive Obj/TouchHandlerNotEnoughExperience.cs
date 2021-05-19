using UnityEngine;

public class TouchHandlerNotEnoughExperience : MonoBehaviour
{
	[SerializeField] private PlayerScript playerScript;
	[SerializeField] private GameObject indicatorUI;
	[SerializeField] private float experiencePlayer;
	[SerializeField] private float displayTimeindicatorUI = 1.5f;

	private void OnMouseDown()
	{
		if ( playerScript.experiencePlayer.slider.value > experiencePlayer )
			return;

		indicatorUI.gameObject.SetActive(true);
		Invoke(nameof(SetActive), displayTimeindicatorUI);
	}

	private void SetActive()
	{
		indicatorUI.gameObject.SetActive(false);
	}
}
