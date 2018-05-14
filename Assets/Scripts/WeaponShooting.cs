using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour
{

    public GameObject shot;

    private float angle;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 objectPos = new Vector2(transform.position.x, transform.position.y);

            Vector2 heading = mousePos - objectPos;

            float distance = heading.magnitude;

            Vector2 direction = heading / distance;
            Vector2 normal = new Vector2(1f, 0f);

            angle = Vector2.Angle(normal, direction);

            if (mousePos.y < objectPos.y)
            {
                angle = 360f - angle;
            }

            Instantiate(shot, transform.position, Quaternion.Euler(0, 0, angle));
        }
    }
}
