using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSence3 : MonoBehaviour
{
    public float Speed = 10;
    private float Move = 1;
    private bool Jump;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Jump)
        { rb.gravityScale = rb.gravityScale * -1; }
        
    }
    private void FixedUpdate()
    {
        Vector2 vt = new Vector2(Move * Speed, rb.velocity.y);
        rb.velocity = vt;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Barrier")
        {
            SceneManager.LoadScene("Scene01");
        }
        if (collision.gameObject.tag == "NextSence")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Neutral")
        {
            Jump = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Jump = false;
    }
}

