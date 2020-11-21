using UnityEngine;
using System.Collections;


public enum MASKS { CROUCH, DOUBLEJUMP, STRENGTH, ELEMENTALRESISTANCE, NONE };

public class SwitchMask : MonoBehaviour
{

    public MASKS currentMask;

    void Start()
    {

    }

    public void Switch(int maskID)
    {
        currentMask = (MASKS)maskID;
    }



}
