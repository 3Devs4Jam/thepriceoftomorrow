using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParentPosition : MonoBehaviour
{

    private GameObject parent;

    private SpriteRenderer parentSpriteRenderer;

    private SpriteRenderer thisSpriteRenderer;

    // Use this for initialization
    void Start()
    {
        parent = transform.parent.gameObject;
        parentSpriteRenderer = parent.GetComponent<SpriteRenderer>();
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 objectPosition = parent.transform.position;

        int order = parentSpriteRenderer.sortingOrder;

        if (mousePosition.y > objectPosition.y)
        {
            thisSpriteRenderer.sortingOrder = order - 1;
        }
        else
        {
            thisSpriteRenderer.sortingOrder = order + 1;
        }

        if (mousePosition.x > objectPosition.x)
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
            }
        }
    }
}
