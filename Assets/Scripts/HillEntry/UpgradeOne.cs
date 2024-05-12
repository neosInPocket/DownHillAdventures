using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeOne : MonoBehaviour
{
	[SerializeField] private Image fill;
	[SerializeField] private TMP_Text amount;
	[SerializeField] private Button purchase;
	[SerializeField] private Image purchaseImage;
	[SerializeField] private Sprite plus;
	[SerializeField] private Sprite noPlus;
	[SerializeField] private GameObject noPlusImage;
	[SerializeField] private UpgradeOne otherUpgradeOne;
	[SerializeField] private InfoSaver infoSaver;
	[SerializeField] private List<EnergySaver> energySavers;
	[SerializeField] private int saveCost;
	[SerializeField] private TMP_Text energyCostValue;
	[SerializeField] private int isEntry;

	private void Start()
	{
		HillRefresh();
	}

	public void HillRefresh()
	{
		int entryAmount = isEntry == 0 ? HillSaver.Instance.entryUpgrade : HillSaver.Instance.continueUpgrade;
		fill.fillAmount = (float)entryAmount / (float)10;
		amount.text = $"{entryAmount}/{10}";
		energyCostValue.text = saveCost.ToString();

		if (entryAmount == 10)
		{
			purchase.interactable = false;
			purchaseImage.sprite = plus;
			noPlusImage.SetActive(false);
		}
		else
		{
			if (HillSaver.Instance.currentEnergy >= saveCost)
			{
				purchase.interactable = true;
				purchaseImage.sprite = plus;
				noPlusImage.SetActive(false);
			}
			else
			{
				purchase.interactable = false;
				purchaseImage.sprite = noPlus;
				noPlusImage.SetActive(true);
			}
		}
	}

	public void UpdateSideInformation()
	{
		infoSaver.SaveInfoUpgrades();
		energySavers.ForEach(x => x.SetEnergy());
	}

	public void SetPurchased()
	{
		HillSaver.Instance.IncreaseOneUpgrade(saveCost, isEntry == 0);
		HillRefresh();
		otherUpgradeOne.HillRefresh();
		UpdateSideInformation();
	}
}
