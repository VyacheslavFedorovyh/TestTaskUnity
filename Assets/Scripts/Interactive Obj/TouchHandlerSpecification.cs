using UnityEngine;
using UnityEngine.UI;

public class TouchHandlerSpecification : MonoBehaviour
{
	[SerializeField] private GameObject specificationUI;
	[SerializeField] private string specification = "Specification";
	[SerializeField] private float displayTimeindicatorUI = 1.5f;

	private void OnMouseDown()
	{
		specificationUI.GetComponent<Text>().text = specification;
		specificationUI.gameObject.SetActive(true);

		Invoke(nameof(SetActive), displayTimeindicatorUI);
	}

	private void SetActive()
	{
		specificationUI.gameObject.SetActive(false);
	}
}
