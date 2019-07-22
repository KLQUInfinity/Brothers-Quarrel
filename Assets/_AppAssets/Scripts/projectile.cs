using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        Destroybullet();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }
    void Destroybullet()
    {
        Destroy(gameObject,lifetime);
    }
}
