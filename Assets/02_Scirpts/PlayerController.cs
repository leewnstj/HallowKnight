using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float playerSpeed;
    [SerializeField] float jumpPower;
    [SerializeField] float jumpDis;
    [SerializeField] int maxJump;

    [SerializeField] LayerMask ground_Layer;

    public bool isJump;
    public bool twiceJump;

    private float inputX;
    private int currentJump;

    private Rigidbody2D rigid;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(inputX * playerSpeed, rigid.velocity.y);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, jumpDis, ground_Layer);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(currentJump < maxJump)
            {
                currentJump++;
                rigid.velocity = Vector2.up * jumpPower;
            }
        }
        if (hit)
        {
            currentJump = 0;
        }
    }
}
