using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchFlash : MonoBehaviour
{
    // Start is called before the first frame update
    public void switchFlash(GameObject flash)
    {
        
        flash.SetActive(!flash.activeSelf);
    }
}
