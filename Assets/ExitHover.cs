using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ExitHover : MonoBehaviour, IPointerEnterHandler
{
    public ImageSelection imageSelection;

    public void OnPointerEnter(PointerEventData eventData)
    {
        imageSelection.DisplayQuitSprite();
    }
}