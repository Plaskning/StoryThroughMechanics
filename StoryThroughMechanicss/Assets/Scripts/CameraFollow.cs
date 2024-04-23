using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offset = new Vector3(5, 0, -10);
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = target.transform.position + offset;
    }
}
