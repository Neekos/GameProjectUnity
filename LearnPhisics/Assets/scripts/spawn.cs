using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    
    public GameObject cube;
    public GameObject cube2;

    public float maxDelay, minDelay;
    float next;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > next)
        {

        
        float spawnZ = transform.position.z;
        float spawnY = transform.position.y+2;
            float spawnZ1 = transform.position.z;
            float spawnY1 = transform.position.y+1;

            float spawnX1 = -5;
        float spawnX2 = 5;
        float spawnX = Random.Range(spawnX1, spawnX2);
        float spawnXx = Random.Range(spawnX1, spawnX2);

            next = Time.time + Random.Range(maxDelay, minDelay);

        Instantiate(cube, new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);
        Instantiate(cube2, new Vector3(spawnXx, spawnY1, spawnZ1-5), Quaternion.identity);
        }
    }

}
