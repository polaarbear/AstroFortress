using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private LoaderPrefabs prefabLoader = null;
    [SerializeField] private Camera fortressCam = null;
    private float cameraWidth;
    private float cameraHeight = 18f;

    private PlayerShip playerShip = null;
    private Fortress fortress = null;
    private ShieldGenerator shieldGenerator = null;

    private void Awake()
    {
        AlignCamera();
        LoadGameObjects();
    }

    private void AlignCamera()
    {
        cameraWidth = cameraHeight * fortressCam.aspect;
        Vector3 centerScreen = new Vector3(cameraWidth / 2f, cameraHeight / 2f, fortressCam.transform.position.z);
        fortressCam.transform.position = centerScreen;
    }

    private void LoadGameObjects()
    {
        playerShip = Instantiate(prefabLoader.GetPlayerShipPrefab(), transform);
        LoadEnemyShields();
    }

    private void LoadEnemyShields()
    {
        shieldGenerator = Instantiate(prefabLoader.GetShieldGeneratorPrefab(), transform);
        shieldGenerator.LoadShieldBars(prefabLoader.GetShieldBarPrefab(), prefabLoader.GetShieldGemPrefab());
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
