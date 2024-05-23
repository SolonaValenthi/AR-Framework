using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class ExaminableManager : MonoBehaviour
{
    private static ExaminableManager _instance;
    public static ExaminableManager Instance
    {
        get 
        {
            if (_instance == null)
                Debug.LogError("No examinable manager found");

            return _instance;
        }
    }

    [SerializeField] private ARPlacementInteractable _placement;
    [SerializeField] private Transform _examineTarget;

    private GameObject _lastPlaceable;

    public bool isExamining { get; private set; } = false;

    void Awake()
    {
        _instance = this;
    }

    public void SetExamineTarget(Transform target)
    {
        isExamining = true;
        target.position = _examineTarget.position;
        target.parent = _examineTarget;
        
        if (_placement.isActiveAndEnabled)
        {
            _lastPlaceable = _placement.placementPrefab;
            _placement.placementPrefab = null;
        }
    }

    public void EndExamination()
    {
        isExamining = false;
        if (_placement.isActiveAndEnabled)
            _placement.placementPrefab = _lastPlaceable;
    }
}
