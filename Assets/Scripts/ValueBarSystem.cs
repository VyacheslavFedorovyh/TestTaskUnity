using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class ValueEvent : UnityEvent<float> { }

[System.Serializable]
public class ValueBarSystem
{
	[SerializeField] private ValueEvent ValueCganget = new ValueEvent();

	private int value;
	private int valueMax;

	public void Setup(int inValue, int inValueMax)
	{
		value = inValue;
		valueMax = inValueMax;
		SayChanged();
	}

	public void AddValue(int inValue)
	{
		value += inValue;
		if (value > valueMax) value = valueMax;
		SayChanged();
	}

	public void RemoveValue(int inValue)
	{
		value -= inValue;
		if (value < 0) value = 0;
		SayChanged();
	}

	private void SayChanged()
	{
		ValueCganget.Invoke((float)value / valueMax);
	}
}