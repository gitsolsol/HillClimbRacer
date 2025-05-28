using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class VehicleDataset : ScriptableObject
{
    public Vehicle[] vehicle;

    public int VehicleCount{
        get{
            return vehicle.Length;
        }
    }
    public Vehicle GetVehicle(int index){
        return vehicle[index];
    }
}
