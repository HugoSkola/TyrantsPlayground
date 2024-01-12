using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class grabobject : MonoBehaviour
{
    [SerializeField]
    private Transform grabpoint;

    [SerializeField]
    private Transform rayPoint;

    [SerializeField]
    private float rayDistance;

    private GameObject grabbedObject;
    private int layerIndex;
   private void Start()
    {
        layerIndex = LayerMask.NameToLayer("objects");
    }
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);
        if (hitInfo.collider!=null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            if (Keyboard.current.qKey.wasPressedThisFrame)
            {
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabpoint.position;
                grabbedObject.transform.SetParent(transform);
            }

            else if(Keyboard.current.qKey.wasPressedThisFrame)
            {
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
            }
       }
        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);

    }


    

}
