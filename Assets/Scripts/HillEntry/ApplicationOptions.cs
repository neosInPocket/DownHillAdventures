using UnityEngine;
using UnityEngine.UI;

public class ApplicationOptions : MonoBehaviour
{
	[SerializeField] private Color toggledOff;
	[SerializeField] private Color toggledOn;
	[SerializeField] private Image musicState;
	[SerializeField] private Image effectsState;

	private void Start()
	{
		SetToggleState();
	}

	public void SetToggleState()
	{
		musicState.color = HillBackgoundMusic.instance.EnabledMusic ? toggledOn : toggledOff;
		effectsState.color = HillBackgoundMusic.instance.EnabledEffects ? toggledOn : toggledOff;
	}

	public void ChangeStateMusic()
	{
		HillBackgoundMusic.instance.ToggleHillMusic();
		musicState.color = HillBackgoundMusic.instance.EnabledMusic ? toggledOn : toggledOff;
	}

	public void ChangeStateEffects()
	{
		HillBackgoundMusic.instance.ToggleHillSound();
		effectsState.color = HillBackgoundMusic.instance.EnabledEffects ? toggledOn : toggledOff;
	}
}
