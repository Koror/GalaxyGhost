using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Boom;
    public int AmmoIncrease = 2;
    public int AmmoStart = 5;
    public float Acceleration = 30;
    public float DelayBullet = 0.3f;

    private Animator animator;
    private bool life = true;
    private int ammo;
    private int multRotate = 6;
    private int borderRotate = 80;
    private Vector2 force = new Vector2(0, 0);
    private Vector3 bulletOffset = new Vector3(0.1f, 0, 0);
    private float deltaTimeBullet = 0;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        force.y = Acceleration;
        ammo = AmmoStart;
        GameManager.Instance.AmmoUI.UpdateAmmo(ammo);
    }

    void FixedUpdate()
    {
        //move
        if (life)
        {
            //phone
            Touch[] touches = Input.touches;
            for (int i = 0; i < touches.Length; i++)
                if (Input.GetTouch(i).position.x < Screen.width / 2)
                {
                    rb.AddForce(force);
                }
            //pc
            if (Input.GetKey(KeyCode.Space))
                rb.AddForce(force);

            rb.rotation = rb.velocity.y * multRotate;
            if (rb.rotation >= borderRotate)
                rb.rotation = borderRotate;
            if (rb.rotation <= -borderRotate)
                rb.rotation = -borderRotate;
        }
    }

    void Update()
    {
        //attack
        if (life)
        {
            deltaTimeBullet += Time.deltaTime;
            //phnoe
            Touch[] touches = Input.touches;
            for (int i = 0; i < touches.Length; i++)
                if ((Input.GetTouch(i).position.x > Screen.width / 2) && (deltaTimeBullet > DelayBullet) && ammo > 0)
                {
                    ammo--;
                    GameManager.Instance.AmmoUI.UpdateAmmo(ammo);
                    deltaTimeBullet = 0;
                    GameObject bullet = Instantiate(Bullet, rb.transform.position + bulletOffset, Quaternion.identity);
                    bullet.GetComponent<BulletController>().Hostile = false;
                }
            //pc
            if (Input.GetKey(KeyCode.F) && (deltaTimeBullet > DelayBullet) && ammo > 0)
            {
                ammo--;
                GameManager.Instance.AmmoUI.UpdateAmmo(ammo);
                deltaTimeBullet = 0;
                GameObject bullet = Instantiate(Bullet, rb.transform.position + bulletOffset, Quaternion.identity);
                bullet.GetComponent<BulletController>().Hostile = false;
            }

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (life)
        {
            if ((collision.gameObject.tag == "meteor") || (collision.gameObject.tag == "border_laser"))
            {
                DestroyPlayer();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (life)
        {
            if (other.gameObject.tag == "cristal")
            {
                Destroy(other.gameObject);
                Score.Instance.SCORE++;
                Score.Instance.UpdateScore();
                ammo += AmmoIncrease;
                GameManager.Instance.AmmoUI.UpdateAmmo(ammo);
            }

            if (other.gameObject.tag == "bullet")
            {
                if (other.GetComponent<BulletController>().Hostile)
                {
                    Destroy(other.gameObject);
                    DestroyPlayer();
                }
            }
        }
    }

    private void DestroyPlayer()
    {
        GameManager.Instance.ResultController.Activate();
        animator.SetBool("Life", false);
        life = false;
        rb.gravityScale = 0;
        Instantiate(Boom, transform.position, Quaternion.identity);
    }
}
