using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : Interactable
{

    public bool isVertical;
    public bool startLeft;
    public bool move;
    public float moveDistance;
    private float direction;
    private Vector2 originPosition;
    private Vector2 targetVector;

    public override void Toggle()
    {
        move = !move;
    }

    void Start()
    {
        originPosition = this.transform.position;
        if (startLeft)
        {
            direction = -2;
        }
        else
        {
            direction = 2;
        }
    }

    void Update()
    {
        if (move)
        {
            if (isVertical)
            {
                this.transform.position = new Vector2(this.transform.position.x + (Time.deltaTime * direction), this.transform.position.y);
            }
            else
            {
                this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + (Time.deltaTime * direction));
            }
            float distance = Vector2.Distance(this.transform.position, originPosition);
            if (distance > moveDistance)
            {
                direction *= -1;
                originPosition = this.transform.position;
            }
        }
    }

}
