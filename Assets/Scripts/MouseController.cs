using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    Vector3 targetDir;
    private bool isBeingHeld = false;
    [SerializeField] private Transform arrow;
  
    public float speed = 10f;
    public Vector3 targetPos;
    public bool isMoving;
    const int MOUSE = 0;
    private static Vector3 startPosition;
   /* [SerializeField]*/ private MovePuck ball;
    private bool movedBack = false;

    private bool arrowSpawn = false;


    // Use this for initialization1
    void Start()
    {
        ball = GameObject.FindWithTag("Ball").GetComponent<MovePuck>();
        //ball = GameObject.FindWithTag("Ball").GetComponent<MovePuck>();
        startPosition = transform.position;
        targetPos = transform.position;
        isMoving = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(ball.transform.position);

        if (Input.GetMouseButton(MOUSE))
        {
            SetTarggetPosition();
            isBeingHeld = true;
        }
        if (isBeingHeld)
        {
            arrowSpawn = true;
            if (arrowSpawn == true) 
            {
                arrowSpawn = false;
                //Transform a = Instantiate(arrow, targetDir, Quaternion.identity);

            }
            MoveObject();
        }
        if(isBeingHeld==false && startPosition!=transform.position)
        {
            arrowSpawn = false;
            MoveBack();

            if (ball != null && movedBack && ball.isMoving() == false) 
            {
                ball.Move(targetDir,targetdist);
                Debug.Log("Moving");
            }
            if (ball == null) 
            {
                ball = GameObject.FindWithTag("Ball").GetComponent<MovePuck>();
                //Debug.Log("Ball null");
            }

            if(ball.isMoving() == true) 
            {
                Debug.Log("WOOOOOrks");
            }


        }
       
    }
    void  SetTarggetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point;

        if (plane.Raycast(ray, out point))
            targetPos = ray.GetPoint(point);
        if (targetPos.z > -4f)
        {
            targetPos.z = -4f;

        }

        isMoving = true;
    }
    public float targetdist;
    private bool ballIsMoving =false;

    float MoveObject()
    {

        
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);


        if (transform.position == targetPos) 
        {
            targetdist = Vector3.Distance(startPosition, targetPos);
            isBeingHeld = false;
            targetDir = transform.position - startPosition;

        }
        //Debug.DrawLine(transform.position, targetPos, Color.red);

        
        return targetdist;

    }

    private void MoveBack()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position,targetPos)>2f) movedBack = true;

        if (transform.position == startPosition && isBeingHeld==false && targetPos!=startPosition) 
        {
            movedBack = false;
        }
    }

   
}