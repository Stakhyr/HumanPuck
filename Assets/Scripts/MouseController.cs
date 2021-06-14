using UnityEngine;

public class MouseController : MonoBehaviour
{
    Vector3 targetDir;
    private bool isBeingHeld = false;
  
    public float speed = 10f;
    public Vector3 targetPos;
    public bool cubeIsMoving;
    const int MOUSE = 0;
    private static Vector3 startPosition;
    private PuckController ball;
    private bool movedBack = false;


    // Use this for initialization1
    void Start()
    {
        ball = GameObject.FindWithTag("Ball").GetComponent<PuckController>();
        startPosition = transform.position;
        targetPos = transform.position;
        cubeIsMoving = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(MOUSE))
        {
            SetTarggetPosition();
            isBeingHeld = true;
        }
        if (isBeingHeld)
        {
            MoveObject();
        }
        if(isBeingHeld==false && startPosition!=transform.position)
        {
            MoveBack();

            if (ball != null && movedBack && ball.isMoving() == false) 
            {
                ball.Move(targetDir,targetdist);
            }
            if (ball == null) 
            {
                ball = GameObject.FindWithTag("Ball").GetComponent<PuckController>();
            }
        }
       
    }
    //set move vector for cube
    void  SetTarggetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point;

        if (plane.Raycast(ray, out point)) 
        {
            float val = Vector3.Distance(startPosition, ray.GetPoint(point));
            if (val>0 && val < 4f) 
            {
                targetPos = ray.GetPoint(point);

            }
            else 
            {
                targetPos = transform.position;
            }
           
        }
        cubeIsMoving = true;
    }
    public float targetdist;
    float MoveObject()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);


        if (transform.position == targetPos) 
        {
            targetdist = Vector3.Distance(startPosition, targetPos);
            isBeingHeld = false;
            targetDir = transform.position - startPosition;
        }
        return targetdist;

    }

    //cube move to start position
    private void MoveBack()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position,targetPos)>0.5f) movedBack = true;

        if (transform.position == startPosition && isBeingHeld==false && targetPos!=startPosition) 
        {
            movedBack = false;
        }
    }



    //allowed range of cube motion
    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;

        float range = 3f;
        Gizmos.DrawWireSphere(pos, range);
    }
}