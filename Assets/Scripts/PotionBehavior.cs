using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBehavior : MonoBehaviour
{
    Material _mat;

    // Start is called before the first frame update
    void Start()
    {
        _mat = GetComponent<MeshRenderer>().material;
    }

    public void Activate()
    {
        _mat.SetColor("_EmissionColor", Color.white);
    }

    public void Deactivate()
    {
        _mat.SetColor("_EmissionColor", Color.black);
    }
}
