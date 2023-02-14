using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class inputFieldValueUnifier_script : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_InputField[] AllInputFields;
    void Start()
    {
        AllInputFields = GetComponentsInChildren<TMP_InputField>(true);
        foreach(var i in AllInputFields)
        {
            i.text = "";
            TMP_Text placeholder_text = i.placeholder.gameObject.GetComponent<TMP_Text>();
            placeholder_text.alignment  = TextAlignmentOptions.Center;
            placeholder_text.text = "Enter Value";
            i.contentType = TMP_InputField.ContentType.DecimalNumber;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
