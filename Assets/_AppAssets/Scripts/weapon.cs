using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotpoint;
    private float timebtwShots;
    public float startTimebtwShots;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timebtwShots <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(projectile, shotpoint.position, transform.rotation);
                timebtwShots = startTimebtwShots;
            }
        }else
        {
            timebtwShots -= Time.deltaTime;
        }
    }
}
