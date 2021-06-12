using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrugObject : MonoBehaviour
{
    private float startPosX;
    private float startPosZ;
    private bool isBeingHeld = false;

    private void Update()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToViewportPoint(mousePos);

        this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX,0, mousePos.z - startPosZ);
    }

    private void OnMouseDown()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosZ = mousePos.z - this.transform.localPosition.z;
            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
}

