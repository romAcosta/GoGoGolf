using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] GameObject startMenuText;
    [SerializeField] GameObject startLaunch;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startLaunch.SetActive(true);
            startMenuText.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
