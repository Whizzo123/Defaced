using UnityEngine;
using System.Collections;


public class Projectile : MonoBehaviour
{

    public float timeAlive;
    private float timeAliveCounter;

    // Use this for initialization
    void Start()
    {
        timeAliveCounter = timeAlive;
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive -= Time.deltaTime;
    }
}
