using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBar : MonoBehaviour
{
    private List<ShieldGem> activeGems;

    private void Awake()
    {
        activeGems = new List<ShieldGem>();
    }

    public void AddGem(ShieldGem newGem)
    {
        activeGems.Add(newGem);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
