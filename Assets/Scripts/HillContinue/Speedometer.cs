using System;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
	[SerializeField] private Image imageFill;
	[SerializeField] private HookHero hookHero;

	private void Update()
	{
		imageFill.fillAmount = Map(Math.Abs(hookHero.verticalVelocty), hookHero.MinSpeeds.x, hookHero.MinSpeeds.y, 0, 1f);
	}

	public float Map(float value, float fromMin, float fromMax, float toMin, float toMax)
	{
		if (value < fromMin)
		{
			value = fromMin;
		}
		else if (value > fromMax)
		{
			value = fromMax;
		}

		return (value - fromMin) * (toMax - toMin) / (fromMax - fromMin) + toMin;
	}
}
