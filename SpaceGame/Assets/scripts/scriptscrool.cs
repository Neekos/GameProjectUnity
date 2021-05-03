using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptscrool : MonoBehaviour
{
    public float speed;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        //задаем нашему вектору текущее положение
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 0 ... -150 -> 0
        float offset = Time.time * speed;
        // повторяем десвие 
        float Z = Mathf.Repeat(offset, 250);
        //задаем текущему положениею сдвиг 
        transform.position = startPosition + new Vector3(0,0,-Z);
    }
}
