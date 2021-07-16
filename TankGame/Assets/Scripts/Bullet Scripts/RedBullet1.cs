using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet1 : MonoBehaviour
{
    public float speed;

    private Rigidbody2D myBody;
    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(0f, -speed);
    }

	void Start()
	{

		if (GamePlayController.instance.playerScore <= 10)
		{
			speed = 5;
		};
		if (10 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 20)
		{
			speed = 6;
		};

		if (20 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 30)
		{
			speed = 7;
		};

		if (30 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 40)
		{
			speed = 8;
		};

		if (40 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 50)
		{
			speed = 9;
		};

		if (50 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 60)
		{
			speed = 10;
		};

		if (60 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 70)
		{
			speed = 11;
		}

		if (70 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 80)
		{
			speed = 12;
		}

		if (80 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 90)
		{
			speed = 13;
		}

		if (90 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 100)
		{
			speed = 14;
		}

		if (GamePlayController.instance.playerScore > 100)
		{
			speed = 16;
		}

	}

	void OnTriggerEnter2D(Collider2D target) //xu ly va cham voi trigger
    {
        if (target.tag == "Border")
        {
            Destroy(gameObject);
        }
    }
}
