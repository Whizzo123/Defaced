using UnityEngine;
using System.Collections;




public class PlayerCollectionController : MonoBehaviour
{


    public int flowersCollected;
    public Item[] collectedItems;

    void Start()
    {
        flowersCollected = 0;
        collectedItems = new Item[5];
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Flower")
        {
            flowersCollected++;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "CollectableItem")
        {
            Pickup(other.gameObject.name);
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Mask")
        {
            GetComponent<MaskPickup>().Pickup();
            Destroy(other.gameObject);
        }
    }

    private void Pickup(string name)
    {
        for (int i = 0; i < collectedItems.Length; i++)
        {
            if(collectedItems[i].name == null)
            {
                collectedItems[i].name = name;
                return;
            }
        }
        Debug.LogWarning("Items list is full!!!");
    }

    

}
