using UnityEngine;
using System.Collections;



public class MaskPickup : MonoBehaviour
{

    public MASKS maskToAdd;
    public Sprite maskSpriteForWheel;

    public void Pickup()
    {
        FindObjectOfType<MaskWheel>().AddMaskToWheel(maskToAdd, maskSpriteForWheel);
    }


}
