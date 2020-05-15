using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private Camera fortressCam = null;
    private float cameraHeight;
    private float cameraWidth;

    [SerializeField] private PlayerShip playerShip = null;

    private void Awake()
    {
        cameraHeight = fortressCam.orthographicSize * 2;
        cameraWidth = cameraHeight * fortressCam.aspect;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PerformBoundsCheck();
    }

    private void PerformBoundsCheck()
    {
        Vector3 playerPosition = playerShip.transform.position;
        if (playerPosition.x < 0)
        {
            playerPosition.x = cameraWidth;
        }
        else if (playerPosition.x > cameraWidth)
        {
            playerPosition.x = 0;
        }

        if (playerPosition.y < 0)
        {
            playerPosition.y = cameraHeight;
        }
        else if (playerPosition.y > cameraHeight)
        {
            playerPosition.y = 0;
        }
        playerShip.transform.position = playerPosition;
    }
}
