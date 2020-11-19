using UnityEngine;
using System.Collections;


public enum MASKS { CROUCH, DOUBLEJUMP, STRENGTH, ELEMENTALRESISTANCE, NONE };

public class SwitchMask : MonoBehaviour
{

    public MASKS currentMask;
    private PlayerMovementController mv_controller;
    private PlayerHealthController h_controller;
    private PlayerInputController in_controller;

    void Start()
    {
        mv_controller = FindObjectOfType<PlayerMovementController>();
        h_controller = FindObjectOfType<PlayerHealthController>();
        in_controller = FindObjectOfType<PlayerInputController>();
    }

    public void Switch(int maskID)
    {
        switch(maskID)
        {
            case 0:
                currentMask = MASKS.CROUCH;
                SetProperties(true, false, 1, false);
                break;
            case 1:
                currentMask = MASKS.DOUBLEJUMP;
                SetProperties(false, false, 2, false);
                break;
            case 2:
                currentMask = MASKS.STRENGTH;
                SetProperties(false, true, 1, false);
                break;
            case 3:
                currentMask = MASKS.ELEMENTALRESISTANCE;
                SetProperties(false, false, 1, true);
                break;
            case 4:
                currentMask = MASKS.NONE;
                Debug.LogWarning("Did you mean to equip no mask?");
                SetProperties(false, false, 1, false);
                break;
        }
    }

    private void SetProperties(bool crouch, bool strength, int jump, bool e_resistance)
    {
        in_controller.canCrouch = crouch;
        in_controller.hasStrength = strength;
        mv_controller.jumpLimit = jump;
        h_controller.hasElementalResistance = e_resistance;
    }

}
