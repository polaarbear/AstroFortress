using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private SpriteRenderer laserRenderer = null;
    [SerializeField] private List<Sprite> laserSprites = null;
    private int activeSpriteIndex = 0;
    private bool spritesCountingUp = true;
    private float spriteChangeInterval = 0.05f;
    private float spriteChangeCounter = 0f;
    private float velocity = 25f;

    private void Awake()
    {
        name = "Laser";
        laserRenderer.sprite = laserSprites[0];
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;
        transform.Translate(GetFacingVector() * velocity * deltaTime);
    }

    private Vector2 GetFacingVector()
    {
        float thrustY = Mathf.Tan(transform.rotation.z * Mathf.Deg2Rad);
        float thrustX = 1f;
        return new Vector2(thrustX, thrustY).normalized;
    }

    private void UpdateSprite(float deltaTime)
    {
        spriteChangeCounter += deltaTime;
        if(spriteChangeCounter >= spriteChangeInterval)
        {
            if(spritesCountingUp)
            {
                activeSpriteIndex++;
                if (activeSpriteIndex == laserSprites.Count - 1)
                {
                    spritesCountingUp = false;
                }
            }
            else
            {
                activeSpriteIndex--;                
                if(activeSpriteIndex == 0)
                {
                    spritesCountingUp = true;
                }
            }
            laserRenderer.sprite = laserSprites[activeSpriteIndex];
            spriteChangeCounter = 0f;
        }
    }
}
