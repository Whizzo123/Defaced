using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBlock : MonoBehaviour
{
    public BoxCollider2D playerCollider;
    public SwitchMask switchMask;
    public PlayerHealthController player;
    bool isToggled;
    public int playerExit = 0;
    void Start()
    {
        gameObject.tag = "ElementalDamage";
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<BoxCollider2D>().IsTouching(playerCollider) && switchMask.currentMask == MASKS.ELEMENTALRESISTANCE && isToggled == false)
        {

            StartCoroutine(ToggleElectricity());

        }
        else if(playerExit == 1 && switchMask.currentMask != MASKS.ELEMENTALRESISTANCE && gameObject.tag == "ElementalDamage")
        {
            player.Die();
        }

    }

    IEnumerator ToggleElectricity()
    {
        isToggled = true;
        gameObject.tag = "Ground";
        Debug.Log("off");
        yield return new WaitForSeconds(10);
        Debug.Log("On");
        gameObject.tag = "ElementalDamage";
        isToggled = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerExit--;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerExit++;
    }
}
