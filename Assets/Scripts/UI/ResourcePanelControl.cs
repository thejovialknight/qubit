using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcePanelControl : MonoBehaviour
{
    public Text bitsText;
    public Text energyText;
    public RectTransform panel;

    public float panelScaleSpeed = 10f;
    float panelOffset = 340;

    // Update is called once per frame
    void Update()
    {
        int bitsLength = bitsText.text.Length;
        int energyLength = energyText.text.Length;
        int higherNumber = Mathf.Max(bitsLength, energyLength);

        float desiredPanelOffset = (340 - (7 * higherNumber));
        if (panelOffset != desiredPanelOffset)
        {
            panelOffset = Mathf.Lerp(panelOffset, desiredPanelOffset, panelScaleSpeed * Time.deltaTime);
        }

        panel.offsetMin = new Vector2(panelOffset, panel.offsetMin.y);
    }
}
