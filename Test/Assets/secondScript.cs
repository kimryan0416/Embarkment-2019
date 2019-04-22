using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondScript : MonoBehaviour
{

    Test firstScript;

    // Start is called before the first frame update
    void Start()
    {
        firstScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Test>();
    }

    // Update is called once per frame
    void Update()
    {
        if(firstScript.variableBool)
        {
            firstScript.printBuckets();
        }
    }
}
