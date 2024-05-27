using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public delegate void ModeSwitch(bool placementMode);
    public static event ModeSwitch modeSwitched;

    [SerializeField] private Transform _examineTarget;

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
    }

    public void EndExamination()
    {
        isExamining = false;
    }

    public void SwitchMode(bool placementMode)
    {
        modeSwitched?.Invoke(placementMode);
    }
}
