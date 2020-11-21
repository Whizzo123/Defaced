using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBlock : MonoBehaviour
{
    private GameObject playerGO;
    private SwitchMask switchMask;
    private PlayerHealthController player;
    private Collider2D myCollider;
    bool isToggled;
    public bool isPeriodic;
    public float periodicTime;
    private float periodicTimeCounter;
    void Start()
    {
        gameObject.tag = "ElementalDamage";
        switchMask = FindObjectOfType<SwitchMask>();
        myCollider = GetComponent<Collider2D>();
        if (myCollider == null)
            Debug.LogError("GameObject " + gameObject.name + " has no collider");
        player = FindObjectOfType<PlayerHealthController>();
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
        if (playerGO != null)
        {
            if (switchMask.currentMask == MASKS.ELEMENTALRESISTANCE && isToggled == false)
            {
                StartCoroutine(ToggleElectricity());
            }
            else if (switchMask.currentMask != MASKS.ELEMENTALRESISTANCE && gameObject.tag == "ElementalDamage")
            {
                if(!player.isDead)
                    player.isDead = true;
            }
        }

    }

    IEnumerator ToggleElectricity()
    {
        isToggled = true;
        gameObject.tag = "Ground";
        yield return new WaitForSeconds(10);
        gameObject.tag = "ElementalDamage";
        isToggled = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerInputController>())
        {
            playerGO = null;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerInputController>())
        {
            playerGO = collision.gameObject;
        }
    }

    public bool IsToggled()
    {
        return isToggled;
    }
}
