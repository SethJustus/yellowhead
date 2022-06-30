using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    public string wordsToDisplay;
    public Text textAsset;
    // Start is called before the first frame update
    void Start()
    {
        textAsset= GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textAsset.text = wordsToDisplay;
    }
}
