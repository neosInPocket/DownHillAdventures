using UnityEngine;

public class CompleteManager : MonoBehaviour
{
	[SerializeField] private PlatformsInstantiator platformsInstantiator;
	[SerializeField] private HookHero hookHero;
	[SerializeField] private EntrySituation entrySituation;
	[SerializeField] private CompleteScreen completeScreen;
	[SerializeField] private OpenGame openGame;
	[SerializeField] private TopperReset topperReset;
	public int location;
	public int targetDistance => (int)(10f * Mathf.Log(location + 1) + location);
	public int levelLoot => (int)(30f * Mathf.Log(location + 1) + location / 2);

	private void Start()
	{
		location = HillSaver.Instance.currentLocation;
		topperReset.SetTopperState(levelLoot, targetDistance);

		if (entrySituation.IsSituationNeeded())
		{
			entrySituation.StartSituation(SituationEnd);
		}
		else
		{
			SituationEnd();
		}
	}

	public void SituationEnd()
	{
		openGame.SetOpen(OnOpenSkipped);
	}

	public void OnOpenSkipped()
	{
		hookHero.SetDependencies(targetDistance);
		ToggleGameState(true);
		hookHero.RB.gravityScale += 0.01f;
		hookHero.colliderCircle.enabled = true;
	}

	public void MaxDistanceReached()
	{
		ToggleGameState(false);
		completeScreen.Complete(CompleteReason.Completed, levelLoot);
	}

	public void HeroVelocityRange()
	{
		ToggleGameState(false);
		completeScreen.Complete(CompleteReason.Velocity, levelLoot);
	}

	public void HeroPopped()
	{
		ToggleGameState(false);
		completeScreen.Complete(CompleteReason.Popped, levelLoot);
	}

	public void ToggleGameState(bool toggle)
	{
		if (toggle)
		{
			hookHero.ReleaseBall(true);
			platformsInstantiator.EnableTouch();

			hookHero.HeroDistanceReached += MaxDistanceReached;
			hookHero.HeroVelocityRange += HeroVelocityRange;
			hookHero.HeroPopped += HeroPopped;
		}
		else
		{
			hookHero.ReleaseBall(false);
			platformsInstantiator.DisableTouch();

			hookHero.HeroDistanceReached -= MaxDistanceReached;
			hookHero.HeroVelocityRange -= HeroVelocityRange;
			hookHero.HeroPopped -= HeroPopped;
		}
	}

	private void OnDestroy()
	{
		hookHero.HeroDistanceReached -= MaxDistanceReached;
		hookHero.HeroVelocityRange -= HeroVelocityRange;
		hookHero.HeroPopped -= HeroPopped;
	}
}
