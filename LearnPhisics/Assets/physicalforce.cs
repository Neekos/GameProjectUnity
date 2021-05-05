using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicalforce : MonoBehaviour
{
    private Rigidbody R;
    // Start is called before the first frame update
    void Start()
    {
        R = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            R.AddForce(0,  900, 0);
        }   
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            R.AddForce(-300,0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            R.AddForce(300, 0, 0);
        }
    }
}
