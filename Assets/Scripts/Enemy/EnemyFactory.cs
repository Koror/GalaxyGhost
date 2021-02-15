using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject Enemy;

    private List<GameObject> enemies = new List<GameObject>();

    private Vector2 startPos = new Vector2(11f, 0);

    public float timeDelay = 6f;
    bool isDelay;
    private float delay = 0;

    private int[] enemCount = { 1, 1, 2, 2, 3, 3 };
    private int counterForEnemCount = 0;

    void Start()
    {
        isDelay = true;
    }

    void Update()
    {
        if (isDelay)
        {
            delay += Time.deltaTime;
            if (delay >= timeDelay)
            {

                isDelay = false;
                delay = 0;
            } 
        }

        if ((isDelay == false) && (enemies.Count == 0))
        {
            for(int i = enemCount[counterForEnemCount]; i>0 ;i--)
                spawnEnemy();
            if(counterForEnemCount+1<enemCount.Length)
                counterForEnemCount++;
        }
    }

    private void spawnEnemy()
    {
        GameObject en = Instantiate(Enemy, startPos, Quaternion.identity);
        enemies.Add(en);
    }

    public void EnemyDie(GameObject go)
    {
        enemies.Remove(go);
        if (enemies.Count == 0)
            isDelay = true;
        Destroy(go);
        
    }
}
