using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class transverseDiscrepancy : MonoBehaviour
{

	public TMP_InputField  MxCIR,MxCIL,MndCIR,MndCIL,MxLIR,MxLIL,MndLIR,MndLIL,MxMPV_ponts,MndMPV_ponts,MxMMV_ponts,MndMMV_ponts,MxMPV_schwarz,MndMPV_schwarz,MxMMV_schwarz,MndMMV_schwarz;

    

    private float ftpr(TMP_InputField in_field)
	{
		return float.Parse(in_field.text);
	}

    private float PontMxCPV,PontMxCMV,PontMndCPV,PontMndCMV;
    public TMP_Text premolarValMax,premolarValMan,molaValMax,molarValMan,totDisPreMax,totDispreMan,totDisMoMax,totDisMoMan;
    public TMP_Text infPreMax,infPreMan,infMoMax,infMoMan;
    public void calculatePonts()
    {
        PontMxCPV = (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxLIL) + ftpr(MxLIR)) * 100 / 80;
		PontMxCMV = (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxLIL) + ftpr(MxLIR)) * 100 / 64;

		PontMndCPV = (ftpr(MndCIL) + ftpr(MndCIR) + ftpr(MndLIL) + ftpr(MndLIR)) * 100 / 80;
		PontMndCMV = (ftpr(MndCIL) + ftpr(MndCIR) + ftpr(MndLIL) + ftpr(MndLIR)) * 100 / 64;

        premolarValMax.text = PontMxCPV.ToString();
        premolarValMan.text =  PontMndCPV.ToString();
        molaValMax.text = PontMxCMV.ToString();
        molarValMan.text = PontMndCMV.ToString();
        totDisPreMax.text = (ftpr(MxMPV_ponts) - PontMxCPV).ToString();
        totDispreMan.text = (ftpr(MndMPV_ponts) - PontMndCPV).ToString();
        totDisMoMax.text = (ftpr(MxMMV_ponts) - PontMxCMV).ToString();
        totDisMoMan.text = (ftpr(MndMMV_ponts) - PontMndCMV).ToString();

        if(ftpr(MxMPV_ponts) < PontMxCPV) 
        {
            infPreMax.text = "measured premolar value is less than calculated value, therefore its a narrow arch and needs expansion.";
        }
        else{
            infPreMax.text = "measured premolar value is more than calculated value, therefore its a wide arch and doesn't need expansion.";
        }

		if(ftpr(MxMMV_ponts) < PontMxCMV){
            infMoMax.text = "measured molar value is less than calculated value, therefore its a narrow arch and needs expansion.";
        }
        else{
            infMoMax.text = "measured molar value is more than calculated value, therefore its a wide arch and doesn't need expansion.";
        }

        if(ftpr(MndMPV_ponts) < PontMndCPV){
            infPreMan.text = "measured premolar value is less than calculated value, therefore its a narrow arch and needs expansion.";
        }
        else{
            infPreMan.text = "measured premolar value is more than calculated value, therefore its a wide arch and doesn't need expansion.";
        }

		if(ftpr(MndMMV_ponts) < PontMndCMV){
            infMoMan.text = "measured molar value is less than calculated value, therefore its a narrow arch and needs expansion.";
        } 
        else{
            infMoMan.text = "measured molar value is more than calculated value, therefore its a wide arch and doesn't need expansion.";
        }

    }

    public TMP_InputField mfpe,facetype,slie,slip;
    float v1,v2,SchwMxCPV,SchwMxCMV,SchwMndCPV,SchwMndCMV;

    public TMP_Text preMax,preMan,moMax,moMan,totPreMax,totPreMan,totMoMax,totMoMan;

    public void calculateSchwarz()
    {
        float MxMPV_local,MndMPV_local;
        if (mfpe.text == 2.ToString())
		{
            MxMPV_local = float.Parse(MxMPV_schwarz.text)+2;
            MndMPV_local = float.Parse(MndMPV_schwarz.text)+2;

        }
        else
        {
            MxMPV_local = ftpr(MxMPV_schwarz);
            MndMPV_local = ftpr(MndMPV_schwarz);
        }

        if (facetype.text == 1.ToString())
		{
			v1 = 8; v2 = 16;
		}
		else if (facetype.text == 2.ToString())
		{
			v1 = 7; v2 = 14;
		}
		else if (facetype.text == 3.ToString())
		{
			v1 = 6; v2 = 12;
		}

        if (slie.text == "2")
		{
			SchwMxCPV = (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxCIL) + ftpr(MxCIR) - 4) + v1;
			SchwMxCMV = (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxCIL) + ftpr(MxCIR) - 4) + v2;

			SchwMndCPV = (ftpr(MndCIL) + ftpr(MndCIR) + ftpr(MndCIL) + ftpr(MndCIR) - 4) + v1;
			SchwMndCMV = (ftpr(MndCIL) + ftpr(MndCIR) + ftpr(MndCIL) + ftpr(MndCIR) - 4) + v2;

            
		}
		else
		{

			if (slip.text == "1")
			{
				SchwMxCPV = (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxCIL) + ftpr(MxCIR) - 4) + v1;
				SchwMxCMV = (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxCIL) + ftpr(MxCIR) - 4) + v2;

				SchwMndCPV = (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxCIL) + ftpr(MxCIR) - 4) + v1;
				SchwMndCMV = (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxCIL) + ftpr(MxCIR) - 4) + v2;
			}
			else
			{
				SchwMxCPV = (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxLIL) + ftpr(MxLIR)) + v1;
				SchwMxCMV = (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxLIL) + ftpr(MxLIR)) + v2;

				SchwMndCPV = (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxLIL) + ftpr(MxLIR)) + v1;
				SchwMndCMV = (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxLIL) + ftpr(MxLIR)) + v2;
			}
		}

        preMan.text = SchwMndCPV.ToString();
        preMax.text = SchwMxCPV.ToString();
        moMax.text = SchwMxCMV.ToString();
        moMan.text= SchwMndCMV.ToString();
        totPreMan.text = (MndMPV_local - SchwMndCPV).ToString();
        totPreMax.text = (MxMPV_local - SchwMxCPV).ToString();
        totMoMax.text = (ftpr(MxMMV_schwarz) - SchwMxCMV).ToString();
        totMoMan.text = (ftpr(MndMMV_schwarz) - SchwMndCMV).ToString();

    }


}
