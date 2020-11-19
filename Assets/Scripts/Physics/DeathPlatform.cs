using UnityEngine;
using System.Collections;



public class DeathPlatform : MonoBehaviour
{


    public float timeAlive;
    private float timeAliveCounter;

    void Start()
    {
        timeAliveCounter = timeAlive;
    }
    void Update()
    {
        if(timeAliveCounter <= 0)
        {
            Destroy(this.gameObject);
        }
        timeAliveCounter -= Time.deltaTime;
    }

}

