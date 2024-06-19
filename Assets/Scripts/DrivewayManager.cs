using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class DrivewayManager : MonoBehaviour
{
    // For handling driveway mode specifics

    private static DrivewayManager _instance;
    public static DrivewayManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("No Driveway manager found");

            return _instance;
        }
    }

    [SerializeField] private ARPlacementInteractable _placement;
    [SerializeField] private ARPlaneManager _planeManager;
    [SerializeField] private GameObject[] _drivewayModel; // ID's 0 = Sports Car

    private bool _placementReady = true;
    private GameObject _placed;

    void Awake()
    {
        _instance = this;
    }

    public void SelectObject(int ID)
    {
        if (_placementReady)
            _placement.placementPrefab = _drivewayModel[ID];
        else
            _placement.placementPrefab = null;
    }

    public void ObjectPlaced()
    {
        _placement.placementPrefab = null;
        _placementReady = false;
        DisablePlanes(_placementReady);
    }

    public void RegisterModel(GameObject model)
    {
        _placed = model;
    }

    public void RemoveModel()
    {
        Destroy(_placed);
        _placementReady = true;
        DisablePlanes(_placementReady);
    }

    public void LockModel()
    {
        _placed.GetComponent<DrivewayModel>()?.LockModel();
    }

    private void DisablePlanes(bool disable)
    {
        _planeManager.enabled = disable;

        foreach (ARPlane plane in _planeManager.trackables)
        {
            plane.gameObject.SetActive(disable);
        }
    }
}
