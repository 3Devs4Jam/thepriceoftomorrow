using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 3f;
    private float moveX;
    private float moveY;
    public float face; // 0 - up, 1 - right, 2 - down, 3 - left

    private bool[,] colliders;

    private Animator anim;

    private bool playerMoving;

    private int posicaoInicial = 23;

    private ArrayList openList;

    private ArrayList closedList;

    // Use this for initialization
    void Start()
    {

        openList = new ArrayList();
        closedList = new ArrayList();

        // Adicionando a posicao inicial na lista aberta
        openList.Add(posicaoInicial);

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("EnemyMoving", false);
        anim.SetFloat("Face", face);
    }
}
