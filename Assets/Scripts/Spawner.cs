using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePattern;

    private float timeToSpawn;
    public float startTimeToSpawn;
    public float decreaseTime;
    public float minTime = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToSpawn <= 0)
        {
            int rand = Random.Range(0, obstaclePattern.Length);
            Instantiate(obstaclePattern[rand], transform.position, Quaternion.identity);
            timeToSpawn = startTimeToSpawn;
            if (startTimeToSpawn > minTime)
            {
                startTimeToSpawn -= decreaseTime;
            }
            
        }
        else
        {
            timeToSpawn -= Time.deltaTime;
        }


    }
}
