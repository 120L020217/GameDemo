using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private Animator animator;
    // direction 1:right , -1:left
    private int dir = 1;
    private float startPosX;
    private bool isDie = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        startPosX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDie)
        {
            return;
        }

        transform.Translate(transform.right * Time.deltaTime * 0.8f * dir);

        if (transform.position.x > startPosX + 0.7f)
        {
            dir = dir * -1;
        }
        else if (transform.position.x < startPosX - 0.7f)
        {
            dir = dir * -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Ground")
        {
            dir = dir * -1;
        }
        /*if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("isDie");
            AudioManager.Instance.Play(2);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.0387F, 0);
            isDie = true;

            BoxCollider2D[] collider2Ds;
            collider2Ds = GetComponents<BoxCollider2D>();

            foreach (var item in collider2Ds)
            {
                Destroy(item);
            }
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(gameObject, 1F);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("isDie");
            AudioManager.Instance.Play(2);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.0387F, 0);
            isDie = true;

            BoxCollider2D[] collider2Ds;
            collider2Ds = GetComponents<BoxCollider2D>();
            
            foreach (var item in collider2Ds)
            {
                Destroy(item);
            }
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(gameObject, 1F);
        }
    }
    
}
