using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class PlacementSelector : MonoBehaviour
{
    // Placeable ID's: 0 = candle, 1 = revolver, 2 = potion, 3 = soldier

    [SerializeField] private ARPlacementInteractable _placement;
    [SerializeField] private GameObject[] _placeables;

    private bool[] _placed = { false, false, false, false };
    private int _selected;

    public void SelectPlaceable(int ID)
    {
        if (!_placed[ID])
        {
            _selected = ID;
            _placement.placementPrefab = _placeables[ID];
            _placement.enabled = true;
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
    }
}
