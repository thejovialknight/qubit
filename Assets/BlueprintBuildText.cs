using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueprintBuildText : MonoBehaviour
{
    public BitBank bitBank;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = bitBank.bits + "/" + bitBank.maxBits;
    }
}
