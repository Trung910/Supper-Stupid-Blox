using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerSence2 : MonoBehaviour
{
    public float Speed;
    private float Move = 1f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 315);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 225);
        }
        transform.Translate(Vector3.up * Move * Speed * Time.deltaTime);

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

}
