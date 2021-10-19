
using UnityEngine;

public class FireBall : MonoBehaviour
{
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DragonGameControls.isGameOver)
        {
            return;
        }
        rb.velocity = new Vector2(5, 0);
        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<AudioManager>().PlaySound("Collect");
            DragonGameControls.score++;
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }

}
