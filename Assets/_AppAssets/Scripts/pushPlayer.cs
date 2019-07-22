using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushPlayer : MonoBehaviour
{
    float sspeed = 10f;

    private Animator anim;
    public GameObject player;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        anim.Play("SpringPressed");
    //        Debug.Log(" player pressed spring");
    //    }
    //}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.Play("SpringPressed");
            Debug.Log(" player pressed spring");
        }
    }
    public void playerPush()
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, sspeed);

    }

}
