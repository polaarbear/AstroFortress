﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    [SerializeField] private SpriteRenderer flameRenderer = null;

    public void Toggle(bool isActive)
    {
        if (isActive)
            flameRenderer.enabled = true;
        else
            flameRenderer.enabled = false;
    }
}
