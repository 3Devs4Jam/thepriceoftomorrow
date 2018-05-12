using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public float speed = 3f;
    public float moveX;
    public float moveY;
    public float faceX;
    public float faceY;

    private Animator anim;

    private bool playerMoving;

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

        HandleMouseMovement();

        this.gameObject.transform.position += new Vector3(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 0f);

        if (moveX != 0 || moveY != 0)
        {
            playerMoving = true;
        }

        anim.SetFloat("MoveX", faceX);
        anim.SetFloat("MoveY", faceY);
        anim.SetBool("PlayerMoving", playerMoving);
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

    private void HandleMouseMovement()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 objectPos = new Vector2(transform.position.x, transform.position.y);

        Vector2 difference = objectPos - mousePos;

        Vector2 normal = new Vector2(objectPos.x, objectPos.y + 1f);

        faceX = 0f;
        faceY = 0f;

        float angle = Vector2.Angle(normal, difference);

        Debug.Log("Angle: " + angle);
    }
}
