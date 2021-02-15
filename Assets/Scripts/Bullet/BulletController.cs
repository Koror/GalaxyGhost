using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float Speed;

    Vector3 direct;

    public bool Hostile = false;
    void Start()
    {
        direct = new Vector3(Speed, 0, 0);
    }

    void Update()
    {
        if(Hostile)
            gameObject.transform.position += direct * Time.deltaTime * -1;    
        else
            gameObject.transform.position += direct * Time.deltaTime;

        if (gameObject.transform.position.x > 12 || gameObject.transform.position.x < - 11)
        {
            Destroy(gameObject);
        }
    }

}
