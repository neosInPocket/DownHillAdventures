using UnityEngine;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using Finger = UnityEngine.InputSystem.EnhancedTouch.Finger;
using System;

public class OpenGame : MonoBehaviour
{
	[SerializeField] private CompleteManager completeManager;
	private Action openSkippedAction;

	public void SetOpen(Action openSkipped)
	{

		gameObject.SetActive(true);
		openSkippedAction = openSkipped;
		Touch.onFingerDown += Skip;
	}

	public void Skip(Finger finger)
	{
		openSkippedAction?.Invoke();
		Touch.onFingerDown -= Skip;
		gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		Touch.onFingerDown -= Skip;
	}
}
