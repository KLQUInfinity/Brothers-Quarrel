using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickUp : MonoBehaviour
{
    public GameObject player;
    public GameObject positionOfItem;
    private Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")

        {
            animator.Play("itemused");
            Debug.Log("item got");
            gameObject.transform.position = positionOfItem.transform.position;
            gameObject.transform.SetParent(player.transform);

        }
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //void Update()
    //{
        
    //}
}
