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
        background.sprite = sprites.background;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        FindObjectOfType<MaskWheel>().SetSegmentSelected(this);
        GetComponent<Image>().color = Color.grey;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        FindObjectOfType<MaskWheel>().SetSegmentDeselected();
        GetComponent<Image>().color = Color.white;
    }

}
