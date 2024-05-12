using UnityEngine;

public class HillSaver : MonoBehaviour
{
	[SerializeField] private float defaultHills;
	public static HillSaver Instance;

	public int currentLocation;
	public int currentEnergy;
	public int entryUpgrade;
	public int continueUpgrade;
	public int musicAmplitude;
	public int soundsAmplitude;
	public int hillInstructions;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}

		if (defaultHills > 0)
		{
			DefaultIntFields();
			SaveIntFields();
		}
		else
		{
			LoadIntFields();
		}
	}

	public void DefaultIntFields()
	{
		PlayerPrefs.DeleteAll();

		currentLocation = 1;
		currentEnergy = 50;
		entryUpgrade = 0;
		continueUpgrade = 0;
		musicAmplitude = 1;
		soundsAmplitude = 1;
		hillInstructions = 1;
	}

	public void SaveIntFields()
	{
		PlayerPrefs.SetInt("currentLocation", currentLocation);
		PlayerPrefs.SetInt("currentBrilliants", currentEnergy);
		PlayerPrefs.SetInt("entryUpgrade", entryUpgrade);
		PlayerPrefs.SetInt("continueUpdgrade", continueUpgrade);
		PlayerPrefs.SetInt("musicAmplitude", musicAmplitude);
		PlayerPrefs.SetInt("soundsAmplitude", soundsAmplitude);
		PlayerPrefs.SetInt("hillInstructions", hillInstructions);
		PlayerPrefs.Save();
	}

	public void IncreaseOneUpgrade(int cost, bool isEntry)
	{
		currentEnergy -= cost;

		if (isEntry)
		{
			entryUpgrade++;
		}
		else
		{
			continueUpgrade++;
		}

		SaveIntFields();
	}

	public void LoadIntFields()
	{
		currentLocation = PlayerPrefs.GetInt("IntField1", 0);
		currentEnergy = PlayerPrefs.GetInt("IntField2", 0);
		entryUpgrade = PlayerPrefs.GetInt("IntField3", 0);
		continueUpgrade = PlayerPrefs.GetInt("IntField4", 0);
		musicAmplitude = PlayerPrefs.GetInt("IntField5", 0);
		soundsAmplitude = PlayerPrefs.GetInt("IntField6", 0);
		hillInstructions = PlayerPrefs.GetInt("IntField7", 0);
	}
}
