using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject rig;


    [SerializeField]
    private Quaternion targetRotation;

    private bool isRotating = false;

    void Update()
    {
        if(isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,  Time.deltaTime);
            isRotating = false;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        isRotating = true;
        
    }
}
