using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class permanentDentition : MonoBehaviour
{
    private float ftpr(TMP_InputField in_field)
	{
		return float.Parse(in_field.text);
	}
   public TMP_InputField Mxd,Mndd,MxCIR,MxCIL,MndCIR,MndCIL,MxLIR,MxLIL,MndLIR,MndLIL,MxCaR,MxCaL,MndCaR,MndCaL,MxPMR1,MxPML1,MndPMR1,MndPML1,MxPMR2,MxPML2,MndPMR2,MndPML2;
    float perm_arch_leng_discrepancy_Mnd,perm_arch_leng_discrepancy_Mx;

    public TMP_Text toothSpaceMan,toothSpaceMax;
    public void calculateToothSpaceArch()
    {
        perm_arch_leng_discrepancy_Mx = ftpr(Mxd) - (ftpr(MxCIR) + ftpr(MxCIL) + ftpr(MxLIL) + ftpr(MxLIR) + ftpr(MxCaL) + ftpr(MxCaR) + ftpr(MxPML1) + ftpr(MxPMR1) + ftpr(MxPML2) + ftpr(MxPMR2));
        perm_arch_leng_discrepancy_Mnd = ftpr(Mndd) - (ftpr(MndCIR) + ftpr(MndCIL) + ftpr(MndLIL) + ftpr(MndLIR) + ftpr(MndCaL) + ftpr(MndCaR) + ftpr(MndPML1) + ftpr(MndPMR1) + ftpr(MndPML2) + ftpr(MndPMR2));
        toothSpaceMan.text = (Mathf.Round(perm_arch_leng_discrepancy_Mnd * 100) / 100).ToString();
        toothSpaceMax.text = (Mathf.Round(perm_arch_leng_discrepancy_Mx * 100) / 100).ToString();
    }

    public TMP_InputField BolMndFMR,BolMndFML,BolMxFMR,BolMxFML;
    float BolOvrRat,BolAntRat;
    public TMP_Text ovrRat,antRat,ovrRatInf,antRatInf;
    public void calculateBoltonPerm()
    {
        BolOvrRat = (ftpr(MndCIL) + ftpr(MndCIR) + ftpr(MndLIL) + ftpr(MndLIR) + ftpr(MndCaL) + ftpr(MndCaR) + ftpr(MndPML1) + ftpr(MndPMR1) + ftpr(MndPML2) + ftpr(MndPMR2) + ftpr(BolMndFMR) + ftpr(BolMndFML)) * 100 / (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxLIL) + ftpr(MxLIR) + ftpr(MxCaL) + ftpr(MxCaR) + ftpr(MxPML1) + ftpr(MxPMR1) + ftpr(MxPML2) + ftpr(MxPMR2) + ftpr(BolMxFMR) + ftpr(BolMxFML));
        BolAntRat = (ftpr(MndCIL) + ftpr(MndCIR) + ftpr(MndLIL) + ftpr(MndLIR) + ftpr(MndCaL) + ftpr(MndCaR)) * 100 / (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxLIL) + ftpr(MxLIR) + ftpr(MxCaL) + ftpr(MxCaR));
        ovrRat.text = BolOvrRat.ToString();
        antRat.text = BolAntRat.ToString();
        if (BolOvrRat < 91.3){
            ovrRatInf.text = "The amount of maxillary tooth excess(Overall Ratio) is "+ (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxLIL) + ftpr(MxLIR) + ftpr(MxCaL) + ftpr(MxCaR) + ftpr(MxPML1) + ftpr(MxPMR1) + ftpr(MxPML2) + ftpr(MxPMR2) + ftpr(BolMxFMR) + ftpr(BolMxFML) - (ftpr(MndCIL) + ftpr(MndCIR) + ftpr(MndLIL) + ftpr(MndLIR) + ftpr(MndCaL) + ftpr(MndCaR) + ftpr(MndPML1) + ftpr(MndPMR1) + ftpr(MndPML2) + ftpr(MndPMR2) + ftpr(BolMndFMR) + ftpr(BolMndFML)) * 100 / 91.3f);
        } 
        else 
        {
            ovrRatInf.text = "The amount of mandibular tooth excess(Overall Ratio) is "+(ftpr(MndCIL) + ftpr(MndCIR) + ftpr(MndLIL) + ftpr(MndLIR) + ftpr(MndCaL) + ftpr(MndCaR) + ftpr(MndPML1) + ftpr(MndPMR1) + ftpr(MndPML2) + ftpr(MndPMR2) + ftpr(BolMndFMR) + ftpr(BolMndFML) - (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxLIL) + ftpr(MxLIR) + ftpr(MxCaL) + ftpr(MxCaR) + ftpr(MxPML1) + ftpr(MxPMR1) + ftpr(MxPML2) + ftpr(MxPMR2) + ftpr(BolMxFMR) + ftpr(BolMxFML))*91.3f/ 100);
        }


        if (BolAntRat < 77.2){
            antRatInf.text = "The amount of maxillary tooth excess(Anterior Ratio) is "+ (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxLIL) + ftpr(MxLIR) + ftpr(MxCaL) + ftpr(MxCaR) - (ftpr(MndCIL) + ftpr(MndCIR) + ftpr(MndLIL) + ftpr(MndLIR) + ftpr(MndCaL) + ftpr(MndCaR)) * 100 / 77.2f);
        }    
        else{
            antRatInf.text = "The amount of mandibular tooth excess(Anterior Ratio) is "+ (ftpr(MndCIL) + ftpr(MndCIR) + ftpr(MndLIL) + ftpr(MndLIR) + ftpr(MndCaL) + ftpr(MndCaR) - (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxLIL) + ftpr(MxLIR) + ftpr(MxCaL) + ftpr(MxCaR))*77.2f / 100);
        } 
    }


    
	public TMP_InputField  MxMPV,MndMPV,MxMMV,MndMMV;

    

    private float PontMxCPV,PontMxCMV,PontMndCPV,PontMndCMV;
    public TMP_Text premolarValMax,premolarValMan,molaValMax,molarValMan,totDisPreMax,totDispreMan,totDisMoMax,totDisMoMan;
    public TMP_Text infPreMax,infPreMan,infMoMax,infMoMan;
    public void calculatePontsPerm()
    {
        PontMxCPV = (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxLIL) + ftpr(MxLIR)) * 100 / 80;
		PontMxCMV = (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxLIL) + ftpr(MxLIR)) * 100 / 64;

		PontMndCPV = (ftpr(MndCIL) + ftpr(MndCIR) + ftpr(MndLIL) + ftpr(MndLIR)) * 100 / 80;
		PontMndCMV = (ftpr(MndCIL) + ftpr(MndCIR) + ftpr(MndLIL) + ftpr(MndLIR)) * 100 / 64;

        premolarValMax.text = PontMxCPV.ToString();
        premolarValMan.text =  PontMndCPV.ToString();
        molaValMax.text = PontMxCMV.ToString();
        molarValMan.text = PontMndCMV.ToString();
        totDisPreMax.text = (PontMxCPV - ftpr(MxMPV)).ToString();
        totDispreMan.text = (PontMndCPV - ftpr(MndMPV)).ToString();
        totDisMoMax.text = (PontMxCMV - ftpr(MxMMV)).ToString();
        totDisMoMan.text = (PontMndCMV - ftpr(MndMMV)).ToString();

        if(ftpr(MxMPV) < PontMxCPV) 
        {
            infPreMax.text = "measured premolar value is less than calculated value, therefore its a narrow arch and needs expansion.";
        }
        else{
            infPreMax.text = "measured premolar value is more than calculated value, therefore its a wide arch and doesn't need expansion.";
        }

		if(ftpr(MxMMV) < PontMxCMV){
            infMoMax.text = "measured molar value is less than calculated value, therefore its a narrow arch and needs expansion.";
        }
        else{
            infMoMax.text = "measured molar value is more than calculated value, therefore its a wide arch and doesn't need expansion.";
        }

        if(ftpr(MndMPV) < PontMndCPV){
            infPreMan.text = "measured premolar value is less than calculated value, therefore its a narrow arch and needs expansion.";
        }
        else{
            infPreMan.text = "measured premolar value is more than calculated value, therefore its a wide arch and doesn't need expansion.";
        }

		if(ftpr(MndMMV) < PontMndCMV){
            infMoMan.text = "measured molar value is less than calculated value, therefore its a narrow arch and needs expansion.";
        } 
        else{
            infMoMan.text = "measured molar value is more than calculated value, therefore its a wide arch and doesn't need expansion.";
        }

    }

    public TMP_InputField facetype,slip;
    float v1,v2,SchwMxCPV,SchwMxCMV,SchwMndCPV,SchwMndCMV;

    public TMP_Text preMax,preMan,moMax,moMan,totPreMax,totPreMan,totMoMax,totMoMan;

    public void calculateSchwarzPerm()
    {
        float MxMPV_local = ftpr(MxMPV),MndMPV_local = ftpr(MndMPV);

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

      

        if (slip.text == "1")
        {
            SchwMxCPV = (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxCIL) + ftpr(MxCIR) - 4) + v1;
            SchwMxCMV = (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxCIL) + ftpr(MxCIR) - 4) + v2;

            SchwMndCPV = (ftpr(MndCIL) + ftpr(MndCIR) + ftpr(MndCIL) + ftpr(MndCIR) - 4) + v1;
            SchwMndCMV = (ftpr(MndCIL) + ftpr(MndCIR) + ftpr(MndCIL) + ftpr(MndCIR) - 4) + v2;
        }
        else
        {
            SchwMxCPV = (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxLIL) + ftpr(MxLIR)) + v1;
            SchwMxCMV = (ftpr(MxCIL) + ftpr(MxCIR) + ftpr(MxLIL) + ftpr(MxLIR)) + v2;

            SchwMndCPV = (ftpr(MndCIL) + ftpr(MndCIR) + ftpr(MndLIL) + ftpr(MndLIR)) + v1;
            SchwMndCMV = (ftpr(MndCIL) + ftpr(MndCIR) + ftpr(MndLIL) + ftpr(MndLIR)) + v2;
        }
		

        preMan.text = SchwMndCPV.ToString();
        preMax.text = SchwMxCPV.ToString();
        moMax.text = SchwMxCMV.ToString();
        moMan.text= SchwMndCMV.ToString();
        totPreMan.text = (SchwMndCPV - MndMPV_local).ToString();
        totPreMax.text = (SchwMxCPV - MxMPV_local).ToString();
        totMoMax.text = (SchwMxCMV - ftpr(MxMMV)).ToString();
        totMoMan.text = (SchwMndCMV - ftpr(MndMMV)).ToString();

    }


}
