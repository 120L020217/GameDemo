using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mario : MonoBehaviour
{
    // animator component
    private Animator animator;
    
    private bool isOnGround;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        
        AudioManager.Instance.CheckBG();
    }

    // Update is called once per frame
    void Update()
    {
        // access the value of keyboard, -1 0 1
        float h = Input.GetAxis("Horizontal");
        // which means mario move
        if (h != 0f) 
        {
            transform.Translate(h * transform.right * Time.deltaTime);
            if (h > 0f)
            {
                GetComponent <SpriteRenderer>().flipX = false;

            }
            if (h < 0f)
            {
                GetComponent <SpriteRenderer>().flipX = true;
            }
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }

        if (isOnGround && Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 180);
            AudioManager.Instance.Play(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("mario collision invoked");
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("isJump", false);
            isOnGround = true;
        }
        else if (collision.gameObject.tag == "Mushroom")
        {
            animator.SetTrigger("isDie");
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
            Destroy(GetComponent<CapsuleCollider2D>());
            AudioManager.Instance.Play(0, true);
            Invoke("GameOver", 3.5f);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("isJump", true);
            isOnGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gold")
        {
            Debug.Log("mario trigger invoked");
            UIManager.Instance.GoldNum += 1;
            Debug.Log("mario trigger invoked 1");
            Destroy(collision.gameObject);
            AudioManager.Instance.Play(3);
        }
        else if (collision.gameObject.tag == "WinObject")
        {
            int currLV = SceneManager.GetActiveScene().buildIndex;

            if (currLV == SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(currLV + 1);
            }
        }
    }
}
