using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VehicleManager : MonoBehaviour
{
    public VehicleDataset vehicleDataset;
    public Text nameText;
    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;
    void Start()
    {
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
    }
    public void BackOption()
    {
        selectedOption--;
        if (selectedOption <0)
        {
            selectedOption = vehicleDataset.VehicleCount-1;
        }
        UpdateVehicle(selectedOption);
    }
    private void UpdateVehicle(int selectedOption)
    {
        Vehicle vehicle = vehicleDataset.GetVehicle(selectedOption);
        artworkSprite.sprite = vehicle.vehicleSprite;
        nameText.text = vehicle.vehicleName;
    }
}
