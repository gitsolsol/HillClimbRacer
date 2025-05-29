using UnityEngine;

public class SettingsMenuController : MonoBehaviour
{
    public GameObject settingsPanel;

    // Called to toggle the settings menu on/off
    public void ToggleSettingsPanel()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    // Optional: Close the panel
    public void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }
}
