using System;
using UnityEngine;

public class HillBackgoundMusic : MonoBehaviour
{
	public static HillBackgoundMusic instance;
	private AudioSource audioSource;
	public bool EnabledMusic { get; set; }
	public bool EnabledEffects { get; set; }

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = HillSaver.Instance.musicAmplitude;
		EnabledMusic = audioSource.volume > 0;
		EnabledEffects = HillSaver.Instance.soundsAmplitude > 0;
	}

	public void ToggleHillMusic()
	{
		if (audioSource.volume == 0)
		{
			audioSource.volume = 1;
		}
		else
		{
			audioSource.volume = 0f;
		}

		HillSaver.Instance.musicAmplitude = (int)audioSource.volume;
		HillSaver.Instance.SaveIntFields();
		EnabledMusic = HillSaver.Instance.musicAmplitude > 0;
	}

	public void ToggleHillSound()
	{
		if (HillSaver.Instance.soundsAmplitude == 0)
		{
			HillSaver.Instance.soundsAmplitude = 1;
		}
		else
		{
			HillSaver.Instance.soundsAmplitude = 0;
		}

		HillSaver.Instance.SaveIntFields();
		EnabledEffects = HillSaver.Instance.soundsAmplitude > 0;
	}
}
