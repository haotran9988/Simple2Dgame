
using UnityEngine;

public class PlayerDragon : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce;  
    public static bool isJump;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FindObjectOfType<AudioManager>().PlaySound("MainTheme");
    }

    // Update is called once per frame
    void Update()
    {
        if (DragonGameControls.isGameOver)
        {
            return;
        }
        if (isJump || Input.GetKeyDown(KeyCode.UpArrow))
        {
           
            rb.AddForce(Vector2.up * jumpForce);
            isJump = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            FindObjectOfType<AudioManager>().PlaySound("Hit");
            DragonGameControls.health -= 15;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.CompareTag("Tree"))
        {
            FindObjectOfType<AudioManager>().PlaySound("Hit");
            DragonGameControls.health -= 10;
            Destroy(col.gameObject);
        }
        if(col.CompareTag("Enemy"))
        {
            FindObjectOfType<AudioManager>().PlaySound("Hit");
            DragonGameControls.health -= 5;
            Destroy(col.gameObject);
        }
    }
}
