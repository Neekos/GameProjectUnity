using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mycube : MonoBehaviour
{
    private Rigidbody R;
    public float speed;
    public float tilt;
    // Start is called before the first frame update
    void Start()
    {
        R = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Позволяет управлять по одной из осей
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //задает движение
        R.velocity = new Vector3(h, 0, v) * speed;
        //вращение
        //R.rotation = Quaternion.Euler(0, tilt*h, 0);

        //правая кнопка мыши
        if (Input.GetButtonDown("Fire1"))
        {
            R.useGravity = false;
            R.mass = 10f;
            R.drag = 0.2f;
            R.angularDrag = 0.2f;
            R.isKinematic = false;
        //левая  кнопка мыши
        } else if (Input.GetButtonDown("Fire2"))
        {
            R.useGravity = true;
            R.isKinematic = true;
            R.mass = 1f;
            R.drag = 0.0f;
            R.angularDrag = 0.0f;
        }
    }
}
