using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    Rigidbody2D rb;

    public static float moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControls.isGameOver)
        {
            return;
        }
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Wall"))
        {
            GameControls.score++;
            Destroy(gameObject);
        }
    }
}
