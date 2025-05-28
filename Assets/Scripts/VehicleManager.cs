using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class VehicleManager : MonoBehaviour
{
    public VehicleDataset vehicleDataset;
    public Text nameText;
    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateVehicle(selectedOption);

    }
    public void NextOption()
    {
        selectedOption++;
        if (selectedOption >= vehicleDataset.VehicleCount)
        {
            selectedOption = 0;
        }
        UpdateVehicle(selectedOption);
        Save();
    }
    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = vehicleDataset.VehicleCount - 1;
        }
        UpdateVehicle(selectedOption);
        Save();

    }
    private void UpdateVehicle(int selectedOption)
    {
        Vehicle vehicle = vehicleDataset.GetVehicle(selectedOption);
        artworkSprite.sprite = vehicle.vehicleSprite;
        nameText.text = vehicle.vehicleName;
    }
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }
    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

}
