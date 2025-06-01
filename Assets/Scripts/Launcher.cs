using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private GameObject meter;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject point;
    [SerializeField] private float minAngle = -20;
    [SerializeField] private float maxAngle = -70;
    [SerializeField] private float rotateSpeed = 1.5f;
    bool aim = true;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (aim)
        {
            float angle = transform.eulerAngles.z - 360;
            var angles = transform.eulerAngles;
            angles.z = Mathf.Clamp(angle,maxAngle , minAngle);
            transform.position = ball.transform.position;
            transform.eulerAngles = angles;
            
            
            rotateSpeed *= ((angle >= minAngle) || (angle <= maxAngle)) ? -1 : 1;
            transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
            
        }

        if (Input.GetKeyDown(KeyCode.Space) && aim)
        {
            aim = false;
            var direction = point.transform.position - transform.position;
            direction = direction.normalized;
            meter.SetActive(true);
            meter.GetComponent<MeterLauncher>().Direction = direction;
        }
    }
}
