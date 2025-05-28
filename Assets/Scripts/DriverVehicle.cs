using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverVehicle : MonoBehaviour
{
    public VehicleDataset vehicleDataset;
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
    private void UpdateVehicle(int selectedOption)
    {
        Vehicle vehicle = vehicleDataset.GetVehicle(selectedOption);
        artworkSprite.sprite = vehicle.vehicleSprite;
    }
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}
