using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotRotation : MonoBehaviour
{
    private WeaponShooting shotgun;

    private float angle;

    // Use this for initialization
    void Start()
    {
        shotgun = FindObjectOfType<WeaponShooting>();

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 objectPos = new Vector2(shotgun.transform.position.x, shotgun.transform.position.y);

        Vector2 heading = mousePos - objectPos;

        float distance = heading.magnitude;

        Vector2 direction = heading / distance;
        Vector2 normal = new Vector2(1f, 0f);

        angle = Vector2.Angle(normal, direction);

        if (mousePos.y < objectPos.y)
        {
            angle = 360f - angle;
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
