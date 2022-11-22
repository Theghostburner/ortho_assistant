using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class korkhaus_analysis : MonoBehaviour
{

	public TMP_InputField KPIMxMMV, KPIPH;
    float PHI;

    public TMP_Text inference,index;

    private float ftpr(TMP_InputField in_field)
	{
		return float.Parse(in_field.text);
	}


	public void calculateKorkhaus()
    {
        PHI = ftpr(KPIPH) * 100 / ftpr(KPIMxMMV);
        index.text = PHI.ToString();
        if (PHI > 42) 
        {
            inference.text = "High Palate";
        }
        else
        {
            inference.text = "Shallow Palate";
        }

    }

	

}
