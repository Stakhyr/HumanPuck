using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform puck; 

    [SerializeField]private float distanceToBorder = 2f;
    float Speed = 10f;
    private bool movingRihgt = false;
    //private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (TargetInRange()) 
        {
            ///Debug.Log("Target in Range");
            MoveTotarget();
        }

        Patroll();
        DetectSides();
    }

    private void Patroll()
    {
        if (movingRihgt == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime);
        }

        if (movingRihgt == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
        }
    }

    private bool TargetInRange(/*float Range*/) 
    {
        if (Vector3.Distance(transform.position, puck.transform.position) < 4f)
        {
            return true;
        }
        return false;

    }

    void MoveTotarget() 
    {
        
        float Direction = Mathf.Sign(puck.transform.position.x - transform.position.x);
        Vector3 MovePos = new Vector3(
             transform.position.x + Direction * Speed * Time.deltaTime, //MoveTowards on 1 axis
            transform.position.y,
            transform.position.z
        );
        transform.position = MovePos;
    }

    void DetectSides() 
    {
        int layerMask = 1 << 9;

        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, distanceToBorder, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.red);
            movingRihgt = true;
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, distanceToBorder, layerMask))
        {
            movingRihgt = false;
        }
    }


}
