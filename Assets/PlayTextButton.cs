using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayTextButton : MonoBehaviour, IPointerEnterHandler
{
    public ImageSelection imageSelection;

    public void OnPointerEnter(PointerEventData eventData)
    {
        imageSelection.DisplayPlaySprite();
    }


}
