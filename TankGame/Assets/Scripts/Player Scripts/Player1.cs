using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{

    public float playerSpeed;

    private Rigidbody2D myBody;

    [SerializeField]
    private GameObject bullet;

    private bool canShoot = true;

    [SerializeField] private AudioClip weaponClip;

    [SerializeField] private GameObject explosionPlayer;

    [SerializeField] private AudioClip explosionPlayerClip;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate() // di chuyen 1 doi tuong co vat ly
    {
        PlayerMovement();
    }

    void Update() // ham Shoot
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (canShoot)
            {
                StartCoroutine(Shoot());
            }
            //Instantiate(bullet, transform.position, Quaternion.identity); //tao ban sao cua vien dan, ban ra tai vi tri player, va vien dan khong xoay
        }
    }

/*    void MouseByMove()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 Mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Mouse = new Vector3(Mouse.x, Mouse.y, 0);
        }
        transform.position = Vector3.Lerp(transform.position, Mouse, playerSpeed * Time.deltaTime);
    }*/

    void PlayerMovement()
    {
        float xAxis = Input.GetAxisRaw("Horizontal") * playerSpeed;
        float yAxis = Input.GetAxisRaw("Vertical") * playerSpeed;
        myBody.velocity = new Vector2(xAxis, yAxis);

    }

    IEnumerator Shoot()
    {
        canShoot = false;

        // de dan ban ra tu dau nong xe tang
        Vector3 temp = transform.position;
        temp.y += 0.6f;
        Instantiate(bullet, temp, Quaternion.identity);
        AudioSource.PlayClipAtPoint(weaponClip, temp); // them am thanh khi ban dan
        yield return new WaitForSeconds(0.2f); //0,2 giay ban ra vien dan 1 lan
        canShoot = true;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy" || target.tag == "RedBullet")
        {
            Destroy(gameObject);
            Destroy(target.gameObject);
            //hieu ung no
            explosionPlayer = (GameObject)Instantiate(explosionPlayer, target.transform.position, Quaternion.identity);
            Destroy(explosionPlayer, 1);

            if (GamePlayController.instance != null)
            {
                GamePlayController.instance.PlayerDiedShowPanel();
            }
            //am thanh no
            AudioSource.PlayClipAtPoint(explosionPlayerClip, transform.position);
        }
    }

}
