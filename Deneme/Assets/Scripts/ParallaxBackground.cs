using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]  Vector2 parallaxEffectMultiplier;
    public Camera camera;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUniteSizeX;
    private float textureUnitSizeY ;

    private void Start() 
    {
        cameraTransform = camera.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUniteSizeX = texture.width / sprite.pixelsPerUnit * transform.localScale.x;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit * transform.localScale.y;
    }

    private void Update()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x,deltaMovement.y*parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;

        if(Mathf.Abs(cameraTransform.transform.position.x - transform.position.x) >= textureUniteSizeX)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUniteSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
        }
        if(Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY)
        {
            float offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUniteSizeX;
            transform.position = new Vector3(transform.position.x, cameraTransform.position.y + offsetPositionY);
        }
    }
}
