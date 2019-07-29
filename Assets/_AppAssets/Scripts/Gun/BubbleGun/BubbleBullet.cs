using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBullet : MonoBehaviour
{
    [SerializeField] private float shootSpeed;

    private Rigidbody2D myRB;

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    public void Shoot(bool facingRight)
    {
        if (!myRB)
        {
            myRB = GetComponent<Rigidbody2D>();
        }

        if (!facingRight)
        {
            myRB.velocity = new Vector2(-1 * shootSpeed, 0);
        }
        else if (facingRight)
        {
            myRB.velocity = new Vector2(1 * shootSpeed, 0);
        }

        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}
