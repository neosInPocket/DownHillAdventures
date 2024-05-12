using UnityEngine;

public class BallPopper : MonoBehaviour
{
	[SerializeField] private SpriteRenderer sp;
	[SerializeField] private Vector2 speeds;
	[SerializeField] private Vector3 rotorValues;
	[SerializeField] private Vector2 sizesForPoppers;
	[SerializeField] private CircleCollider2D coll;
	private float value;
	private int dir;

	private void Start()
	{
		dir = Random.Range(0, 1f) > 0.5f ? -1 : 1;
		value = Random.Range(speeds.x, speeds.y);
		var random = Random.Range(sizesForPoppers.x, sizesForPoppers.y);
		sp.size = new Vector2(random, random);
		coll.radius = random / 2;
	}

	private void Update()
	{
		rotorValues.z += value * dir * Time.deltaTime;
		transform.eulerAngles = rotorValues;
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.TryGetComponent<HookHero>(out HookHero component))
		{
			component.PopHero();
		}
	}
}
