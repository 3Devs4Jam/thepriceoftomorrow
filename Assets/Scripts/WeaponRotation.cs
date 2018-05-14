using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 objectPos = new Vector2(transform.position.x, transform.position.y);

        Vector2 heading = mousePos - objectPos;

        float distance = heading.magnitude;

        Vector2 direction = heading / distance;
        Vector2 normal = new Vector2(1f, 0f);

        float angle = Vector2.Angle(normal, direction);

        if (mousePos.x > objectPos.x && mousePos.y > objectPos.y)
        {
            // no changes
        }
        if (mousePos.x < objectPos.x && mousePos.y > objectPos.y)
        {
            angle = 180 + angle; // flipped image
        }
        if (mousePos.x < objectPos.x && mousePos.y < objectPos.y)
        {
            angle = 180 - angle; // flipped image
        }
        if (mousePos.x > objectPos.x && mousePos.y < objectPos.y)
        {
            angle = -angle;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
