using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskWheel : MonoBehaviour
{

    public GameObject container;
    private MaskWheelComponent[] wheelSegments;
    private MaskWheelComponent selectedSegment;

    void Start()
    {
        container.SetActive(false);
        wheelSegments = container.GetComponentsInChildren<MaskWheelComponent>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            container.SetActive(true);
            FindObjectOfType<PauseSystem>().PauseGame();
        }
        else if(Input.GetKeyUp(KeyCode.Q))
        {
            if (selectedSegment != null)
            {
                FindObjectOfType<SwitchMask>().Switch((int)selectedSegment.equippedMask);
            }
            container.SetActive(false);
            FindObjectOfType<PauseSystem>().ResumeGame();
        }
    }

    private MaskWheelComponent GrabFreeComponent()
    {
        foreach (MaskWheelComponent wheelComponent in wheelSegments)
        {
            if(wheelComponent.equippedMask == MASKS.NONE)
            {
                return wheelComponent;
            }
        }
        return null;
    }

    public void AddMaskToWheel(MASKS maskToAdd, Sprite sprite)
    {
        MaskWheelComponent segment = GrabFreeComponent();
        if (segment != null)
        {
            segment.equippedMask = maskToAdd;
            segment.gameObject.GetComponent<Image>().sprite = sprite;
        }
        Debug.LogError("Have filled up the mask wheel");
    }

    public void SetSegmentSelected(MaskWheelComponent component)
    {
        selectedSegment = component;
    }

    public void SetSegmentDeselected()
    {
        selectedSegment = null;
    }
}
