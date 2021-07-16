using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;

    public float enemySpeed;

    private Rigidbody2D myBody;

    [SerializeField]
    private GameObject bullet;

    [SerializeField] private AudioClip weaponEnemyClip;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        if (GamePlayController.instance.playerScore < 10)
        {
            enemySpeed = Random.Range(2, 4);
        };

        if (10 <= GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 20)
        {
            enemySpeed = Random.Range(3, 5);
        };

        if (20 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 30)
        {
            enemySpeed = Random.Range(4, 6);
        };

        if (30 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 40)
        {
            enemySpeed = Random.Range(5, 7);
        };

        if (40 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 50)
        {
            enemySpeed = Random.Range(6, 8);
        };

        if (50 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 60)
        {
            enemySpeed = Random.Range(7, 9);
        };

        if (60 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 70)
        {
            enemySpeed = Random.Range(8, 10);
        };

        if (70 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 80)
        {
            enemySpeed = Random.Range(9, 11);
        };

        if (80 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 90)
        {
            enemySpeed = Random.Range(10, 12);
        };

        if (90 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 100)
        {
            enemySpeed = Random.Range(11, 13);
        };

        if (GamePlayController.instance.playerScore > 100)
        {
            enemySpeed = Random.Range(12, 14);
        };
        StartCoroutine(EnemyShoot());  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(0f, -enemySpeed);
    }

    IEnumerator EnemyShoot()
    {
        if (GamePlayController.instance.playerScore <= 30)
        {
            yield return new WaitForSeconds(Random.Range(0.7f, 1f));
        };

        if (30 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 60)
        {
            yield return new WaitForSeconds(Random.Range(0.4f, 0.7f));
        };

        if (GamePlayController.instance.playerScore > 60)
        {
            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
        };

        Vector3 temp = transform.position;

        if (GamePlayController.instance.playerScore <= 20)
        {
            temp.y -= 0.4f;
        };

        if (20 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 40)
        {
            temp.y -= 0.45f;
        };

        if (40 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 60)
        {
            temp.y -= 0.5f;
        };

        if (60 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 80)
        {
            temp.y -= 0.55f;
        };


        if (GamePlayController.instance.playerScore > 80)
        {
            temp.y -= 0.6f;
        };



        Instantiate(bullet, temp, Quaternion.identity);

        AudioSource.PlayClipAtPoint(weaponEnemyClip, temp);

        StartCoroutine(EnemyShoot());
        /*yield return new WaitForSeconds(Random.Range(1f, 3f));
        Vector3 temp = transform.position;
        temp.y -= 1f;
        Instantiate(bullet, temp, Quaternion.identity);

        StartCoroutine(EnemyShoot());*/
    }

    void OnTriggerEnter2D(Collider2D target) //xu ly va cham voi trigger
    {
        if (target.tag == "Border")
        {
            Destroy(gameObject);
        }
    }
}
