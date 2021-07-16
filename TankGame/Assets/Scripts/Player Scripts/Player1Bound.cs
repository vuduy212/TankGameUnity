using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Bound : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f)); //bat va cham voi khung
        minX = -bounds.x + 0.3f;
        maxX = bounds.x - 0.3f;
        minY = -bounds.y + 0.6f;
        maxY = bounds.y - 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position; //vi tri cua player

        //neu vuot qua gioi han thi dat lai ve gioi han

        if(temp.x < minX)
        {
            temp.x = minX;
        } else if(temp.x > maxX)
        {
            temp.x = maxX;
        }

        if (temp.y < minY)
        {
            temp.y = minY;
        }
        else if (temp.y > maxY)
        {
            temp.y = maxY;
        }

        transform.position = temp;
    }
}
