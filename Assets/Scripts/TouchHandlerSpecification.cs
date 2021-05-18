using UnityEngine;
using UnityEngine.UI;

public class TouchHandlerSpecification : MonoBehaviour
{
	[SerializeField] private GameObject specificationUI;
	[SerializeField] private Text text;
	[SerializeField] private string specification = "Specification";
	[SerializeField] private float displayTime;

	private void OnMouseDown()
	{
		text.text = specification;
		specificationUI.gameObject.SetActive(true);

		Invoke(nameof(SetActive), displayTime);
	}

	private void SetActive()
	{
		specificationUI.gameObject.SetActive(false);
	}
}
