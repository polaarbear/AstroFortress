using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabLoader", menuName = "Loaders/Prefab Loader", order = 0)]
public class LoaderPrefabs : ScriptableObject
{
    [SerializeField] private PlayerShip PrefabPlayerShip = null;
    [SerializeField] private LaserCannon PrefabLaserCannon = null;

    [SerializeField] private ShieldGenerator PrefabShieldGenerator = null;
    [SerializeField] private ShieldBar PrefabShieldBar = null;
    [SerializeField] private ShieldGem PrefabShieldGem = null;

    [SerializeField] private Fortress PrefabFortress = null;

    public PlayerShip GetPlayerShipPrefab()
    {
        return PrefabPlayerShip;
    }

    public LaserCannon GetLaserCannonPrefab()
    {
        return PrefabLaserCannon;
    }

    public ShieldGenerator GetShieldGeneratorPrefab()
    {
        return PrefabShieldGenerator;
    }

    public ShieldBar GetShieldBarPrefab()
    {
        return PrefabShieldBar;
    }

    public ShieldGem GetShieldGemPrefab()
    {
        return PrefabShieldGem;
    }

    public Fortress GetFortressPrefab()
    {
        return PrefabFortress;
    }
}
