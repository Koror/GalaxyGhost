using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFactory : MonoBehaviour
{

    public GameObject meteor;
    public GameObject cristal;

    public float time = 2;

    public float speed = 10;

    private float spawn = 11;

    private float range = 5;

    private float curr_time;

    private float multSpeed=0;

    public float multSpeedScale = 1;


    void Start()
    {
        curr_time = time;

        meteor.GetComponent<MeteorController>().Speed = speed;
        cristal.GetComponent<MeteorController>().Speed = speed;
    }

    
    void Update()
    {
        multSpeed += Time.deltaTime * multSpeedScale;
        curr_time -= Time.deltaTime;

        if (curr_time <= 0)
        {
            if (Random.Range(0, 2) == 0)
            {
               GameObject go = Instantiate(meteor, new Vector2(spawn, Random.Range(-range, range)), Quaternion.identity);
               go.GetComponent<MeteorController>().Speed = speed + multSpeed;
            }
            else
            {
                GameObject go = Instantiate(cristal, new Vector2(spawn, Random.Range(-range, range)), Quaternion.identity);
                go.GetComponent<MeteorController>().Speed = speed + multSpeed;
            }
            curr_time = time;
        }
    }

}
