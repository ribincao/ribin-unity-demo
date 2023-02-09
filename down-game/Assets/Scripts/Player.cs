using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private GameObject currentFloor;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            transform.Translate(-moveSpeed * Time.deltaTime, 0f, 0f);
        } else if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("NormalFloor"))
        {
            if (col.contacts[0].normal == new Vector2(0f, 1f))
            {
                Debug.Log("NormalFloor Enter");
                currentFloor = col.gameObject;
            }
        } else if (col.transform.CompareTag("TailsFloor"))
        {
            if (col.contacts[0].normal == new Vector2(0f, 1f))
            {
                Debug.Log("TailsFloor Enter");
                currentFloor = col.gameObject;
            }
        }else if (col.transform.CompareTag("Ceiling"))
        {
            Debug.Log("Ceiling Enter");
            currentFloor.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("DeathLine"))
        {
            Debug.Log("DeathLine Enter");
            Time.timeScale = 0; // 暂停
        }
    }
}