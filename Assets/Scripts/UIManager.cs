using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("No UI manager found");

            return _instance;
        }
    }
    
    [SerializeField] private GameObject _sceneMenu;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _modelSelector;
    [SerializeField] private TMP_Text _currentMode;
    [SerializeField] private TMP_Text _currentPlacement;
    [SerializeField] private GameObject _errorText;

    private bool _placementMode = true;

    void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _sceneMenu.SetActive(true);
        _mainMenu.SetActive(false);
    }
    
    public void SwitchMode()
    {
        _placementMode = !_placementMode;

        if (_placementMode)
            _currentMode.text = "Placement Mode";
        else
            _currentMode.text = "Examination Mode";

        _modelSelector.SetActive(_placementMode);
        ExaminableManager.Instance.SwitchMode(_placementMode);
    }

    public void SelectModel(int modelID)
    {
        switch (modelID)
        {
            case 0:
                _currentPlacement.text = "Model: Candle";
                break;
            case 1:
                _currentPlacement.text = "Model: Revolver";
                break;
            case 2:
                _currentPlacement.text = "Model: Potion";
                break;
            case 3:
                _currentPlacement.text = "Model: Soldier";
                break;
            default:
                Debug.LogError("Invalid Model ID");
                break;
        }
    }

    public void Examination(bool examining)
    {
        _sceneMenu.SetActive(!examining);
    }

    public void PlacementError()
    {
        _errorText.SetActive(true);
    }

    public bool GetMode()
    {
        return _placementMode;
    }
}
