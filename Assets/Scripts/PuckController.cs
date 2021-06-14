using UnityEngine;

public class PuckController : MonoBehaviour
{
    public Rigidbody rgBody;
    public Vector3 spawnPos;
    Vector3 lastVelocity;
    float impuls;
    private MouseController cube;
    private SceneManage sceneManager;

    [SerializeField]private float minSpeed;

    public bool ballMove;
    void Start()
    {
        cube = GameObject.FindWithTag("Cube").GetComponent<MouseController>();
        sceneManager = GameObject.FindWithTag("SceneManager").GetComponent<SceneManage>();
        rgBody = GetComponent<Rigidbody>();
        spawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rgBody.velocity.magnitude);
        //CheckVelicity();
       
    }
    public void Move(Vector3 targedDir, float power)
    {
        rgBody.velocity = targedDir * Time.deltaTime * 100f * cube.targetdist;
        ballMove = true;
    }

    //implements collision checking with game objects
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            sceneManager.IncreaseScore(20);
            ResetPosition();
        }

        if (collision.gameObject.tag == "Enemy")
        {
            sceneManager.ReduceScore(5);
            ResetPosition();
        }

        if (collision.gameObject.tag == "BackWall")
        {
            ResetPosition();
        }

        if (collision.gameObject.tag == "Wall") 
        {
            float speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(rgBody.velocity, collision.contacts[0].normal);
            rgBody.velocity = direction * Time.deltaTime * GetImpulse();
        }

         
    }

    //reset position and velocity of puck
    private void ResetPosition()
    {
        transform.position = spawnPos;
        rgBody.velocity = Vector3.zero;
        ballMove = false;
    }

    //check if puck is moving
    public bool isMoving()
    {
        if (ballMove == true) return true;
        return false;
    }

    //set impulse for puck after collision with wall
    public float  GetImpulse()
    {
        impuls = 30f * cube.targetdist;
        return impuls;
    }

    //reset puck if velocity less some value
    //private void CheckVelicity() 
    //{
    //    if (rgBody.velocity.magnitude >= minSpeed) 
    //    {
    //        ResetPosition();
    //    }
    //}
}
