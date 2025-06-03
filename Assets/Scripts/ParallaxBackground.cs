using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] float parallaxAmount = .5f;
    private Transform cameraTransform;
    private Vector3 lastPosition;
    private float textureUnitSizeX;
    
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastPosition = cameraTransform.position;
        var sprite = GetComponent<SpriteRenderer>().sprite;
        var texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        
    }

    
    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastPosition;
        
        transform.position += deltaMovement * parallaxAmount;
        lastPosition = cameraTransform.position;

        if (cameraTransform.position.x - transform.position.x >= textureUnitSizeX)
        {
            float offsetX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetX, transform.position.y);
        }
    }
}
