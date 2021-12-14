using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDrive : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float gravityMultiplier;


    private Rigidbody rb;
    Collider m_ObjectCollider;

    [SerializeField]
    private GameManager gameManager;
    // Start is called before the first frame update



    void Start()
    {
        rb = GetComponent<Rigidbody>();

        m_ObjectCollider = GetComponent<Collider>();

        m_ObjectCollider.isTrigger = false;

        Debug.Log("Trigger On : " + m_ObjectCollider.isTrigger);
    }




    // Update is called once per frame
    void FixedUpdate()
    {
        Accelerate();
        Turn();
        Fall();

    }

    void Accelerate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 forceToAdd = -transform.forward;
            forceToAdd.y = 0;
            rb.AddForce(forceToAdd * speed * 10);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 forceToAdd = transform.forward;
            forceToAdd.y = 0;
            rb.AddForce(forceToAdd * speed * 10);
        }

        Vector3 locVel = transform.InverseTransformDirection(rb.velocity);
        locVel = new Vector3(0, locVel.y, locVel.z);
        rb.velocity = new Vector3(transform.TransformDirection(locVel).x, rb.velocity.y, transform.TransformDirection(locVel).z);

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Collect")
        {


            if (Input.GetKey(KeyCode.W))
            {
                Vector3 forceToAdd = transform.up;
                forceToAdd.z = 0;
                rb.AddForce(forceToAdd * speed * 250);
            }

            if (Input.GetKey(KeyCode.S))
            {
                Vector3 forceToAdd = -transform.up;
                forceToAdd.z = 0;
                rb.AddForce(forceToAdd * speed * 250);
            }
            other.gameObject.SetActive(false);


           
        }

        if (other.gameObject.tag == "End")
        {

            gameManager.EndGame();
            other.gameObject.SetActive(false);
        }
    }
     
        //if (other.gameObject.tag == "Obstacle" )
        //{
            
        //    m_ObjectCollider.isTrigger = true;

        //    Debug.Log("Trigger On : " + m_ObjectCollider.isTrigger);
        //    other.gameObject.SetActive(false);
            
        //    m_ObjectCollider.isTrigger = false;
        //}

   

//private void OnTriggerEnter(Collider other)
//{

//    if (other.gameObject.tag == "GameCollect")
//    {
//        if (Input.GetKey(KeyCode.O)) 
//        {
//            Vector3 forceToAdd = transform.up;
//            forceToAdd.z = 0;
//            rb.AddForce(forceToAdd * speed * 250);
//        }

//        if (Input.GetKey(KeyCode.P))
//        {
//            Vector3 forceToAdd = -transform.up;
//            forceToAdd.z = 0;
//            rb.AddForce(forceToAdd * speed * 250);
//        }
//        other.gameObject.SetActive(false);
//    }

//}
void Turn()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(-Vector3.up * turnSpeed * 10);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(Vector3.up * turnSpeed * 10);
        }
    }

    //void Fly()
    //{
    //    if (Input.GetKey(KeyCode.O))
    //    {
    //        Vector3 forceToAdd = transform.up;
    //        forceToAdd.z = 0;
    //        rb.AddForce(forceToAdd * speed * 10);
    //    }

    //    if (Input.GetKey(KeyCode.P))
    //    {
    //        Vector3 forceToAdd = -transform.up;
    //        forceToAdd.z = 0;
    //        rb.AddForce(forceToAdd * speed * 10);
    //    }
    //}

   
    void Fall()
    {
        rb.AddForce(Vector3.down * gravityMultiplier * 10);
    }
}