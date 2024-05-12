using TMPro;
using UnityEngine;

public class EnergySaver : MonoBehaviour
{
	[SerializeField] private TMP_Text mainText;

	private void Start()
	{
		SetEnergy();
	}

	public void SetEnergy()
	{
		mainText.text = HillSaver.Instance.currentEnergy.ToString();
	}
}
