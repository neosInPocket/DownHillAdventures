using System.Collections;
using UnityEngine;

public class BallDesk : MonoBehaviour
{
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private float[] lifeTimes;
	[SerializeField] private PhysicsMaterial2D material;
	public Vector2 Size => spriteRenderer.bounds.size;
	private Color currentColor = Color.white;

	private float lifeTime;

	private void Start()
	{
		lifeTime = lifeTimes[HillSaver.Instance.continueUpgrade];
	}

	public void SetDesk()
	{
		spriteRenderer.color = Color.white;
		var collider = gameObject.AddComponent<PolygonCollider2D>();
		collider.autoTiling = true;
		collider.sharedMaterial = material;
		//StartCoroutine(StartDisappear());
	}

	private IEnumerator StartDisappear()
	{
		while (currentColor.a > 0)
		{
			currentColor.a -= Time.deltaTime / lifeTime;
			spriteRenderer.color = currentColor;
			yield return null;
		}

		currentColor.a = 0;
		spriteRenderer.color = currentColor;
		Destroy(gameObject);
	}
}
