using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour
{

    Rigidbody lazershot;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        if (!GameControllerScript.isStarted)
        {
            return;
        }
        //передаем переменной поведение твердого тела и с помощью velocity и vector3 заставляем двигатся по одной из оси
        lazershot = GetComponent<Rigidbody>();
        lazershot.velocity = new Vector3(0,0,speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
