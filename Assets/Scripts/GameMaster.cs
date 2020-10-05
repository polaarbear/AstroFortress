using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    /// <summary>
    /// ASSET LOADERS
    /// </summary>

    [SerializeField] private LoaderPrefabs prefabLoader = null;

    /// <summary>
    /// CAMERA
    /// </summary>
    [SerializeField] private Camera gameCam = null;
    private float cameraWidth;
    private float cameraHeight = 18f;

    private GameControls gameControls;
    private bool primaryFireHeld = false;
    private bool fireReady = true;
    private float fireRate = .1f;
    private float timeSinceFire = 0f;

    private int playerLevel = 3;
    private PlayerShip playerShip = null;
    private Fortress fortress = null;
    private ShieldGenerator shieldGenerator = null;

    private void Awake()
    {
        AlignCamera();
        LoadGameObjects();
        InitializeControls();
    }

    private void AlignCamera()
    {
        cameraWidth = cameraHeight * gameCam.aspect;
        Vector3 centerScreen = new Vector3(cameraWidth / 2f, cameraHeight / 2f, gameCam.transform.position.z);
        gameCam.transform.position = centerScreen;
    }

    private void InitializeControls()
    {
        gameControls = new GameControls();
        gameControls.InGameControls.ToggleThruster.performed += toggleThruster => playerShip.ToggleThrusters();
        gameControls.InGameControls.FirePrimary.performed += firePrimary => primaryFireHeld = !primaryFireHeld;
    }

    private void OnEnable()
    {
        gameControls.InGameControls.Enable();
    }

    private void OnDisable()
    {
        gameControls.InGameControls.Disable();
    }

    private void LoadGameObjects()
    {
        LoadPlayer();
        LoadEnemy();
    }

    private void LoadPlayer()
    {
        playerShip = Instantiate(prefabLoader.GetPlayerShipPrefab(), transform);
        List<LaserCannon> laserCannons = new List<LaserCannon>();
        for(int lvl = 0; lvl < playerLevel; lvl++)
        {
            LaserCannon newCannon = Instantiate(prefabLoader.GetLaserCannonPrefab(), playerShip.transform);
            newCannon.name = "LaserCannon" + (lvl + 1).ToString();
            laserCannons.Add(newCannon);
        }
        playerShip.AttachCannons(laserCannons);
    }

    private void LoadEnemy()
    {
        fortress = Instantiate(prefabLoader.GetFortressPrefab(), transform);
        shieldGenerator = Instantiate(prefabLoader.GetShieldGeneratorPrefab(), transform);
        shieldGenerator.StartShield(prefabLoader.GetShieldBarPrefab(), prefabLoader.GetShieldGemPrefab());
        fortress.transform.position = shieldGenerator.transform.position = 
            new Vector3(
                gameCam.transform.position.x,
                gameCam.transform.position.y, 0f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
        PerformBoundsCheck();
        playerShip.CheckRotation(deltaTime, gameControls.InGameControls.RotateShip.ReadValue<float>());
        UpdatePlayerWeapons(deltaTime);
    }

    private void UpdatePlayerWeapons(float deltaTime)
    {
        if(!fireReady)
        {
            timeSinceFire += deltaTime;
            if(timeSinceFire >= fireRate)
            {
                fireReady = true;
                timeSinceFire = 0f;
            }
        }
        else if (primaryFireHeld && fireReady)
        {
            playerShip.FireLasers(InstantiateFiredLasers());
            fireReady = false;
        }
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

    private List<Laser> InstantiateFiredLasers()
    {
        List<Laser> firedLasers = new List<Laser>();
        for(int laser = 0; laser < playerLevel; laser++)
        {
            firedLasers.Add(Instantiate(prefabLoader.GetLaserPrefab(), transform));
        }
        return firedLasers;
    }
}
