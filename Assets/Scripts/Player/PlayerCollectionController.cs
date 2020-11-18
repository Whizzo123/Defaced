using UnityEngine;
using System.Collections;




public class PlayerCollectionController : MonoBehaviour
{


    public int flowersCollected;

    void Start()
    {
        flowersCollected = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Flower")
        {
            flowersCollected++;
            Destroy(other.gameObject);
        }
    }

    

}
