using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWhile : MonoBehaviour
{

    [SerializeField] private GameObject _test;
    [SerializeField] private Transform _testSpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        do
        {
            Instantiate(_test, _testSpawnPosition.position, _testSpawnPosition.rotation);
            
            Debug.Log("BAH");
        }
        while (true);
    }
}
