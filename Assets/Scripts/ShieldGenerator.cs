using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGenerator : MonoBehaviour
{
    private float baseRotationSpeed = 5f;

    /// <summary>
    /// //Tuples contain xPos, yPos, zRot
    /// </summary>
    private List<Tuple<float, float, float>> ringZeroOffsets = new List<Tuple<float, float, float>>();
    private List<Tuple<float, float, float>> ringOneOffsets = new List<Tuple<float, float, float>>();
    private List<Tuple<float, float, float>> ringTwoOffsets = new List<Tuple<float, float, float>>();

    [SerializeField] private GameObject ring0 = null;
    [SerializeField] private GameObject ring1 = null;
    [SerializeField] private GameObject ring2 = null;

    private void Awake()
    {
        LoadRingOffsets();
    }

    private void Update()
    {
        Vector3 baseRotation = new Vector3(0f, 0f, baseRotationSpeed * Time.deltaTime);
        RotateRings(baseRotation);
    }

    #region Load Shield Generator

    private void LoadRingOffsets()
    {
        LoadRingZeroOffsets();
        LoadRingOneOffsets();
        LoadRingTwoOffsets();
    }

    private void LoadRingZeroOffsets()
    {
        ringZeroOffsets.Add(new Tuple<float, float, float>(0f, 1.2f, 0f));
        ringZeroOffsets.Add(new Tuple<float, float, float>(.85f, .85f, 315f));
        ringZeroOffsets.Add(new Tuple<float, float, float>(1.2f, 0f, 270f));
        ringZeroOffsets.Add(new Tuple<float, float, float>(.85f, -.85f, 225f));
        ringZeroOffsets.Add(new Tuple<float, float, float>(0f, -1.2f, 180f));
        ringZeroOffsets.Add(new Tuple<float, float, float>(-.85f, -.85f, 135f));
        ringZeroOffsets.Add(new Tuple<float, float, float>(-1.2f, 0f, 90f));
        ringZeroOffsets.Add(new Tuple<float, float, float>(-.85f, .85f, 45f));
    }

    private void LoadRingOneOffsets()
    {
        ringOneOffsets.Add(new Tuple<float, float, float>(0f, 1.85f, 0f));
        ringOneOffsets.Add(new Tuple<float, float, float>(1.25f, 1.25f, 315f));
        ringOneOffsets.Add(new Tuple<float, float, float>(1.85f, 0f, 270f));
        ringOneOffsets.Add(new Tuple<float, float, float>(1.25f, -1.25f, 225f));
        ringOneOffsets.Add(new Tuple<float, float, float>(0f, -1.85f, 180f));
        ringOneOffsets.Add(new Tuple<float, float, float>(-1.25f, -1.25f, 135f));
        ringOneOffsets.Add(new Tuple<float, float, float>(-1.85f, 0f, 90f));
        ringOneOffsets.Add(new Tuple<float, float, float>(-1.25f, 1.25f, 45f));
    }

    private void LoadRingTwoOffsets()
    {
        ringTwoOffsets.Add(new Tuple<float, float, float>(0f, 2.4f, 0f));
        ringTwoOffsets.Add(new Tuple<float, float, float>(1.7f, 1.7f, 315f));
        ringTwoOffsets.Add(new Tuple<float, float, float>(2.4f, 0f, 270f));
        ringTwoOffsets.Add(new Tuple<float, float, float>(1.7f, -1.7f, 225f));
        ringTwoOffsets.Add(new Tuple<float, float, float>(0f, -2.4f, 180f));
        ringTwoOffsets.Add(new Tuple<float, float, float>(-1.7f, -1.7f, 135f));
        ringTwoOffsets.Add(new Tuple<float, float, float>(-2.4f, 0f, 90f));
        ringTwoOffsets.Add(new Tuple<float, float, float>(-1.7f, 1.7f, 45f));
    }

    public void LoadShieldBars(ShieldBar prefabShieldBar, ShieldGem prefabShieldGem)
    {
        for(int ring = 0; ring < 3; ring++)
        {
            for(int bar = 0; bar < 8; bar++)
            {
                ShieldBar thisBar;
                switch(ring)
                {
                    case 0:
                        thisBar = Instantiate(prefabShieldBar, ring0.transform);
                        thisBar.transform.parent = ring0.transform;
                        Tuple<float, float, float> ringZeroOffset = ringZeroOffsets[bar];
                        thisBar.transform.Translate(new Vector3(ringZeroOffset.Item1, ringZeroOffset.Item2, 0f));
                        thisBar.transform.Rotate(new Vector3(0f, 0f, ringZeroOffset.Item3));
                        for(int gem = 0; gem < 2; gem ++)
                        {
                            ShieldGem thisGem = Instantiate(prefabShieldGem, thisBar.transform);
                            thisBar.AddGem(thisGem);
                            switch(gem)
                            {                                
                                case 0:
                                    thisGem.transform.Translate(new Vector3(-.25f, 0f, 0f));
                                    break;
                                case 1:
                                    thisGem.transform.Translate(new Vector3(.25f, 0f, 0f));
                                    break;
                            }
                        }
                        break;
                    case 1:
                        thisBar = Instantiate(prefabShieldBar, ring1.transform);
                        thisBar.transform.parent = ring1.transform;
                        Tuple<float, float, float> ringOneOffset = ringOneOffsets[bar];
                        thisBar.transform.Translate(new Vector3(ringOneOffset.Item1, ringOneOffset.Item2, 0f));
                        thisBar.transform.Rotate(new Vector3(0f, 0f, ringOneOffset.Item3));
                        for (int gem = 0; gem < 3; gem++)
                        {
                            ShieldGem thisGem = Instantiate(prefabShieldGem, thisBar.transform);
                            thisBar.AddGem(thisGem);
                            switch (gem)
                            {
                                case 0:
                                    thisGem.transform.Translate(new Vector3(-.5f, 0f, 0f));
                                    break;
                                case 1: //Nothing happens, gem is centered
                                    break;
                                case 2:
                                    thisGem.transform.Translate(new Vector3(.5f, 0f, 0f));
                                    break;
                            }
                        }
                        break;
                    case 2:
                        thisBar = Instantiate(prefabShieldBar, ring2.transform);
                        thisBar.transform.parent = ring2.transform;
                        Tuple<float, float, float> ringTwoOffset = ringTwoOffsets[bar];
                        thisBar.transform.Translate(new Vector3(ringTwoOffset.Item1, ringTwoOffset.Item2, 0f));
                        thisBar.transform.Rotate(new Vector3(0f, 0f, ringTwoOffset.Item3));
                        for (int gem = 0; gem < 4; gem++)
                        {
                            ShieldGem thisGem = Instantiate(prefabShieldGem, thisBar.transform);
                            thisBar.AddGem(thisGem);
                            switch (gem)
                            {
                                case 0:
                                    thisGem.transform.Translate(new Vector3(-.75f, 0f, 0f));
                                    break;
                                case 1:
                                    thisGem.transform.Translate(new Vector3(-.25f, 0f, 0f));
                                    break;
                                case 2:
                                    thisGem.transform.Translate(new Vector3(.25f, 0f, 0f));
                                    break;
                                case 3:
                                    thisGem.transform.Translate(new Vector3(.75f, 0f, 0f));
                                    break;
                            }
                        }
                        break;
                }
            }
        }
    }

    #endregion



    public void RotateRings(Vector3 rotationVector)
    {
        ring0.transform.Rotate(rotationVector / 2f);
        ring1.transform.Rotate(-rotationVector / 3f);
        ring2.transform.Rotate(rotationVector / 4f);
    }
}
