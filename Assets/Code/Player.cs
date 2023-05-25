using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public float Speed = 10;
    private float Move =1;
    private float Hight = 0;
    private Rigidbody2D rb;
    private bool Jump;

    private bool Change_Way;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Jump)
        {
            Hight = 15;
            Jump = false;
        }
        else
        { Hight = 0; }
        rb.AddForce(Vector2.up * Hight, ForceMode2D.Impulse);
    }
    private void FixedUpdate()
    {
        Vector2 vt = new Vector2(Move * Speed, rb.velocity.y);
        rb.velocity = vt;
    }
    //Tiếp Xúc với Collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Điều kiện nhảy
        if (collision.gameObject.tag == "Neutral" || collision.gameObject.tag == "Barrier")
        {
            Jump = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
     Jump = false;
    }
    //Tiếp xúc với Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Điều kiện Load Scene
        if (collision.gameObject.tag == "Barrier")
        {
            SceneManager.LoadScene("Scene01");
        }
        //Đổi Scene
        if (collision.gameObject.tag == "NextSence")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        //Chuyển Hướng
        if (collision.gameObject.tag == "Redirect")
        {
            Move = Move * -1;
        }
        //Chuyển hướng trọng lực
        if (collision.gameObject.tag == "RedirectU&D")
        {
            rb.gravityScale = rb.gravityScale * -1;
        }
        //Nhảy đôi
        if (collision.gameObject.tag == "DoubleJump")
        {
            Hight = 20;
            rb.AddForce(Vector2.up * Hight, ForceMode2D.Impulse);
        }
        //Click để nhảy
        if (collision.gameObject.tag == "ClickToJump")
        {
            Jump = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Hight = 20;
                rb.AddForce(Vector2.up * Hight, ForceMode2D.Impulse);
            }
        }
        if ((collision.gameObject.tag == "ClickToDJ&RD"))
        {
            Debug.Log("Jump");
            Jump = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("test");
                Hight = 15;
                rb.AddForce(Vector2.up * Hight, ForceMode2D.Impulse);
                Move *= -1;
            }
        }
        //Nhay đôi và chuyển hướng
        if (collision.gameObject.tag == "DJ&RD")
        {
            Hight = 15;
            rb.AddForce(Vector2.up * Hight, ForceMode2D.Impulse);
            Move *= -1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)  
    {
        Jump = false;
    }
}

