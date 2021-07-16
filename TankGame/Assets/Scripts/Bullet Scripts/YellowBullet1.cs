    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBullet1 : MonoBehaviour
{
    public float speed;

    private Rigidbody2D myBody;

    [SerializeField] private GameObject explosionEnemy;

    [SerializeField] private AudioClip explosionEnemyClip;
    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(0f, speed);
    }

    void OnTriggerEnter2D(Collider2D target) //xu ly va cham voi trigger
    {
        if (target.tag == "Enemy")
        {
            Destroy(target.gameObject);
            Destroy(gameObject);
            explosionEnemy = (GameObject)Instantiate(explosionEnemy, target.transform.position, Quaternion.identity);
            Destroy(explosionEnemy, 1);
            GamePlayController.instance.playerScore++; //cong diem
            AudioSource.PlayClipAtPoint(explosionEnemyClip, target.transform.position);
        }
        if (target.tag == "Border")
        {
            Destroy(gameObject);
        }
    }
}
