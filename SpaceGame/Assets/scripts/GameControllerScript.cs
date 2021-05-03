using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    //текстовый тип интерфейса
    public UnityEngine.UI.Text scoreLabel;
    public GameObject menu;//получаем меню
    public UnityEngine.UI.Button startButton;//получаем кнопку
    public static bool isStarted = false;//задаем стат перем для проверки
    public static int scrore;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(delegate
        {
            //удаляем меню и то что внем
            menu.SetActive(false);
            //делаем игру активной
            isStarted = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = "Score:" + scrore;
    }
}
