using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public float speed = 3f;
    public float moveX;
    public float moveY;

    private Animator anim;

    private bool playerMoving;
    private Vector2 lastMove;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;

        HandleKeyDown();

        HandleKeyUp();

        this.gameObject.transform.position += new Vector3(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 0f);

        if (moveX != 0 || moveY != 0)
        {
            playerMoving = true;
            lastMove = new Vector2(moveX, moveY);
        }

        anim.SetFloat("MoveX", moveX);
        anim.SetFloat("MoveY", moveY);
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }

    private void HandleKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveX = 1f;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveX = -1f;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveY = 1f;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveY = -1f;
        }
    }

    private void HandleKeyUp()
    {
        if ((moveX == 1f && Input.GetKeyUp(KeyCode.D)) || (moveX == -1f && Input.GetKeyUp(KeyCode.A)))
        {
            moveX = 0;
        }
        if ((moveY == 1f && Input.GetKeyUp(KeyCode.W)) || (moveY == -1f && Input.GetKeyUp(KeyCode.S)))
        {
            moveY = 0;
        }
    }
}
