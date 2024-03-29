using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class grabobject : MonoBehaviour
{
    [SerializeField]
    GameObject BulletPrefab;


    [SerializeField]
    Transform bulletspawn;

    
    //public float shootingDelay = 1f;

    //float nextFireTime = 0f;

    [SerializeField]
    private Transform grabpoint;

    [SerializeField]
    private Transform rayPoint;

    [SerializeField]
    private float rayDistance;

    Rigidbody2D rigidBody;
    [SerializeField]
    Vector2 velocity = Vector2.one;

    public GameObject grabbedObject;
    private int layerIndex;
   public void Start()
    {
        layerIndex = LayerMask.NameToLayer("objects");
        layerIndex = LayerMask.NameToLayer("npc");

    }
    void Update()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);
        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            if (Keyboard.current.qKey.wasPressedThisFrame && grabbedObject == null)
            {
                grabbedObject = hitInfo.collider.gameObject;
                Rigidbody2D rbObject = grabbedObject.GetComponent<Rigidbody2D>();
                rbObject.isKinematic = true;
                rbObject.MovePosition(grabpoint.position);
                grabbedObject.transform.SetParent(transform);
            }

            else if (Keyboard.current.qKey.wasPressedThisFrame)
            {
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
            }
        }

        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);

    }


    
        
}
