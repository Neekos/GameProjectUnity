using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidEmittor : MonoBehaviour
{
    public GameObject asteroid;
    public float maxDelay, minDelay;
    float nextAsteroid;
    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.isStarted)
        {
            return;
        }
        if (Time.time> nextAsteroid)
        {
            //узнаем ось z y x
            float EmittorZ = transform.position.z;
            float EmittorY = 0;
            // делим ось x на попалам и выбираем случайную точку по х ранодомную
            float EmittorX1 = -100;
            float EmittorX2 = 100;
            //устанавливаем растояниео
            float EmittorX = Random.Range(EmittorX1, EmittorX2);
            //пришла пора выпускать новый 
            nextAsteroid = Time.time + Random.Range(maxDelay, minDelay);
            //создаем новый астероид
            Instantiate(asteroid, new Vector3(EmittorX, EmittorY, EmittorZ), Quaternion.identity);
        }
    }
}
