using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class Examinable : MonoBehaviour
{
    [SerializeField] private Transform _originalParent;
    [SerializeField] private float _rotSpeed = 0.5f;
    [SerializeField] private float _examinedScale = 0.1f;
    [SerializeField] private ARTranslationInteractable _posManip;
    [SerializeField] private ARRotationInteractable _rotManip;
    [SerializeField] private ARScaleInteractable _scaleManip;
    
    private bool _isExamined = false;
    private Vector3 _returnPos;
    private Quaternion _returnRot;
    private Vector3 _returnScale;

    void Update()
    {
        if (_isExamined)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    transform.RotateAround(transform.position, -transform.parent.up, touch.deltaPosition.x * _rotSpeed);
                    transform.RotateAround(transform.position, transform.parent.right, touch.deltaPosition.y * _rotSpeed);
                }
            }
        }
    }

    void OnEnable()
    {
        ExaminableManager.modeSwitched += ModeSwitch;
    }

    public void Examine()
    {
        if (!UIManager.Instance.GetMode())
        {
            _isExamined = true;
            SetReturn();
            transform.localScale = Vector3.one * _examinedScale;
            ExaminableManager.Instance.SetExamineTarget(this.transform);
            UIManager.Instance.Examination(_isExamined);
        }
    }

    public void Unexamine()
    {
        if (_isExamined)
        {
            _isExamined = false;
            ReturnToWorld();
            ExaminableManager.Instance.EndExamination();
            UIManager.Instance.Examination(_isExamined);
        }
    }

    private void SetReturn()
    {
        _returnPos = transform.position;
        _returnRot = transform.rotation;
        _returnScale = transform.localScale;
    }

    private void ReturnToWorld()
    {
        transform.parent = _originalParent;
        transform.position = _returnPos;
        transform.rotation = _returnRot;
        transform.localScale = _returnScale;
    }

    private void ModeSwitch(bool placementMode)
    {
        _posManip.enabled = placementMode;
        _rotManip.enabled = placementMode;
        _scaleManip.enabled = placementMode;
    }

    void OnDisable()
    {
        ExaminableManager.modeSwitched -= ModeSwitch;
    }
}
