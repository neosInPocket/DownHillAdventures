using UnityEngine;

public class PoppersSpawner : MonoBehaviour
{
	[SerializeField] private BallPopper ballPopper;
	[SerializeField] private Transform initial;
	[SerializeField] private Vector2 between;
	[SerializeField] private float xRanges;

	[SerializeField] private Transform target;
	private Transform currentLast;

	private void Start()
	{
		currentLast = initial;
	}

	private void Update()
	{
		if (target.transform.position.y - 8 < currentLast.transform.position.y)
		{
			Vector2 screenSize = HillSaver.Instance.screenSize;
			float xMaxRestrict = Mathf.Abs(screenSize.x * xRanges - screenSize.x);

			var popperPosition = new Vector2();
			popperPosition.x = Random.Range(-xMaxRestrict, xMaxRestrict);
			popperPosition.y = currentLast.transform.position.y - Random.Range(between.x, between.y);

			currentLast = Instantiate(ballPopper, popperPosition, Quaternion.identity, transform).transform;
		}
	}

}
