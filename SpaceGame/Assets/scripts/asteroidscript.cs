using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidscript : MonoBehaviour
{
    Rigidbody asteroid;
    public float speedRotation;
    public float maxSpeed, minSpeed;
    public float Xshift; //отклонене по оси х
    public GameObject explosionAsteroid;
    public GameObject littleAsteroid;
    public GameObject explosionShip;
    float size;
    // Start is called before the first frame update
    void Start()
    {
        //передаем rigitbody и направление вектора движения
        asteroid = GetComponent<Rigidbody>();
        size = Random.Range(0.5f, 1.0f);
        asteroid.transform.localScale *= size;
        //выбираем скорость случайную установленную
        float speedZ = Random.Range(maxSpeed, minSpeed);
        float speedX = Random.Range(-speedZ*Xshift, speedZ*Xshift);
        asteroid.velocity = new Vector3(speedX, 0, -speedZ) / size ;
        //задаем нашему остероиду вращение рандомное
        asteroid.angularVelocity = Random.insideUnitSphere * speedRotation;
    }
    //срабатывает при начале столкновения
    private void OnTriggerEnter(Collider other)
    {
        //что бы астероид не взрывался в самом начале и от маленьких осколков
        if (other.tag == "Boundury" || other.tag == "MiniAs")
        {
            return;
        }

        if (other.tag == "Player")
        {
            Instantiate(explosionShip, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
        else
        {
            GameControllerScript.scrore += 10;
        }
        
       
            Instantiate(explosionAsteroid, other.transform.position, Quaternion.identity);
            Destroy(gameObject);// уничтожаем остероид
            for (int i = 0; i < 5; i++)
            {
                Instantiate(littleAsteroid, other.transform.position, Quaternion.identity);
            }
            
     
        //Destroy(other.gameObject);//и то с чем он столкнулся
    }
}
