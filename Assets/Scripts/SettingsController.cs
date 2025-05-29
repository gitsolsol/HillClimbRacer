using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [Header("UI Elements")]
    public Toggle musicToggle;
    public Toggle soundsToggle;
    public Button aboutButton;

    private string[] languages = { "English", "Arabic" };
    private int currentLanguageIndex = 0;

    void Start()
    {
        // Initialize settings
        musicToggle.isOn = PlayerPrefs.GetInt("Music", 1) == 1;
        soundsToggle.isOn = PlayerPrefs.GetInt("Sounds", 1) == 1;


        // Hook up events
        musicToggle.onValueChanged.AddListener(OnMusicToggle);
        soundsToggle.onValueChanged.AddListener(OnSoundsToggle);
        aboutButton.onClick.AddListener(OnAboutPressed);

    }

    public void OnMusicToggle(bool isOn)
    {
        PlayerPrefs.SetInt("Music", isOn ? 1 : 0);
        Debug.Log("Music toggled: " + isOn);
    }

    public void OnSoundsToggle(bool isOn)
    {
        PlayerPrefs.SetInt("Sounds", isOn ? 1 : 0);
        Debug.Log("Sounds toggled: " + isOn);
    }

    public void OnAboutPressed()
    {
        Debug.Log("About button pressed!");
        // Show your about panel or credits scene
    }
}
