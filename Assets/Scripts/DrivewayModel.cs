using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class DrivewayModel : MonoBehaviour
{
    // Generic behaviours shared by all driveway models

    [SerializeField] private ARSelectionInteractable _select;
    [SerializeField] private ARRotationInteractable _rotate;
    [SerializeField] private ARTranslationInteractable _translate;

    // Start is called before the first frame update
    void Start()
    {
        DrivewayManager.Instance?.RegisterModel(this.gameObject);
    }

    // Model becomes unselected and cannot be manipulated
    public void LockModel()
    {
        _select.enabled = false;
        _rotate.enabled = false;
        _translate.enabled = false;
    }
}
