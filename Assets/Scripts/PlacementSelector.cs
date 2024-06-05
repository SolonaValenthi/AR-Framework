using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class PlacementSelector : MonoBehaviour
{
    // Placeable ID's: 0 = candle, 1 = revolver, 2 = potion, 3 = soldier

    [SerializeField] private ARPlacementInteractable _placement;
    [SerializeField] private GameObject[] _placeables;
    [SerializeField] private Material _planeMat;

    private bool[] _placed = { false, false, false, false };
    private int _selected;

    Color _planeColor;

    void Start()
    {
        _planeColor = _planeMat.color;
    }

    private void OnEnable()
    {
        GameManager.removeModels += RemoveObjects;
    }

    public void SelectPlaceable(int ID)
    {
        if (!_placed[ID])
        {
            _selected = ID;
            _placement.placementPrefab = _placeables[ID];
            _placement.enabled = true;
            _planeMat.color = _planeColor;
        }
        else
        {
            _placement.placementPrefab = null;
            UIManager.Instance.PlacementError();
        }
    }

    public void ObjectPlaced()
    {
        _placed[_selected] = true;
        _placement.placementPrefab = null;
        _placement.enabled = false;
        _planeMat.color = Color.clear;
    }

    private void RemoveObjects()
    {
        for (int i = 0; i < _placed.Length; i++)
        {
            _placed[i] = false;
        }
    }

    private void OnDisable()
    {
        GameManager.removeModels -= RemoveObjects;
        _planeMat.color = _planeColor;
    }
}
