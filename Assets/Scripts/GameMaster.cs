using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    [SerializeField] private Camera fortressCam = null;
    private float cameraWidth;
    private float cameraHeight;

    [SerializeField] private PlayerShip playerShip = null;
    [SerializeField] private Fortress fortress = null;

    private void Awake()
    {
        float screenHeight = Screen.height;
        fortressCam.orthographicSize = Screen.height / 120;
        cameraHeight = fortressCam.orthographicSize * 2f;
        cameraWidth = cameraHeight * fortressCam.aspect;
        fortressCam.transform.position = new Vector3(cameraWidth / 2f, cameraHeight / 2f, fortressCam.transform.position.z);
        fortress.transform.position = new Vector3(cameraWidth / 2f, cameraHeight / 2f, 0f);
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
