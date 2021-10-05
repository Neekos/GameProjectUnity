using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public void Addhealth(int value)
    {
        GetComponent<Slider>().value += value;
    }
}
