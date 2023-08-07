using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate;
    private float timer = 0;
    public float heightOffset;
    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer<spawnRate)
        {
            timer +=  Time.deltaTime;
        } 
        else 
        {
            spawnPipe();
            timer = 0;
        }
     
    }

    void spawnPipe()
    {
        float lowesPoint=transform.position.y - heightOffset;
        float highestPoint=transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowesPoint,highestPoint),0),transform.rotation);
    }
}
