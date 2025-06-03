using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private float launchForce;
    [SerializeField] private Transform point;
    bool activated = false;
    
    

    void OnTriggerEnter2D(Collider2D other)
    { 
        if(activated) return;
        GetComponent<AudioSource>().Play();
        var direction = point.position - transform.position;
        direction.Normalize();
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * launchForce);
        activated = true;
    }
}
