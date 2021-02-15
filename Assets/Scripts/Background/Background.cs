using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject Background1;

    public GameObject Background2;

    private float border;

    public float Speed = 3;

    void Start()
    {
        Rect rect = Background1.GetComponent<SpriteRenderer>().sprite.rect;
        border = rect.width / 100;
        Background2.transform.position = new Vector2(border, 0);

    }

    void FixedUpdate()
    {
        Background1.transform.Translate(Vector2.left * Time.deltaTime * Speed);
        Background2.transform.Translate(Vector2.left * Time.deltaTime * Speed);

        if (Background1.transform.position.x <= -border)
        {
            Background1.transform.position = new Vector2(border, 0);
        }

        if (Background2.transform.position.x <= -border)
        {
            Background2.transform.position = new Vector2(border, 0);
        }
    }
}
