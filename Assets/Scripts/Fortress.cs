using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fortress : MonoBehaviour
{
    [SerializeField] private GameObject shieldGenerator = null;
    private float rotationSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotationVector = new Vector3(0f, 0f, rotationSpeed * Time.deltaTime);
        CounterRotateShield(rotationVector);
    }

    private void CounterRotateShield(Vector3 fortressRotation)
    {
        shieldGenerator.transform.Rotate(-2 * fortressRotation);
    }
}
