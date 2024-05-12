using System;
using TMPro;
using UnityEngine;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using Finger = UnityEngine.InputSystem.EnhancedTouch.Finger;

public class EntrySituation : MonoBehaviour
{
	[SerializeField] private Animator animationController;
	[SerializeField] private TMP_Text text;
	[SerializeField] private string[] allStringsValues;
	private int indexPosition;
	Action situationEnded;

	public bool IsSituationNeeded()
	{
		bool need = HillSaver.Instance.hillInstructions > 0;
		if (need)
		{
			HillSaver.Instance.hillInstructions = 0;
			HillSaver.Instance.SaveIntFields();
			return true;
		}

		return false;
	}

	public void StartSituation(Action situationEnded)
	{
		gameObject.SetActive(true);

		this.situationEnded = situationEnded;
		Touch.onFingerDown += SampleAction;
		SampleAction();
	}

	private void SampleAction(Finger finger)
	{
		if (indexPosition >= allStringsValues.Length)
		{
			OnEnd();
			return;
		}

		text.text = allStringsValues[indexPosition];
		animationController.SetTrigger("playSituation");
		indexPosition++;
	}

	public void SampleAction()
	{
		text.text = allStringsValues[indexPosition];
		animationController.SetTrigger("playSituation");
		indexPosition++;
	}

	public void OnEnd()
	{
		Touch.onFingerDown -= SampleAction;
		situationEnded?.Invoke();
		gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		Touch.onFingerDown -= SampleAction;
	}
}
