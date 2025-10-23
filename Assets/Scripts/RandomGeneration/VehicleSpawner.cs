using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class VehicleSpawner : MonoBehaviour
{
    //List of all the possible vehicles
    public List<Vehicles> vehicleList = new();

    //Variables specific to the spawner
    public Transform spawn;
    //Abstract variables for referencing
    GameObject _physicalVehicle;

    private void Start()
    {
        int pick = Random.Range(0, vehicleList.Count);

        Vehicles vehiclePick = vehicleList[pick];
        LoadVehicle(vehiclePick);

        spawn = GetComponent<Transform>();
    }

    //Load the vehicle ScriptableObject
    private void LoadVehicle(Vehicles _vehicles)
    {
        //Load the Mesh of the vehicle and reset its local position and rotation
        _physicalVehicle = Instantiate(_vehicles.vehicle, spawn);
        _physicalVehicle.transform.localPosition = Vector3.zero;
        _physicalVehicle.transform.localRotation = Quaternion.identity;
    }
}
