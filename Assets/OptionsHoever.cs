using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class OptionsHoever : MonoBehaviour, IPointerEnterHandler
{
    public ImageSelection imageSelection;

    public void OnPointerEnter(PointerEventData eventData)
    {
        imageSelection.DisplayOptionsSprite();
    }
}
