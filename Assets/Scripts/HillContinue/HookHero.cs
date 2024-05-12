using System;
using System.Collections.Generic;
using UnityEngine;

public class HookHero : MonoBehaviour
{
	[SerializeField] private Rigidbody2D movingEngine;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private GameObject blow;
	[SerializeField] private List<float> gravityScalesUpgrades;
	[SerializeField] private CircleCollider2D ballCollider;
	[SerializeField] private Vector2[] minSpeedsUpgrades;
	private Vector2 minSpeeds;
	public float verticalVelocty => movingEngine.velocity.y;
	public float currentDistance => transform.position.y;
	public Action HeroPopped { get; set; }
	public Action HeroVelocityRange { get; set; }
	public Action HeroDistanceReached { get; set; }
	private float targetDistance;
	private Vector2 screenSize;
	public Vector2 MinSpeeds => minSpeeds;
	public Rigidbody2D RB => movingEngine;
	public CircleCollider2D colliderCircle => ballCollider;

	private void Start()
	{
		movingEngine.gravityScale = gravityScalesUpgrades[HillSaver.Instance.entryUpgrade];
		minSpeeds = minSpeedsUpgrades[HillSaver.Instance.continueUpgrade];
		screenSize = HillSaver.Instance.screenSize;
	}

	private void Update()
	{
		if (Mathf.Abs(currentDistance) > targetDistance)
		{
			HeroDistanceReached?.Invoke();
			ReleaseBall(false);
			ballCollider.enabled = false;
		}

		if (transform.position.x - ballCollider.radius < -screenSize.x || transform.position.x + ballCollider.radius > screenSize.x)
		{
			PopHero();
		}

		if ((Mathf.Abs(movingEngine.velocity.y) < minSpeeds.x || Mathf.Abs(movingEngine.velocity.y) > minSpeeds.y) && transform.position.y < -0.5f)
		{
			PopHeroVelocity();
		}
	}

	public void SetDependencies(float targetDistance)
	{
		this.targetDistance = targetDistance;
	}

	public void ReleaseBall(bool value)
	{
		if (value)
		{
			movingEngine.constraints = RigidbodyConstraints2D.None;
		}
		else
		{
			movingEngine.constraints = RigidbodyConstraints2D.FreezeAll;
		}
	}

	public void PopHero()
	{
		blow.gameObject.SetActive(true);
		ReleaseBall(false);
		spriteRenderer.enabled = false;
		ballCollider.enabled = false;
		HeroPopped?.Invoke();
	}

	public void PopHeroVelocity()
	{
		blow.gameObject.SetActive(true);
		ReleaseBall(false);
		spriteRenderer.enabled = false;
		ballCollider.enabled = false;
		HeroVelocityRange?.Invoke();
	}
}
