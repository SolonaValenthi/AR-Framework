using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _emitter;
    
    Material _mat;
    Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _mat = GetComponent<MeshRenderer>().material;
        _anim = GetComponent<Animator>();
    }

    public void Activate()
    {
        _anim.SetTrigger("Open");
        _emitter.SetActive(true);
    }

    public void Deactivate()
    {
        _anim.SetTrigger("Close");
        _emitter.SetActive(false);
    }
}
