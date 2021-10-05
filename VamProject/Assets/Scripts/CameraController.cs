using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float MouseX;
    private float MouseY;
    [Header("Чувствительность мыши")]
    public float MouseSensetivity = 100f;

    private float xRotation = 0f;
    public Transform Player;
    
    // Start is called before the first frame update
    void Start()
    {
        
        


    }

    // Update is called once per frame
    void Update()
    {

        MouseX = Input.GetAxis("Mouse X") * MouseSensetivity * Time.deltaTime;
        MouseY = Input.GetAxis("Mouse Y") * MouseSensetivity * Time.deltaTime;
        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        Player.Rotate(Vector3.up * MouseX);
    }
}
