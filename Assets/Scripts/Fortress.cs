using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fortress : MonoBehaviour
{
    
    private float rotationSpeed = 15f;
    [SerializeField] ShieldGenerator shieldGenerator = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotationVector = new Vector3(0f, 0f, rotationSpeed * Time.deltaTime);
        transform.Rotate(rotationVector);
    }
}
