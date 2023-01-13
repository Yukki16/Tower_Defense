using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScripts : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] paths;
    void Start()
    {
        Grid.GenerateGrid(new Vector2(), new Vector2(9,5), new Vector2(10, 10), 10, paths);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
