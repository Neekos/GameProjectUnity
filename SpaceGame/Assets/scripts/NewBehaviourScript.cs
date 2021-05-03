using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    Rigidbody ship;
    public float speed; 
    public float speed2;
    public float tilt; //вращение
    public float tilt2; 
    public float XMax, XMin, ZMax, ZMin;//ограничеваем пространство
    public GameObject LazerShot; //лазер
    public Transform LazerGun;// точка с которой будет спавнится
    public Transform LazerGun2;
    public float shotDuration; //задержка
    public float shotNext;//следующий выстрел
    void Start()
    {
        
        ship = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.isStarted)
        {
            return;
        }
        //Заставялем двигатся обЪект
        float moveHorizontal = Input.GetAxis("Horizontal"); // +1 -1 
        float moveVertical = Input.GetAxis("Vertical");
        //велосити позволяет двигать объект прямо
        ship.velocity = new Vector3(moveHorizontal*speed2, 0 ,moveVertical * speed);
        //rotation quaternion.eulaer позволяет  вертеть объект
        ship.rotation = Quaternion.Euler(tilt*moveVertical,0 , -tilt2* moveHorizontal);
        //устанавливаем рамки для того что бы не смогли улететь 
        float Xclamep = Mathf.Clamp(ship.position.x, XMin, XMax);
        float Zclamep = Mathf.Clamp(ship.position.z, ZMin, ZMax);

        ship.position = new Vector3(Xclamep,0,Zclamep);
            //Делаем выстел по щелчку мыши input.getbutton и проверяем текущее время и время следующего выстрела
        if (Time.time > shotNext && Input.GetButtonDown("Fire1"))
        {
            //создаем объект лазер в лазергане
            Instantiate(LazerShot, LazerGun.position, Quaternion.identity);
            Instantiate(LazerShot, LazerGun2.position, Quaternion.identity);
            //говорим что следующий вистрел через 1сек примерно
            shotNext = Time.time + shotDuration;
        }
        

        

        
    }
}
