using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    #region Movement
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    [SerializeField] private bool facingRight = true;
    #endregion

    #region Jump
    [Header("Jump")]
    public float JumpPower;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius = 0.02f;

    [SerializeField] private bool isGrounded;
    #endregion

    #region Item Pick up
    [HideInInspector] public PlayerEquipment playerEquipment;

    [SerializeField] private Transform gunContainerPos;

    private GameObject gunObj;
    private Gun gunManager;
    private GameObject trapPrefab;
    #endregion

    public int ControllerIndex;

    private Rigidbody2D myRB;

    private void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
        playerEquipment = PlayerEquipment.Empty;
    }

    private void Update()
    {
        Shoot();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        // Move the Character
        float movement = Input.GetAxisRaw("Horizontal_" + ControllerIndex);
        myRB.velocity = new Vector2(movement * moveSpeed * Time.deltaTime, myRB.velocity.y);

        // Flip the Character acording to move diraction
        if (!facingRight && movement > 0)
        {
            Flip();
        }
        else if (facingRight && movement < 0)
        {
            Flip();
        }
    }

    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // For Regular Jump
        if (Input.GetAxisRaw("Jump_" + ControllerIndex) != 0 && isGrounded)
        {
            isGrounded = false;
            myRB.velocity = new Vector2(myRB.velocity.x, JumpPower * Time.deltaTime);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void Shoot()
    {
        if (Input.GetAxisRaw("Fire1_" + ControllerIndex) != 0 && gunManager)
        {
            gunManager.Shoot(facingRight);
        }
    }

    private void PutTrap()
    {
        print("Put Trap");
    }

    /// <summary>
    /// Take the item picked up from pick up base 
    /// </summary>
    /// <param name="item">the picked up item</param>
    public void TakeNewItem(GameObject item)
    {
        if (item.tag.Equals("Gun"))
        {
            if (!gunObj)
            {
                Destroy(gunObj);
            }

            playerEquipment = PlayerEquipment.Gun;
            gunObj = Instantiate(item, gunContainerPos, false) as GameObject;
            gunManager = gunObj.GetComponent<Gun>();
            //gunManager.Shoot();
        }
        else if (item.tag.Equals("Trap"))
        {
            playerEquipment = PlayerEquipment.Trap;
            trapPrefab = item;
        }
    }
}
