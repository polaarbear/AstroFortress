using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabLoader", menuName = "Loaders/Prefab Loader", order = 0)]
public class LoaderValues : ScriptableObject
{
    private List<float> OffsetsX_ThreeGemShield = new List<float>();


    #region InitialLoad

    public void LoadDefaultValues()
    {
        LoadThreeGemOffsets();
    }

    private void LoadThreeGemOffsets()
    {
        OffsetsX_ThreeGemShield.Add(-.5f);
        OffsetsX_ThreeGemShield.Add(0f);
        OffsetsX_ThreeGemShield.Add(.5f);
    }

    #endregion
}
