using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    Rigidbody R;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        R = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        R.velocity = new Vector3(0, 0, -speed);
    }
}
