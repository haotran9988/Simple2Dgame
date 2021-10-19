
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public static float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DragonGameControls.isGameOver)
        {
            return;
        }
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
        transform.position += Vector3.up * Mathf.Sin(Time.time) * Time.deltaTime;
    }
}
