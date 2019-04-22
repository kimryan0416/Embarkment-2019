using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public bool variableBool;
    public string name;
    public int number;
    MeshRenderer meshR;
    // Normally, variables declared within individual class files cannot be accessed by other classes or programs (i.e. Unity)
    // However, if we put "public" in front of a variable declaration, it then becomes accessible and editable by other
    // classes and engine (i.e. Unity)

    // Start is called before the first frame update
    void Start()
    {
        meshR = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            meshR.enabled = !meshR.enabled;
        }
    }

    public void printBuckets()
    {
        Debug.Log(variableBool);
        Debug.Log(name);
        Debug.Log(number);
    }
}
