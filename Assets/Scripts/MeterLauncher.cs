using UnityEngine;
using UnityEngine.UI;

public class MeterLauncher : MonoBehaviour
{
    [SerializeField] private GameObject launcher;
    [SerializeField] Image meterImage;
    [SerializeField] Slider slider;
    [SerializeField] private float changeRate = .213f;
    [SerializeField] private Rigidbody2D ball;
    [SerializeField] private CameraFollow cam;
    
    
    public float multiplier = 1.5f;
    bool meterLaunched = false;
    private Vector2 direction = Vector2.zero;
    
    void Start()
    {
        
    }

    public Vector2 Direction
    {
        get => direction;
        set => direction = value;
    }


    void Update()
    {
        if (!meterLaunched)
        {
            changeRate *= ((slider.value >= 1) || (slider.value <= 0)) ? -1 : 1;
            slider.value += changeRate * Time.deltaTime;
        
            float t = Mathf.InverseLerp(0f, 1f, slider.value);
            Color newColor = Color.Lerp(Color.red, Color.green, t);
            meterImage.material.color = newColor;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !meterLaunched)
        {
            meterLaunched = true;
            ball.AddForce(direction * (slider.value * multiplier), ForceMode2D.Impulse);
            gameObject.SetActive(false);
            launcher.SetActive(false);
            cam.enabled = true;

        }
    }
}
