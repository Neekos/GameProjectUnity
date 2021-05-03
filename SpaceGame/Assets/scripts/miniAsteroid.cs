using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniAsteroid : MonoBehaviour
{
    Rigidbody miniA;
    public float speedRotation;
    public float maxSpeed, minSpeed;
    public float Xshift; //отклонене по оси х

    // Start is called before the first frame update
    void Start()
    {
        //передаем rigitbody и направление вектора движения
        miniA = GetComponent<Rigidbody>();
        //выбираем скорость случайную установленную
        float speedZ = Random.Range(maxSpeed, minSpeed);
        float speedX = Random.Range(-speedZ * Xshift, speedZ * Xshift);
        miniA.velocity = new Vector3(speedX, 0, -speedZ);
        //задаем нашему остероиду вращение рандомное
        miniA.angularVelocity = Random.insideUnitSphere * speedRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
