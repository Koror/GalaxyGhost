using UnityEngine;

public class EnemyController : Subject
{
    public GameObject Boom;
    public GameObject Bullet;
    public float Speed;

    private float top = 5.5f;
    private float bottom = -5.5f;
    private float endXPos = 7.5f;
    private float xSpeed = 7;
    private Vector3 bulletOffset = new Vector3(-0.3f, 0, 0);

    private Vector2 endPoint;
    private float direction;

    void Start()
    {
        GenerateEndPoint();
    }

    void FixedUpdate()
    {
        //move to position
        if (gameObject.transform.position.x > endXPos)
        {
            gameObject.transform.position -= new Vector3(xSpeed, 0, 0) * Time.deltaTime;
        }
        else
        {
            if ((endPoint.y - transform.position.y) * direction > 0)
            {
                transform.position = transform.position + new Vector3(0, Speed * Time.deltaTime * direction, 0);
            }
            else
            {
                GenerateEndPoint();
                GameObject bull = Instantiate(Bullet, transform.position + bulletOffset, Quaternion.identity);
                bull.GetComponent<BulletController>().Hostile = true;
            }
        }
    }

    void GenerateEndPoint()
    {
        endPoint = new Vector2(transform.position.x, Random.Range(bottom, top));
        if (endPoint.y - transform.position.y < 0)
            direction = -1;
        else
            direction = 1;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "bullet" && (!col.GetComponent<BulletController>().Hostile))
        {
            Notify();
            EnemyFactory enemyFactory = (EnemyFactory)FindObjectOfType(typeof(EnemyFactory));
            Instantiate(Boom, transform.position, Quaternion.identity);
            enemyFactory.EnemyDie(gameObject);
            Destroy(col.gameObject);
        }
    }
    

}
