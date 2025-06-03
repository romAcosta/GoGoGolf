using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameOver gameOver;
    [SerializeField] TMP_Text text;
    bool launched = false;
    private float distance = 0;
    private float startX;

    private float timer = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (launched)
        {
            if (distance < (transform.position.x - startX))
            {
                text.text = (transform.position.x - startX).ToString("F2") + " m";
                distance = (transform.position.x - startX);
                timer = 3f;
            }
            else
            {
                print("hit");
                timer -= Time.deltaTime;
            }

            if (timer <= 0)
            {
                gameOver.EndGame(distance);
            }
        }
    }

    public void Launch()
    {
        launched = true;
    }
}
