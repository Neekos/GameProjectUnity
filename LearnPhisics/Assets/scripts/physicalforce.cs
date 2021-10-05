using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicalforce : MonoBehaviour
{
    private Rigidbody R;
    private bool isActive = true;
    public float water = 10f;
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
            R.AddForce(0,  1200, 0);
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

        float dive = -transform.position.y + transform.lossyScale.x * 0.5f;
        dive = Mathf.Clamp(dive, 0f, 1f);

        R.AddForce(Vector3.up * dive * water);
        R.drag = dive * 2f;
        R.angularDrag = dive * 2f;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            R.isKinematic = true;
            collision.other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }


}
