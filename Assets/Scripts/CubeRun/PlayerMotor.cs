using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMotor : MonoBehaviour
{
    public float jumpForce;
    Rigidbody2D rb;
   
    bool isGround;
    public static bool isJump;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJump = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameControls.isGameOver)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            isJump = true;
        }
        if (isJump && isGround)
        {
            rb.AddForce(Vector2.up * jumpForce);
            isGround = false;
            isJump = false;
            FindObjectOfType<AudioManager>().PlaySound("JumpSound");
        }

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
        if (col.gameObject.CompareTag("Obstacle") && !GameControls.isGameOver)
        {
            FindObjectOfType<AudioManager>().PlaySound("LoseSound");
            GameControls.isGameOver = true;
        }
    }

}
