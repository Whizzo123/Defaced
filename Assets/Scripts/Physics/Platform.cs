using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public bool isVertical;
    public bool startLeft;
    public bool move;
    public float moveDistance;
    private float direction;
    private Vector2 originPosition;
    private Vector2 targetVector;

    void Start()
    {
        originPosition = this.transform.position;
        if (startLeft)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
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
            Debug.Log("Distance: " + distance);
            if (distance > moveDistance)
            {
                Debug.Log("Got to target");
                direction *= -1;
                originPosition = this.transform.position;
            }
        }
    }

}
