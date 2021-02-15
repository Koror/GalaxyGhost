using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    [HideInInspector]
    public float Speed = 10;

    void FixedUpdate()
    {
        gameObject.transform.Translate(Vector2.left * Time.deltaTime * Speed);
    }

    void Update()
    {
        if (this.transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }
}
