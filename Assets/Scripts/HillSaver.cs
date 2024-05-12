using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

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
	public Vector2 screenSize;

	private void Awake()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();

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

		screenSize = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize);
	}

	public Vector2 FingerToScreen(Finger finger)
	{
		Vector2 result;
		result.x = 2 * screenSize.x * finger.screenPosition.x / Screen.width - screenSize.x;
		result.y = 2 * screenSize.y * finger.screenPosition.y / Screen.height - screenSize.y;
		return result;
	}

	public void DefaultIntFields()
	{
		currentLocation = 1;
		currentEnergy = 150;
		entryUpgrade = 0;
		continueUpgrade = 0;
		musicAmplitude = 1;
		soundsAmplitude = 1;
		hillInstructions = 1;
	}

	public void SaveIntFields()
	{
		PlayerPrefs.SetInt("currentLocation", currentLocation);
		PlayerPrefs.SetInt("currentEnergy", currentEnergy);
		PlayerPrefs.SetInt("entryUpgrade", entryUpgrade);
		PlayerPrefs.SetInt("continueUpgrade", continueUpgrade);
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
		currentLocation = PlayerPrefs.GetInt("currentLocation", 1);
		currentEnergy = PlayerPrefs.GetInt("currentEnergy", 0);
		entryUpgrade = PlayerPrefs.GetInt("entryUpgrade", 0);
		continueUpgrade = PlayerPrefs.GetInt("continueUpgrade", 0);
		musicAmplitude = PlayerPrefs.GetInt("musicAmplitude", 1);
		soundsAmplitude = PlayerPrefs.GetInt("soundsAmplitude", 1);
		hillInstructions = PlayerPrefs.GetInt("hillInstructions", 1);
	}
}
