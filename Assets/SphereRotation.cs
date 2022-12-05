using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRotation : MonoBehaviour
{

    [SerializeField] float xx;
    [SerializeField] float yy;
    [SerializeField] float zz;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(xx, yy, zz);
    }
}
