using UnityEngine;
using Cinemachine;

[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")]
public class HoldZeroPosition : CinemachineExtension
{
	[SerializeField] private float z;

	protected override void PostPipelineStageCallback(
		CinemachineVirtualCameraBase vcam,
		CinemachineCore.Stage currentStage, ref CameraState currentState, float time)
	{
		if (currentStage == CinemachineCore.Stage.Body)
		{
			var currentPosition = currentState.RawPosition;
			currentPosition.x = 0f;
			currentPosition.z = z;
			currentState.RawPosition = currentPosition;
		}
	}
}