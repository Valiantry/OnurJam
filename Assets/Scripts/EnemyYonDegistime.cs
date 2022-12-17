using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyYonDegistime : MonoBehaviour
{
    Vector2 temp;

    public Sprite sola, saga, yukariya, asagiya;
    void Update()
    {
        Sprite[] gay = { sola, saga, yukariya, asagiya };
        GetComponent<SpriteRenderer>().sprite = gay[Random r];

        temp = transform.position;


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
}