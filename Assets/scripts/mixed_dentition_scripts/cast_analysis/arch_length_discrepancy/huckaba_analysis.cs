using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class huckaba_analysis : MonoBehaviour
{
    //common variables needed for most of the arch length ones
    public TMP_InputField Mxd , Mndd , CBR , CBL , MxCIR , MxCIL , MndCIR , MndCIL , MxLIR , MxLIL , MndLIR , MndLIL ;

	//huckaba's specific variables
    public TMP_InputField MxSMR,MxSML,MndSMR,MndSML,MxCaR,MxCaL,MndCaR,MndCaL,MxPMR1,MxPML1,MndPMR1,MndPML1,MxPMR2,MxPML2,MndPMR2,MndPML2,MxX2R,MxX2L,MndX2R,MndX2L;

	private float ftpr(TMP_InputField in_field)
	{
		return float.Parse(in_field.text);
	}

	//huckaba's calculation variables
	private float Mndb,Mxb,c,MxX1R,MxX1L,MxXR,MxXL,MxACaR,MxACaL,MxAPMR1,MxAPML1,MxAPMR2,MxAPML2,MndX1R,MndX1L,MndXR,MndXL,MndACaR,MndACaL,MndAPMR1,MndAPML1,MndAPMR2,MndAPML2,MxaH,MxTotal_discrepancy_H,MndaH,MndTotal_discrepancy_H;
	
	//huckaba's result variables
	public TMP_Text maxCanineL,maxCanineR,max1pL,max1pR,max2pL,max2pR,manCanineL,manCanineR,man1pL,man1pR,man2pL,man2pR,maxTOT,manTOT;
	public void calculateHuckaba()
	{
		Mndb = -1 * (ftpr(MndCIR) + ftpr(MndCIL) + ftpr(MndLIR) + ftpr(MndLIL));
		Mxb = -1 * (ftpr(MxCIR) + ftpr(MxCIL) + ftpr(MxLIR) + ftpr(MxLIL));
		c = -1 * (ftpr(CBR) + ftpr(CBL));

		MxX1R = float.Parse(MxSMR.text);
		MxX1L = float.Parse(MxSML.text);

		MxXR = MxX1R / float.Parse(MxX2R.text);
		MxXL = MxX1L / float.Parse(MxX2L.text);

		MxACaR = MxXR * float.Parse(MxCaR.text);
		MxACaL = MxXL * float.Parse(MxCaL.text);
		MxAPMR1 = MxXR * float.Parse(MxPMR1.text);
		MxAPML1 = MxXL * float.Parse(MxPML1.text);
		MxAPMR2 = MxXR * float.Parse(MxPMR2.text);
		MxAPML2 = MxXL * float.Parse(MxPML2.text);

		MndX1R = float.Parse(MndSMR.text);
		MndX1L = float.Parse(MndSML.text);

		MndXR = MndX1R / ftpr(MndX2R);
		MndXL = MndX1L / ftpr(MndX2L);

		MndACaR = MndXR * ftpr(MndCaR);
		MndACaL = MndXL * ftpr(MndCaL);
		MndAPMR1 = MndXR * ftpr(MndPMR1);
		MndAPML1 = MndXL * ftpr(MndPML1);
		MndAPMR2 = MndXR * ftpr(MndPMR2);
		MndAPML2 = MndXL * ftpr(MndPML2);

		MxaH = -1 * (MxACaR + MxACaL + MxAPMR1 + MxAPML1 + MxAPMR2 + MxAPML2);
		MxTotal_discrepancy_H = Mathf.Round((ftpr(Mxd) + MxaH + Mxb) * 100) / 100;

		MndaH = -1 * (MndACaR + MndACaL + MndAPMR1 + MndAPML1 + MndAPMR2 + MndAPML2);
		MndTotal_discrepancy_H = Mathf.Round((ftpr(Mndd) + MndaH + Mndb + c) * 100) / 100;


		//results
		maxCanineL.text = (Mathf.Round(MxACaL * 100) / 100).ToString();
		maxCanineR.text = (Mathf.Round(MxACaR * 100) / 100).ToString();
		max1pL.text = (Mathf.Round(MxAPML1 * 100) / 100).ToString();
		max1pR.text = (Mathf.Round(MxAPMR1 * 100) / 100).ToString();
		max2pL.text = (Mathf.Round(MxAPML2 * 100) / 100).ToString();
		max2pR.text = (Mathf.Round(MxAPMR2 * 100) / 100).ToString();
		manCanineL.text = (Mathf.Round(MndACaL * 100) / 100).ToString();
		manCanineR.text = (Mathf.Round(MndACaR * 100) / 100).ToString();
		man1pL.text = (Mathf.Round(MndAPML1 * 100) / 100).ToString();
		man1pR.text = (Mathf.Round(MndAPMR1 * 100) / 100).ToString();
		man2pL.text = (Mathf.Round(MndAPML2 * 100) / 100).ToString();
		man2pR.text = (Mathf.Round(MndAPMR2 * 100) / 100).ToString();
		maxTOT.text = (Mathf.Round(MxTotal_discrepancy_H * 100) / 100).ToString();
		manTOT.text = (Mathf.Round(MndTotal_discrepancy_H * 100) / 100).ToString();

	}

	private float Sum_of_four_Mnd_Incisors,MxaTJ,MxTotal_discrepancy_TJ,MndaTJ,MndTotal_discrepancy_TJ;
	public TMP_Text manBiCu,maxBiCu,totDisMax,totDisMan;
	public void calculateTanaka()
	{
		Sum_of_four_Mnd_Incisors = ftpr(MndCIR) + ftpr(MndCIL) + ftpr(MndLIR) + ftpr(MndLIL);

		MxaTJ = (((Sum_of_four_Mnd_Incisors) / 2) + 11)*(-2);
		MxTotal_discrepancy_TJ = Mathf.Round((ftpr(Mxd) + MxaTJ + Mxb) * 100) / 100;

		MndaTJ = (((Sum_of_four_Mnd_Incisors) / 2) + 10.5f)*(-2);
		MndTotal_discrepancy_TJ = Mathf.Round((ftpr(Mndd) + MndaTJ + Mndb + c) * 100) / 100;

		//results

		manBiCu.text = ((Sum_of_four_Mnd_Incisors / 2) + 10.5).ToString();
		maxBiCu.text = ((Sum_of_four_Mnd_Incisors / 2) + 11).ToString();
		totDisMan.text = ((Mathf.Round(MxTotal_discrepancy_TJ * 100) / 100)).ToString();
		totDisMax.text = ((Mathf.Round(MndTotal_discrepancy_TJ * 100) / 100)).ToString();

	}
	public TMP_Text lucknowMaleMax,lucknowMaleMan,lucknowFemaleMax,lucknowFemaleMan,patnaMaleMax,patnaMaleMan,patnaFemaleMax,patnaFemaleMan;

	public void calculateRegionalLucknow()
	{
		lucknowMaleMax.text = (14.439 + Sum_of_four_Mnd_Incisors - (2*0.336)).ToString();
		lucknowMaleMan.text = (14.576 + Sum_of_four_Mnd_Incisors - (2*0.315)).ToString();
		lucknowFemaleMan.text = (13.189 + Sum_of_four_Mnd_Incisors - (2*0.344)).ToString();
		lucknowFemaleMax.text = (13.288 + Sum_of_four_Mnd_Incisors - (2*0.368)).ToString();

	}
	public void calculateRegionalPatna()
	{
		patnaMaleMan.text = (10.658 + 0.467*Sum_of_four_Mnd_Incisors).ToString();
		patnaMaleMax.text = (10.805 + 0.474*Sum_of_four_Mnd_Incisors).ToString();
		patnaFemaleMan.text = (12.750 + 0.348*Sum_of_four_Mnd_Incisors).ToString();
		patnaFemaleMax.text = (17.723 + 0.143*Sum_of_four_Mnd_Incisors).ToString();

	}

	float moyer_data(int table_select, float MndCIR, float MndCIL, float MndLIR, float MndLIL, float p)
{
	float[,,] mo_dt = new float[4,9,13];
	table_select -= 1;
	mo_dt[0,0,0] = 21.6f; mo_dt[0,0,1] = 21.8f; mo_dt[0,0,2] = 22.0f; mo_dt[0,0,3] = 22.2f; mo_dt[0,0,4] = 22.4f; mo_dt[0,0,5] = 22.6f; mo_dt[0,0,6] = 22.8f; mo_dt[0,0,7] = 23.0f; mo_dt[0,0,8] = 23.2f; mo_dt[0,0,9] = 23.5f; mo_dt[0,0,10] = 23.7f; mo_dt[0,0,11] = 23.9f; mo_dt[0,0,12] = 24.2f;
	mo_dt[0,1,0] = 20.8f; mo_dt[0,1,1] = 21.0f; mo_dt[0,1,2] = 21.2f; mo_dt[0,1,3] = 21.4f; mo_dt[0,1,4] = 21.6f; mo_dt[0,1,5] = 21.9f; mo_dt[0,1,6] = 22.1f; mo_dt[0,1,7] = 22.3f; mo_dt[0,1,8] = 22.5f; mo_dt[0,1,9] = 22.7f; mo_dt[0,1,10] = 23.0f; mo_dt[0,1,11] = 23.3f; mo_dt[0,1,12] = 23.4f;
	mo_dt[0,2,0] = 20.4f; mo_dt[0,2,1] = 20.6f; mo_dt[0,2,2] = 20.8f; mo_dt[0,2,3] = 21.0f; mo_dt[0,2,4] = 21.2f; mo_dt[0,2,5] = 21.4f; mo_dt[0,2,6] = 21.6f; mo_dt[0,2,7] = 21.9f; mo_dt[0,2,8] = 22.1f; mo_dt[0,2,9] = 22.3f; mo_dt[0,2,10] = 22.5f; mo_dt[0,2,11] = 22.8f; mo_dt[0,2,12] = 23.0f;
	mo_dt[0,3,0] = 20.0f; mo_dt[0,3,1] = 20.2f; mo_dt[0,3,2] = 20.4f; mo_dt[0,3,3] = 20.6f; mo_dt[0,3,4] = 20.9f; mo_dt[0,3,5] = 21.1f; mo_dt[0,3,6] = 21.3f; mo_dt[0,3,7] = 21.5f; mo_dt[0,3,8] = 21.8f; mo_dt[0,3,9] = 22.0f; mo_dt[0,3,10] = 22.2f; mo_dt[0,3,11] = 22.4f; mo_dt[0,3,12] = 22.7f;
	mo_dt[0,4,0] = 19.5f; mo_dt[0,4,1] = 19.7f; mo_dt[0,4,2] = 20.0f; mo_dt[0,4,3] = 20.2f; mo_dt[0,4,4] = 20.4f; mo_dt[0,4,5] = 20.6f; mo_dt[0,4,6] = 20.9f; mo_dt[0,4,7] = 21.1f; mo_dt[0,4,8] = 21.3f; mo_dt[0,4,9] = 21.5f; mo_dt[0,4,10] = 21.7f; mo_dt[0,4,11] = 22.0f; mo_dt[0,4,12] = 22.2f;
	mo_dt[0,5,0] = 19.0f; mo_dt[0,5,1] = 19.3f; mo_dt[0,5,2] = 19.5f; mo_dt[0,5,3] = 19.7f; mo_dt[0,5,4] = 20.0f; mo_dt[0,5,5] = 20.2f; mo_dt[0,5,6] = 20.4f; mo_dt[0,5,7] = 20.7f; mo_dt[0,5,8] = 20.9f; mo_dt[0,5,9] = 21.1f; mo_dt[0,5,10] = 21.3f; mo_dt[0,5,11] = 21.5f; mo_dt[0,5,12] = 21.7f;
	mo_dt[0,6,0] = 18.7f; mo_dt[0,6,1] = 18.9f; mo_dt[0,6,2] = 19.1f; mo_dt[0,6,3] = 19.4f; mo_dt[0,6,4] = 19.6f; mo_dt[0,6,5] = 19.8f; mo_dt[0,6,6] = 20.1f; mo_dt[0,6,7] = 20.3f; mo_dt[0,6,8] = 20.5f; mo_dt[0,6,9] = 20.7f; mo_dt[0,6,10] = 21.0f; mo_dt[0,6,11] = 21.2f; mo_dt[0,6,12] = 21.4f;
	mo_dt[0,7,0] = 18.2f; mo_dt[0,7,1] = 18.5f; mo_dt[0,7,2] = 18.7f; mo_dt[0,7,3] = 18.9f; mo_dt[0,7,4] = 19.2f; mo_dt[0,7,5] = 19.4f; mo_dt[0,7,6] = 19.6f; mo_dt[0,7,7] = 19.9f; mo_dt[0,7,8] = 20.1f; mo_dt[0,7,9] = 20.3f; mo_dt[0,7,10] = 20.5f; mo_dt[0,7,11] = 20.7f; mo_dt[0,7,12] = 20.9f;
	mo_dt[0,8,0] = 17.5f; mo_dt[0,8,1] = 17.7f; mo_dt[0,8,2] = 18.0f; mo_dt[0,8,3] = 18.2f; mo_dt[0,8,4] = 18.5f; mo_dt[0,8,5] = 18.7f; mo_dt[0,8,6] = 18.9f; mo_dt[0,8,7] = 19.2f; mo_dt[0,8,8] = 19.4f; mo_dt[0,8,9] = 19.6f; mo_dt[0,8,10] = 19.8f; mo_dt[0,8,11] = 20.0f; mo_dt[0,8,12] = 20.2f;

	mo_dt[1,0,0] = 20.8f; mo_dt[1,0,1] = 21.0f; mo_dt[1,0,2] = 21.2f; mo_dt[1,0,3] = 21.5f; mo_dt[1,0,4] = 21.7f; mo_dt[1,0,5] = 22.0f; mo_dt[1,0,6] = 22.2f; mo_dt[1,0,7] = 22.5f; mo_dt[1,0,8] = 22.7f; mo_dt[1,0,9] = 23.0f; mo_dt[1,0,10] = 23.3f; mo_dt[1,0,11] = 23.6f; mo_dt[1,0,12] = 23.9f;
	mo_dt[1,1,0] = 20.0f; mo_dt[1,1,1] = 20.3f; mo_dt[1,1,2] = 20.5f; mo_dt[1,1,3] = 20.7f; mo_dt[1,1,4] = 21.0f; mo_dt[1,1,5] = 21.2f; mo_dt[1,1,6] = 21.5f; mo_dt[1,1,7] = 21.8f; mo_dt[1,1,8] = 22.0f; mo_dt[1,1,9] = 22.3f; mo_dt[1,1,10] = 22.6f; mo_dt[1,1,11] = 22.8f; mo_dt[1,1,12] = 23.1f;
	mo_dt[1,2,0] = 19.6f; mo_dt[1,2,1] = 19.8f; mo_dt[1,2,2] = 20.1f; mo_dt[1,2,3] = 20.3f; mo_dt[1,2,4] = 20.6f; mo_dt[1,2,5] = 20.8f; mo_dt[1,2,6] = 21.1f; mo_dt[1,2,7] = 21.3f; mo_dt[1,2,8] = 21.6f; mo_dt[1,2,9] = 21.9f; mo_dt[1,2,10] = 22.1f; mo_dt[1,2,11] = 22.4f; mo_dt[1,2,12] = 22.7f;
	mo_dt[1,3,0] = 19.2f; mo_dt[1,3,1] = 19.5f; mo_dt[1,3,2] = 19.7f; mo_dt[1,3,3] = 20.0f; mo_dt[1,3,4] = 20.2f; mo_dt[1,3,5] = 20.5f; mo_dt[1,3,6] = 20.7f; mo_dt[1,3,7] = 21.0f; mo_dt[1,3,8] = 21.3f; mo_dt[1,3,9] = 21.5f; mo_dt[1,3,10] = 21.8f; mo_dt[1,3,11] = 22.1f; mo_dt[1,3,12] = 22.3f;
	mo_dt[1,4,0] = 18.7f; mo_dt[1,4,1] = 19.0f; mo_dt[1,4,2] = 19.2f; mo_dt[1,4,3] = 19.5f; mo_dt[1,4,4] = 19.8f; mo_dt[1,4,5] = 20.0f; mo_dt[1,4,6] = 20.3f; mo_dt[1,4,7] = 20.5f; mo_dt[1,4,8] = 20.8f; mo_dt[1,4,9] = 21.1f; mo_dt[1,4,10] = 21.3f; mo_dt[1,4,11] = 21.6f; mo_dt[1,4,12] = 21.8f;
	mo_dt[1,5,0] = 18.2f; mo_dt[1,5,1] = 18.5f; mo_dt[1,5,2] = 18.8f; mo_dt[1,5,3] = 19.0f; mo_dt[1,5,4] = 19.3f; mo_dt[1,5,5] = 19.6f; mo_dt[1,5,6] = 19.8f; mo_dt[1,5,7] = 20.1f; mo_dt[1,5,8] = 20.3f; mo_dt[1,5,9] = 20.6f; mo_dt[1,5,10] = 20.9f; mo_dt[1,5,11] = 21.1f; mo_dt[1,5,12] = 21.4f;
	mo_dt[1,6,0] = 17.9f; mo_dt[1,6,1] = 18.1f; mo_dt[1,6,2] = 18.4f; mo_dt[1,6,3] = 18.7f; mo_dt[1,6,4] = 19.0f; mo_dt[1,6,5] = 19.0f; mo_dt[1,6,6] = 19.5f; mo_dt[1,6,7] = 19.7f; mo_dt[1,6,8] = 20.0f; mo_dt[1,6,9] = 20.3f; mo_dt[1,6,10] = 20.5f; mo_dt[1,6,11] = 20.8f; mo_dt[1,6,12] = 21.0f;
	mo_dt[1,7,0] = 17.4f; mo_dt[1,7,1] = 17.7f; mo_dt[1,7,2] = 18.0f; mo_dt[1,7,3] = 18.3f; mo_dt[1,7,4] = 18.5f; mo_dt[1,7,5] = 18.8f; mo_dt[1,7,6] = 19.1f; mo_dt[1,7,7] = 19.3f; mo_dt[1,7,8] = 19.6f; mo_dt[1,7,9] = 19.8f; mo_dt[1,7,10] = 20.1f; mo_dt[1,7,11] = 20.3f; mo_dt[1,7,12] = 20.6f;
	mo_dt[1,8,0] = 16.7f; mo_dt[1,8,1] = 17.0f; mo_dt[1,8,2] = 17.2f; mo_dt[1,8,3] = 17.5f; mo_dt[1,8,4] = 17.8f; mo_dt[1,8,5] = 18.1f; mo_dt[1,8,6] = 18.3f; mo_dt[1,8,7] = 18.6f; mo_dt[1,8,8] = 18.9f; mo_dt[1,8,9] = 19.1f; mo_dt[1,8,10] = 19.3f; mo_dt[1,8,11] = 19.6f; mo_dt[1,8,12] = 19.8f;

	mo_dt[2,0,0] = 21.2f; mo_dt[2,0,1] = 21.4f; mo_dt[2,0,2] = 21.6f; mo_dt[2,0,3] = 21.9f; mo_dt[2,0,4] = 22.1f; mo_dt[2,0,5] = 22.3f; mo_dt[2,0,6] = 22.6f; mo_dt[2,0,7] = 22.8f; mo_dt[2,0,8] = 23.1f; mo_dt[2,0,9] = 23.4f; mo_dt[2,0,10] = 23.6f; mo_dt[2,0,11] = 23.9f; mo_dt[2,0,12] = 24.1f;
	mo_dt[2,1,0] = 20.6f; mo_dt[2,1,1] = 20.9f; mo_dt[2,1,2] = 21.1f; mo_dt[2,1,3] = 21.3f; mo_dt[2,1,4] = 21.6f; mo_dt[2,1,5] = 21.8f; mo_dt[2,1,6] = 22.1f; mo_dt[2,1,7] = 22.3f; mo_dt[2,1,8] = 22.6f; mo_dt[2,1,9] = 22.8f; mo_dt[2,1,10] = 23.1f; mo_dt[2,1,11] = 23.3f; mo_dt[2,1,12] = 23.6f;
	mo_dt[2,2,0] = 20.3f; mo_dt[2,2,1] = 20.5f; mo_dt[2,2,2] = 20.8f; mo_dt[2,2,3] = 21.0f; mo_dt[2,2,4] = 21.3f; mo_dt[2,2,5] = 21.5f; mo_dt[2,2,6] = 21.8f; mo_dt[2,2,7] = 22.0f; mo_dt[2,2,8] = 22.3f; mo_dt[2,2,9] = 22.5f; mo_dt[2,2,10] = 22.8f; mo_dt[2,2,11] = 23.0f; mo_dt[2,2,12] = 23.3f;
	mo_dt[2,3,0] = 20.0f; mo_dt[2,3,1] = 20.3f; mo_dt[2,3,2] = 20.5f; mo_dt[2,3,3] = 20.8f; mo_dt[2,3,4] = 21.0f; mo_dt[2,3,5] = 21.3f; mo_dt[2,3,6] = 21.5f; mo_dt[2,3,7] = 21.8f; mo_dt[2,3,8] = 22.0f; mo_dt[2,3,9] = 22.3f; mo_dt[2,3,10] = 22.5f; mo_dt[2,3,11] = 22.8f; mo_dt[2,3,12] = 23.0f;
	mo_dt[2,4,0] = 19.7f; mo_dt[2,4,1] = 19.9f; mo_dt[2,4,2] = 20.2f; mo_dt[2,4,3] = 20.4f; mo_dt[2,4,4] = 20.7f; mo_dt[2,4,5] = 20.9f; mo_dt[2,4,6] = 21.2f; mo_dt[2,4,7] = 21.5f; mo_dt[2,4,8] = 21.7f; mo_dt[2,4,9] = 22.0f; mo_dt[2,4,10] = 22.2f; mo_dt[2,4,11] = 22.5f; mo_dt[2,4,12] = 22.7f;
	mo_dt[2,5,0] = 19.3f; mo_dt[2,5,1] = 19.6f; mo_dt[2,5,2] = 19.9f; mo_dt[2,5,3] = 20.1f; mo_dt[2,5,4] = 20.4f; mo_dt[2,5,5] = 20.6f; mo_dt[2,5,6] = 20.9f; mo_dt[2,5,7] = 21.1f; mo_dt[2,5,8] = 21.4f; mo_dt[2,5,9] = 21.6f; mo_dt[2,5,10] = 21.9f; mo_dt[2,5,11] = 22.1f; mo_dt[2,5,12] = 22.4f;
	mo_dt[2,6,0] = 19.1f; mo_dt[2,6,1] = 19.3f; mo_dt[2,6,2] = 19.6f; mo_dt[2,6,3] = 19.9f; mo_dt[2,6,4] = 20.1f; mo_dt[2,6,5] = 20.4f; mo_dt[2,6,6] = 20.6f; mo_dt[2,6,7] = 20.9f; mo_dt[2,6,8] = 21.1f; mo_dt[2,6,9] = 21.4f; mo_dt[2,6,10] = 21.6f; mo_dt[2,6,11] = 21.9f; mo_dt[2,6,12] = 22.1f;
	mo_dt[2,7,0] = 18.8f; mo_dt[2,7,1] = 19.0f; mo_dt[2,7,2] = 19.3f; mo_dt[2,7,3] = 19.6f; mo_dt[2,7,4] = 19.8f; mo_dt[2,7,5] = 20.1f; mo_dt[2,7,6] = 20.3f; mo_dt[2,7,7] = 20.6f; mo_dt[2,7,8] = 20.8f; mo_dt[2,7,9] = 21.1f; mo_dt[2,7,10] = 21.3f; mo_dt[2,7,11] = 21.6f; mo_dt[2,7,12] = 21.8f;
	mo_dt[2,8,0] = 18.2f; mo_dt[2,8,1] = 18.5f; mo_dt[2,8,2] = 18.8f; mo_dt[2,8,3] = 19.0f; mo_dt[2,8,4] = 19.3f; mo_dt[2,8,5] = 19.6f; mo_dt[2,8,6] = 19.8f; mo_dt[2,8,7] = 20.1f; mo_dt[2,8,8] = 20.3f; mo_dt[2,8,9] = 20.6f; mo_dt[2,8,10] = 20.8f; mo_dt[2,8,11] = 21.0f; mo_dt[2,8,12] = 21.3f;

	mo_dt[3,0,0] = 24.1f; mo_dt[3,0,1] = 21.6f; mo_dt[3,0,2] = 21.7f; mo_dt[3,0,3] = 21.8f; mo_dt[3,0,4] = 21.9f; mo_dt[3,0,5] = 22.0f; mo_dt[3,0,6] = 22.2f; mo_dt[3,0,7] = 22.3f; mo_dt[3,0,8] = 22.5f; mo_dt[3,0,9] = 22.6f; mo_dt[3,0,10] = 22.8f; mo_dt[3,0,11] = 22.9f; mo_dt[3,0,12] = 23.1f;
	mo_dt[3,1,0] = 20.8f; mo_dt[3,1,1] = 20.9f; mo_dt[3,1,2] = 21.0f; mo_dt[3,1,3] = 21.1f; mo_dt[3,1,4] = 21.3f; mo_dt[3,1,5] = 21.4f; mo_dt[3,1,6] = 21.5f; mo_dt[3,1,7] = 21.7f; mo_dt[3,1,8] = 21.8f; mo_dt[3,1,9] = 22.0f; mo_dt[3,1,10] = 22.1f; mo_dt[3,1,11] = 22.3f; mo_dt[3,1,12] = 22.4f;
	mo_dt[3,2,0] = 20.4f; mo_dt[3,2,1] = 20.5f; mo_dt[3,2,2] = 20.6f; mo_dt[3,2,3] = 20.8f; mo_dt[3,2,4] = 20.9f; mo_dt[3,2,5] = 21.0f; mo_dt[3,2,6] = 21.2f; mo_dt[3,2,7] = 21.3f; mo_dt[3,2,8] = 21.5f; mo_dt[3,2,9] = 21.6f; mo_dt[3,2,10] = 21.8f; mo_dt[3,2,11] = 21.9f; mo_dt[3,2,12] = 22.1f;
	mo_dt[3,3,0] = 20.1f; mo_dt[3,3,1] = 20.2f; mo_dt[3,3,2] = 20.3f; mo_dt[3,3,3] = 20.5f; mo_dt[3,3,4] = 20.6f; mo_dt[3,3,5] = 20.7f; mo_dt[3,3,6] = 20.9f; mo_dt[3,3,7] = 21.0f; mo_dt[3,3,8] = 21.2f; mo_dt[3,3,9] = 21.3f; mo_dt[3,3,10] = 21.4f; mo_dt[3,3,11] = 21.6f; mo_dt[3,3,12] = 21.7f;
	mo_dt[3,4,0] = 19.6f; mo_dt[3,4,1] = 19.8f; mo_dt[3,4,2] = 19.9f; mo_dt[3,4,3] = 20.1f; mo_dt[3,4,4] = 20.2f; mo_dt[3,4,5] = 20.3f; mo_dt[3,4,6] = 20.5f; mo_dt[3,4,7] = 20.6f; mo_dt[3,4,8] = 20.8f; mo_dt[3,4,9] = 20.9f; mo_dt[3,4,10] = 21.0f; mo_dt[3,4,11] = 21.2f; mo_dt[3,4,12] = 21.3f;
	mo_dt[3,5,0] = 19.2f; mo_dt[3,5,1] = 19.4f; mo_dt[3,5,2] = 19.5f; mo_dt[3,5,3] = 19.7f; mo_dt[3,5,4] = 19.8f; mo_dt[3,5,5] = 19.9f; mo_dt[3,5,6] = 20.1f; mo_dt[3,5,7] = 20.2f; mo_dt[3,5,8] = 20.4f; mo_dt[3,5,9] = 20.5f; mo_dt[3,5,10] = 20.6f; mo_dt[3,5,11] = 20.8f; mo_dt[3,5,12] = 20.9f;
	mo_dt[3,6,0] = 18.9f; mo_dt[3,6,1] = 19.1f; mo_dt[3,6,2] = 19.2f; mo_dt[3,6,3] = 19.4f; mo_dt[3,6,4] = 19.5f; mo_dt[3,6,5] = 19.6f; mo_dt[3,6,6] = 19.8f; mo_dt[3,6,7] = 19.9f; mo_dt[3,6,8] = 20.1f; mo_dt[3,6,9] = 20.2f; mo_dt[3,6,10] = 20.3f; mo_dt[3,6,11] = 20.5f; mo_dt[3,6,12] = 20.6f;
	mo_dt[3,7,0] = 18.5f; mo_dt[3,7,1] = 18.7f; mo_dt[3,7,2] = 18.8f; mo_dt[3,7,3] = 19.0f; mo_dt[3,7,4] = 19.1f; mo_dt[3,7,5] = 19.3f; mo_dt[3,7,6] = 19.4f; mo_dt[3,7,7] = 19.6f; mo_dt[3,7,8] = 19.7f; mo_dt[3,7,9] = 19.8f; mo_dt[3,7,10] = 20.0f; mo_dt[3,7,11] = 20.1f; mo_dt[3,7,12] = 20.2f;
	mo_dt[3,8,0] = 17.8f; mo_dt[3,8,1] = 18.0f; mo_dt[3,8,2] = 18.2f; mo_dt[3,8,3] = 18.3f; mo_dt[3,8,4] = 18.5f; mo_dt[3,8,5] = 18.6f; mo_dt[3,8,6] = 18.8f; mo_dt[3,8,7] = 18.9f; mo_dt[3,8,8] = 19.1f; mo_dt[3,8,9] = 19.2f; mo_dt[3,8,10] = 19.3f; mo_dt[3,8,11] = 19.4f; mo_dt[3,8,12] = 19.5f;


	float sumIN = MndCIL + MndCIR + MndLIL + MndLIR;
	float[] sumINlist = { 19.5f, 20f, 20.5f, 21f, 21.5f, 22f, 22.5f, 23f, 23.5f, 24f, 24.5f, 25f, 25.5f };

	int col_ind;

	col_ind = get_index(sumINlist, sumIN, 13);

	float[] percent = { 95.0f, 85.0f, 75.0f, 65.0f, 50.0f, 35.0f, 25.0f, 15.0f, 5.0f };
	int row_ind = get_index(percent, p, 9);

	return mo_dt[table_select,row_ind,col_ind];
}

int get_index(float[] arr, float ele, int len)
{
	float minDiff = 999999999f;
	int index = 0;

	for (int i = 0; i < len; i++)
	{
		float diff = Mathf.Abs(arr[i] - ele);
		if(diff<minDiff)
		{
			minDiff = diff;
			index = i;
		}
	}

	return index;
}


//moyer's inputField and variables
	public TMP_InputField p;
	private float moyer_width_mnd,Mnd_moyer_SR,Mnd_Moyer_discrepancy,moyer_width_mx,Mx_moyer_SR,Mx_Moyer_discrepancy;

	public TMP_Text maleMandMoy,maleMaxMoy,maletotmanMoy,maletotmaxMoy,femaleMandMoy,femaleMaxMoy,femaletotmanMoy,femaletotmaxMoy;

	public void calculateMoyerMale()
	{
		Sum_of_four_Mnd_Incisors = ftpr(MndCIR) + ftpr(MndCIL) + ftpr(MndLIR) + ftpr(MndLIL);
		moyer_width_mnd = moyer_data(1, ftpr(MndCIR), ftpr(MndCIL), ftpr(MndLIR), ftpr(MndLIL), ftpr(p));
		Mnd_moyer_SR = moyer_width_mnd * 2 + Sum_of_four_Mnd_Incisors + ftpr(CBR) + ftpr(CBL);
		Mnd_Moyer_discrepancy = ftpr(Mndd) - Mnd_moyer_SR;

		moyer_width_mx = moyer_data(3, ftpr(MndCIR), ftpr(MndCIL), ftpr(MndLIR), ftpr(MndLIL), ftpr(p));
		Mx_moyer_SR = moyer_width_mx * 2 + ftpr(MxCIR) + ftpr(MxCIL) + ftpr(MxLIR) + ftpr(MxLIL);
		Mx_Moyer_discrepancy = ftpr(Mxd) - Mx_moyer_SR;

		maleMandMoy.text = moyer_width_mnd.ToString();
		maleMaxMoy.text = moyer_width_mx.ToString();
		maletotmanMoy.text = (Mathf.Round(Mnd_Moyer_discrepancy * 100) / 100).ToString();
		maletotmaxMoy.text = (Mathf.Round(Mx_Moyer_discrepancy * 100) / 100).ToString();

	}

	public void calculateMoyerFemale()
	{
		Sum_of_four_Mnd_Incisors = ftpr(MndCIR) + ftpr(MndCIL) + ftpr(MndLIR) + ftpr(MndLIL);
		moyer_width_mnd = moyer_data(2, ftpr(MndCIR), ftpr(MndCIL), ftpr(MndLIR), ftpr(MndLIL), ftpr(p));
		Mnd_moyer_SR = moyer_width_mnd * 2 + Sum_of_four_Mnd_Incisors + ftpr(CBR) + ftpr(CBL);
		Mnd_Moyer_discrepancy = ftpr(Mndd) - Mnd_moyer_SR;

		moyer_width_mx = moyer_data(4, ftpr(MndCIR), ftpr(MndCIL), ftpr(MndLIR), ftpr(MndLIL), ftpr(p));
		Mx_moyer_SR = moyer_width_mx * 2 + ftpr(MxCIR) + ftpr(MxCIL) + ftpr(MxLIR) + ftpr(MxLIL);
		Mx_Moyer_discrepancy = ftpr(Mxd) - Mx_moyer_SR;

		femaleMandMoy.text = moyer_width_mnd.ToString();
		femaleMaxMoy.text = moyer_width_mx.ToString();
		femaletotmanMoy.text = (Mathf.Round(Mnd_Moyer_discrepancy * 100) / 100).ToString();
		femaletotmaxMoy.text = (Mathf.Round(Mx_Moyer_discrepancy * 100) / 100).ToString();

	}

	public TMP_Text bhopalMaleMax,bhopalMaleMan,bhopalFemaleMax,bhopalFemaleMan;

	public void calculateRegionalMoyerBhopal()
	{
		bhopalMaleMax.text = (17.272 + 0.183*Sum_of_four_Mnd_Incisors).ToString();
		bhopalMaleMan.text = (13.914 + 0.297*Sum_of_four_Mnd_Incisors).ToString();
		bhopalFemaleMax.text = (17.151 + 0.173*Sum_of_four_Mnd_Incisors).ToString();
		bhopalFemaleMan.text = (12.452 + 0.349*Sum_of_four_Mnd_Incisors).ToString();
	}

	public TMP_InputField bucco_max_left,bucco_max_right;
	public TMP_Text maxWidthLeft,maxWidthRight,manWidthLeft,manWidthRight;

	public void calculateFoudaAnalysis()
	{
		maxWidthLeft.text = (ftpr(bucco_max_left)*2 - 1).ToString();
		maxWidthRight.text = (ftpr(bucco_max_right)*2 - 1).ToString();
		manWidthLeft.text = (ftpr(bucco_max_left)*2).ToString();
		manWidthRight.text = (ftpr(bucco_max_right)*2).ToString();
	}

	public TMP_InputField MaxFirstPermMol_left,MandFirstPermMol_left,MaxFirstPermMol_right,MandFirstPermMol_right;
	private float sum_mesiodistal_lateral_inc_and_first_perm_molar_left_mand,sum_mesiodistal_lateral_inc_and_first_perm_molar_left_max,sum_mesiodistal_lateral_inc_and_first_perm_molar_right_max,sum_mesiodistal_lateral_inc_and_first_perm_molar_right_mand;

	public TMP_Text trankmaxMalesleft,trankmaxMalesRight,trankManMalesleft,trankManMalesRight,trankmaxFeMalesleft,trankmaxFeMalesRight,trankManFeMalesleft,trankManFeMalesRight;
	public void calculateTrankmannAnalysis()
	{
		//0->left, 1->right
		//0->max, 1->mand
		sum_mesiodistal_lateral_inc_and_first_perm_molar_left_max = ftpr(MaxFirstPermMol_left) + ftpr(MxLIL);
		sum_mesiodistal_lateral_inc_and_first_perm_molar_left_mand = ftpr(MandFirstPermMol_left) + ftpr(MndLIL);

		sum_mesiodistal_lateral_inc_and_first_perm_molar_right_max = ftpr(MaxFirstPermMol_right) + ftpr(MxLIR);
		sum_mesiodistal_lateral_inc_and_first_perm_molar_right_mand = ftpr(MandFirstPermMol_right) + ftpr(MndLIR);

		trankmaxMalesleft.text = (0.93*sum_mesiodistal_lateral_inc_and_first_perm_molar_left_max + 5.5).ToString();
		trankmaxMalesRight.text = (0.93*sum_mesiodistal_lateral_inc_and_first_perm_molar_right_max + 5.5).ToString();
		trankManMalesleft.text = (0.94*sum_mesiodistal_lateral_inc_and_first_perm_molar_left_mand + 5.06).ToString();
		trankManMalesRight.text = (0.94*sum_mesiodistal_lateral_inc_and_first_perm_molar_right_mand + 5.06).ToString();
		trankmaxFeMalesleft.text = (0.99*sum_mesiodistal_lateral_inc_and_first_perm_molar_left_max + 4.47).ToString();
		trankmaxFeMalesRight.text = (0.99*sum_mesiodistal_lateral_inc_and_first_perm_molar_right_max + 4.47).ToString();
		trankManFeMalesleft.text = (0.96*sum_mesiodistal_lateral_inc_and_first_perm_molar_left_mand + 4.43).ToString();
		trankManFeMalesRight.text = (0.96*sum_mesiodistal_lateral_inc_and_first_perm_molar_right_mand + 4.43).ToString();
		
	}
	public TMP_InputField MaxFirstPermMol_left_bachmann;
	public TMP_Text maxillaryWidthBachhmann,mandibularWidthBachmann;
	public void calculateBachmann()
	{
		maxillaryWidthBachhmann.text = (0.81*ftpr(MxLIL) + 0.54*ftpr(MaxFirstPermMol_left_bachmann) + 0.56*ftpr(MndLIL) + 6.98).ToString();
		mandibularWidthBachmann.text = (0.71*ftpr(MxLIL) + 0.39*ftpr(MaxFirstPermMol_left_bachmann) + 0.86*ftpr(MndLIL) + 6.96).ToString();
	}
	
	
		
}
