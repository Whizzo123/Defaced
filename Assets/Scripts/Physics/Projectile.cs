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
        if(timeAlive >= 2)
        {
            Object.Destroy(this.gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerInputController>())
        {
            collision.gameObject.GetComponent<PlayerHealthController>().isDead = true;
            Destroy(this.gameObject);
        }
    }
}
