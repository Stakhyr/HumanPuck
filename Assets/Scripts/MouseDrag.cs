using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private static Vector3 startPosition;
    private Vector3 mousePosition;

    [SerializeField] private float maxEndDistance = 5f;

    private bool isBeingHeld = false;
    void Awake()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        OnMouseDown();
    }

    private bool OnMouseDown()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            isBeingHeld = true;
            Debug.Log("Hold!!!");
            //mousePosition = Input.mousePosition;
            //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //transform.M = new Vector3(mousePosition.x,0,mousePosition.z);
        }
        return true;
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
}
