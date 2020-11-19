using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public float laserFireRate;
    private float laserFireRateCounter;

    void Update()
    {
        if(laserFireRateCounter <= 0)
        {
            laserFireRateCounter = laserFireRate;
            Plane zeroPlane = new Plane(Vector3.down, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance;

            if(zeroPlane.Raycast(ray, out distance))
            {
                Vector2 outputPosition = ray.origin + ray.direction * distance;
                GetComponent<LineRenderer>().SetPosition(0, this.transform.position);
                GetComponent<LineRenderer>().SetPosition(1, outputPosition);
                Debug.DrawLine(this.transform.position, outputPosition);

            }
        }
        laserFireRateCounter -= Time.deltaTime;
    }

}
