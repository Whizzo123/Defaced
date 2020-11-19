using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float movementSpeed;
    public float thresholdDistance;

    public GameObject target;

    void Update()
    {
        if (Vector2.Distance(this.transform.position, target.transform.position) > thresholdDistance)
        {
            Vector2 moveVector = Vector2.Lerp(this.transform.position, target.transform.position, Time.deltaTime * movementSpeed);

            this.transform.position = new Vector3(moveVector.x, moveVector.y, -10f);
        }
    }
}
