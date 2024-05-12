using TMPro;
using UnityEngine;

public class InfoSaver : MonoBehaviour
{
	[SerializeField] private TMP_Text firstOne;
	[SerializeField] private TMP_Text secondOne;

	private void Start()
	{
		SaveInfoUpgrades();
	}

	public void SaveInfoUpgrades()
	{
		firstOne.text = $"{HillSaver.Instance.entryUpgrade}/10";
		secondOne.text = $"{HillSaver.Instance.continueUpgrade}/10";
	}
}
