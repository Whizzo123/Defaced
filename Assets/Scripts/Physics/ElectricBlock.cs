using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBlock : MonoBehaviour
{
    public BoxCollider2D playerCollider;
    private SwitchMask switchMask;
    private PlayerHealthController player;
    bool isToggled;
    private int playerExit = 0;
    public bool isPeriodic;
    public float periodicTime;
    private float periodicTimeCounter;
    void Start()
    {
        gameObject.tag = "ElementalDamage";
    }

    // Update is called once per frame
    void Update()
    {
        if (isPeriodic)
        {
            if (periodicTimeCounter <= 0)
            {
                isToggled = !isToggled;
                periodicTimeCounter = periodicTime;
            }
            periodicTimeCounter -= Time.deltaTime;

        }
        else
        if (gameObject.GetComponent<BoxCollider2D>().IsTouching(playerCollider) && switchMask.currentMask == MASKS.ELEMENTALRESISTANCE && isToggled == false)
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

    public bool IsToggled()
    {
        return isToggled;
    }
}
