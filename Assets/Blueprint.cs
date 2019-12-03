using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueprint : MonoBehaviour, IBuildable
{
    public BitBank bitBank;
    public Transform structurePrefab;

    void Update()
    {
        if(bitBank.Full())
        {
            GameObject.Instantiate(structurePrefab, transform.position, transform.rotation);
            GameObject.Destroy(gameObject);
        }
    }

    // takes data from builder and builds with it, more extendable later on
    public void Build(Transform builder)
    {
        BitBank botBitBank = builder.GetComponent<BitBank>();
        BitBank.TransferClamped(botBitBank, bitBank, botBitBank.bits, 0, bitBank.maxBits - bitBank.bits);
    }
}
