using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteScreen : MonoBehaviour
{
	[SerializeField] private TMP_Text reasonText;
	[SerializeField] private TMP_Text lootText;
	[SerializeField] private GameObject lootContainer;
	[SerializeField] private TMP_Text tipText;
	[SerializeField] private TMP_Text skipNextLevelText;
	[SerializeField] private string velocityText;
	[SerializeField] private string popText;

	public void Complete(CompleteReason reason, int loot)
	{
		gameObject.SetActive(true);

		if (reason == CompleteReason.Completed)
		{
			reasonText.text = "LEVEL COMPLETED!";
			lootContainer.gameObject.SetActive(true);
			tipText.gameObject.SetActive(false);
			skipNextLevelText.text = "NEXT LEVEL";
			lootText.text = loot.ToString();

			HillSaver.Instance.currentEnergy += loot;
			HillSaver.Instance.currentLocation++;
			HillSaver.Instance.SaveIntFields();
			return;
		}

		if (reason == CompleteReason.Velocity)
		{
			reasonText.text = "out of speed range!";
			lootContainer.gameObject.SetActive(false);
			tipText.gameObject.SetActive(true);
			tipText.text = velocityText;
			skipNextLevelText.text = "REPLAY";
			lootText.text = loot.ToString();
			return;
		}

		if (reason == CompleteReason.Popped)
		{
			reasonText.text = "CRASHED!";
			lootContainer.gameObject.SetActive(false);
			tipText.gameObject.SetActive(true);
			tipText.text = popText;
			skipNextLevelText.text = "REPLAY";
			lootText.text = loot.ToString();
			return;
		}
	}

	public void SkipNextLevel()
	{
		SceneManager.LoadScene("DownHillContinue");
	}

	public void SkipMenuLevel()
	{
		SceneManager.LoadScene("DownHillEntry");
	}
}

public enum CompleteReason
{
	Completed,
	Velocity,
	Popped
}
