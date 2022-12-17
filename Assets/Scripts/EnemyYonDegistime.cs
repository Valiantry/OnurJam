using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyYonDegistime : MonoBehaviour
{
    public Sprite sola, saga, yukariya, asagiya;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Sprite[] gay = { sola, saga, yukariya, asagiya };
        GetComponent<SpriteRenderer>().sprite = gay[Random r];

    }

    void yatayCevir()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        Vector3 velocity = rigidbody.velocity;
        if (velocity.x>velocity.y)
        {
            if (velocity.x < 0)
            {
                GetComponent<SpriteRenderer>().sprite = sola;
            }
            else if (velocity.x > 0)
            {
                GetComponent<SpriteRenderer>().sprite = saga;
            }
        }
    }

    void dikeyCevir()
    {
        Rigidbody2D rigidbody=GetComponent<Rigidbody2D>();
        Vector3 velocity = rigidbody.velocity;

        if (velocity.y>velocity.x)
        {
            if (velocity.y<0)
            {
                GetComponent<SpriteRenderer>().sprite = asagiya;
            }
            else if (velocity.y>0)
            {
                GetComponent<SpriteRenderer>().sprite = yukariya;
            }
        }

    }
}