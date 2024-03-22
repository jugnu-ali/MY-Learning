using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class AttributesManager : MonoBehaviour
{
    public TextMeshProUGUI attributesText;

    int attributes = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MagicClicked()
    {

    }

    public void CharismaClicked()
    {

    }

    // Update is called once per frame
    void Update()
    {
        attributesText.text = Convert.ToString(attributes, 2);
    }
}
