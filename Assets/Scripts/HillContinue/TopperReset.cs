using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TopperReset : MonoBehaviour
{
	[SerializeField] private TMP_Text distanceText;
	[SerializeField] private Image distanceSlider;
	[SerializeField] private TMP_Text lootText;
	[SerializeField] private HookHero hookHero;
	private float targetDistance;

	private void Update()
	{
		distanceText.text = Mathf.Abs(hookHero.currentDistance).ToString("F2") + $"/{targetDistance}";
		distanceSlider.fillAmount = Mathf.Abs(hookHero.currentDistance) / targetDistance;
	}

	public void SetTopperState(int loot, int targetDistance)
	{
		this.targetDistance = targetDistance;
		lootText.text = loot.ToString();
	}
}
