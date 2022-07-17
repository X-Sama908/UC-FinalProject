using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour

{
    Rigidbody2D rb;
    public float speed;
    public float jump;
    public bool CanJump=false;
    public Animator animator;
     bool hasKey = false;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "floor")
        {
            CanJump = true;
            animator.SetBool("Jump", false);
        }

        else if (collision.gameObject.tag == "Enemey")
            Destroy(collision.gameObject);

        else if (collision.gameObject.tag == "death")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        else if (collision.gameObject.tag == "wind")
            SceneManager.LoadScene("level2");

        else if (collision.gameObject.tag == "key")
        {
            hasKey = true;
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag == "door" && hasKey)
            SceneManager.LoadScene("level3");

        else if (collision.gameObject.tag == "wind3")
            SceneManager.LoadScene("end");
        

    }

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.gameObject.tag == "Enemey")
            Destroy(collision.gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        jump = 5;
        speed = 10;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 temp = rb.velocity;

        if (CanJump && Input.GetKeyDown(KeyCode.Space))
        {
            temp.y = jump;
            CanJump = false;
            animator.SetBool("Jump", true);
        }
        temp.x = Input.GetAxis("Horizontal") * speed;
        rb.velocity = temp;
    }

   

    

}
