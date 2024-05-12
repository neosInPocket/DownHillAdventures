using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class PlatformsInstantiator : MonoBehaviour
{
	[SerializeField] private BallDesk ballDesk;
	[SerializeField] private CrossBuild crossBuild;
	private Vector2 currentCenterPosition;
	private BallDesk currentDesk;
	private bool isAllowedToBuild;

	private void Awake()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
	}

	public void EnableTouch()
	{
		Touch.onFingerDown += TouchStart;
		Touch.onFingerMove += TouchMove;
		Touch.onFingerUp += TouchRelease;
	}

	public void DisableTouch()
	{
		Touch.onFingerDown -= TouchStart;
		Touch.onFingerUp -= TouchRelease;
		Touch.onFingerMove -= TouchMove;
	}

	private void TouchStart(Finger finger)
	{
		var position = HillSaver.Instance.FingerToScreen(finger) + (Vector2)Camera.main.transform.position;

		Collider2D[] colliders = Physics2D.OverlapBoxAll(position, ballDesk.Size, 0);
		// if (colliders.Any())
		// {
		// 	InstantiateCross(position);
		// 	return;
		// }

		var platform = Instantiate(ballDesk, position, Quaternion.identity, transform);
		currentDesk = platform;
		currentCenterPosition = position;
		isAllowedToBuild = true;
	}

	public void InstantiateCross(Vector2 position)
	{
		Instantiate(crossBuild, position, Quaternion.identity, transform);
	}

	private void TouchMove(Finger finger)
	{
		if (!isAllowedToBuild) return;
		currentDesk.transform.up = HillSaver.Instance.FingerToScreen(finger) - currentCenterPosition + (Vector2)Camera.main.transform.position;
	}

	private void TouchRelease(Finger finger)
	{
		if (!isAllowedToBuild) return;
		isAllowedToBuild = false;
		currentDesk.SetDesk();
	}

	private void OnDestroy()
	{
		Touch.onFingerDown -= TouchStart;
		Touch.onFingerUp -= TouchRelease;
		Touch.onFingerMove -= TouchMove;
	}
}
