using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePuck : MonoBehaviour
{
    public Rigidbody rgBody;
    public Vector3 spawnPos;
    Vector3 lastVelocity;
    float impuls;
    private MouseController cube;

    public bool ballMove;
    void Start()
    {
        cube = GameObject.FindWithTag("Cube").GetComponent<MouseController>();
        rgBody = GetComponent<Rigidbody>();
        spawnPos = transform.position;
        //Debug.Log(lastVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        ///Debug.Log(rgBody.velocity);
        lastVelocity = rgBody.velocity;
       
    }

    public void Move(Vector3 targedDir, float power)
    {
        rgBody.velocity = targedDir * Time.deltaTime * 200f * power;
        ballMove = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Box" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "BackWall")
        {
            //Destroy(this.gameObject);
            //SpawnPuck();
            ResetPosition();
        }

        if(collision.gameObject.tag == "Wall") 
        {
            float speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(rgBody.velocity, collision.contacts[0].normal);
            rgBody.velocity = direction * Time.deltaTime * GetK();
        }
    }

    private void ResetPosition()
    {
        transform.position = spawnPos;
        rgBody.velocity = Vector3.zero;
        ballMove = false;
    }

    public bool isMoving()
    {
        if (ballMove == true) return true;
        return false;
    }

    public float  GetK()
    {
        impuls = 30f* cube.targetdist;
        Debug.Log(cube.targetdist);
        return impuls;
    }
}
