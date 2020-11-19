using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSelection : MonoBehaviour
{

    public Sprite playSprite;
    public Sprite optionsSprite;
    public Sprite quitSprite;

    public Image image;

    public void DisplayPlaySprite()
    {
        image.sprite = playSprite;
    }

    public void DisplayOptionsSprite()
    {
        image.sprite = optionsSprite;
    }

    public void DisplayQuitSprite()
    {
        image.sprite = quitSprite;
    }

}
