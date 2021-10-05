using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Скорость персонажа")]
    public float PlayerSpeed = 7f;
    [Header("Скорость персонажа")]
    public float RunSpeed = 10f;
    [Header("Проверка поверхности")]
    public bool ground;

    public Rigidbody rb;
    [Header("Сила прыжка")] 
    public float JumpPower = 200f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += transform.forward * RunSpeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += transform.forward * PlayerSpeed * Time.deltaTime;
            }
           
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += -transform.forward * PlayerSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += -transform.right * PlayerSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += transform.right * PlayerSpeed * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (ground == true)
            {
                rb.AddForce(transform.up * JumpPower);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            ground = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            ground = false;
        }
    }
}
