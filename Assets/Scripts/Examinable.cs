using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examinable : MonoBehaviour
{
    [SerializeField] private Transform _originalParent;
    [SerializeField] private float _rotSpeed = 0.5f;
    [SerializeField] private float _examinedScale = 0.1f;
    
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

    public void Examine()
    {
        _isExamined = true;
        SetReturn();
        transform.localScale = Vector3.one * _examinedScale;
        ExaminableManager.Instance.SetExamineTarget(this.transform);
    }

    public void Unexamine()
    {
        _isExamined = false;
        ReturnToWorld();
        ExaminableManager.Instance.EndExamination();
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
}
