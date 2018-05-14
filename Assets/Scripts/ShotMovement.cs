using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour
{

    public float speed;

    public float distance;

    public float offset;

    private Vector2 direction;

    private Vector3 startPosition;

    // Use this for initialization
    void Start()
    {
        WeaponShooting shotgun = FindObjectOfType<WeaponShooting>();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 objectPos = new Vector2(shotgun.transform.position.x, shotgun.transform.position.y);
        Vector2 heading = mousePos - objectPos;
        float distance = heading.magnitude;
        direction = heading / distance;
        transform.position += new Vector3(direction.x * offset, direction.y * offset, 0f);
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(direction.x * speed * Time.deltaTime, direction.y * speed * Time.deltaTime, 0f);

        if ((transform.position - startPosition).magnitude > distance)
        {
            Destroy(gameObject);
        }
    }
}
