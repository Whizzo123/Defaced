using UnityEngine;
using System.Collections;


public class ProjectileLauncher : MonoBehaviour
{

    private BoxCollider2D targetArea;
    private GameObject targetGO;
    public GameObject projectilePrefab;
    public GameObject firePoint;

    public float fireRate;
    public float projectileSpeed;
    private float fireRateCounter;

    public Vector2 direction;

    void Start()
    {
        targetArea = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (targetGO != null)
        {
            if (fireRateCounter <= 0)
            {
                //Fire
                fireRateCounter = fireRate;
                direction = Vector3.Normalize((targetGO.transform.position + new Vector3(0,1,0)) - firePoint.transform.position);
                GameObject go = (GameObject)Instantiate(projectilePrefab, firePoint.transform.position, Quaternion.identity);
                go.GetComponent<Rigidbody2D>().velocity += new Vector2(direction.x * projectileSpeed, (direction.y) * projectileSpeed);
            }
            fireRateCounter -= Time.deltaTime;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerInputController>())
        {
            targetGO = other.gameObject;
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerInputController>())
        {
            targetGO = null;
        }
    }

}
