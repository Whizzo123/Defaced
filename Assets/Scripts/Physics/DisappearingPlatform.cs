using UnityEngine;
using System.Collections;


public class DisappearingPlatform : Interactable
{

    public override void Toggle()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }

}
