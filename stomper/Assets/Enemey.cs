using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemey : MonoBehaviour
{
    public int direction;
    public float speed;
    public Rigidbody2D rb;
    public GameObject RightT;
    public GameObject LeftT;
    

    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;
        direction = 1;
        //rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.right * speed * direction;

        if (direction > 0)
        {
            Collider2D check = Physics2D.OverlapBox(RightT.transform.position, Vector2.one * 0.5f, 0f);
            Debug.Log(check);

            if (check == null || check.tag !="floor")
                direction = -direction;
        }

        if (direction < 0)
        {
            Collider2D check = Physics2D.OverlapBox(LeftT.transform.position, Vector2.one * 0.5f, 0f);

            if (check == null || check.tag != "floor")
                direction = -direction;
        }

    }

    /* private void OnTriggerExit2D(Collider2D collition)
    {
        if (collition.gameObject.tag == "floor")
            direction = -direction;
    }

     
     */
    

} 


