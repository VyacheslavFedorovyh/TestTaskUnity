using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ValueBar : MonoBehaviour
{
	[SerializeField] public Slider slider;

	public void Setup(float value, float maxValue)
	{
		slider.value = value;
		slider.maxValue = maxValue;
	}

	public void AddValue(float value)
	{
		slider.value += value;
	}

	public void RemoveValue(float value)
	{
		slider.value -= value;
	}
}
