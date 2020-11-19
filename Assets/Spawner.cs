using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject deathPlatformPrefab;
    public GameObject spawnPoint;

    public float spawnRate;
    private float spawnRateCounter;


    void Update()
    {
        if (spawnRateCounter <= 0)
        {
            spawnRateCounter = spawnRate;
            GameObject go = (GameObject)Instantiate(deathPlatformPrefab, spawnPoint.transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
        }
        spawnRateCounter -= Time.deltaTime;
    }

}
