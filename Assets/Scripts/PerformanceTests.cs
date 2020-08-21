using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class PerformanceTests : MonoBehaviour
{
    [DllImport("LowLevelPlugin")]
    private static extern int fillArray(int a, int b);

    int a = 1;
    int b = 2;
    int c = 0;
    void Start()
    {
        c = fillArray(a,b);
        Debug.Log(c);
    }

}
