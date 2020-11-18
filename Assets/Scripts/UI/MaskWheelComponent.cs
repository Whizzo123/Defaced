using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MaskWheelComponent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public MASKS equippedMask;
    public Image foreground;
    public Image background;

    void Start()
    {

    }

    void Update()
    {

    }

    public void SetUpSprites(MaskWheelSprite sprites)
    {
        foreground.sprite = sprites.foreground;
        Color foreColor = foreground.color;
        foreColor.a = 1f;
        foreground.color = foreColor;
        background.sprite = sprites.background;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (equippedMask != MASKS.NONE)
        {
            Color tempColor = background.color;
            tempColor.a = .5f;
            background.color = tempColor;
            FindObjectOfType<MaskWheel>().SetSegmentSelected(this);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (equippedMask != MASKS.NONE)
        {
            FindObjectOfType<MaskWheel>().SetSegmentDeselected();
            background.color = Color.white;
        }
    }

}
