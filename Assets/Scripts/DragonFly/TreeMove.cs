
using UnityEngine;

public class TreeMove : MonoBehaviour
{
    public static float speed = 2;
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
            transform.position += new Vector3(30, 0, 0);
            RandomShowSprite();
        }
    }
    void RandomShowSprite()
    {
        int index = Random.Range(0, 3);
        int childCount = transform.childCount;
        for(int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            bool showIndex = index == i;
            child.gameObject.SetActive(showIndex);
        }
    }
    private void OnEnable()
    {
        RandomShowSprite();
    }
}
