using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class huckaba_analysis : MonoBehaviour
{
    //common variables needed for most of the arch length ones
    public TMP_InputField Mxd , Mndd , CBR , CBL , MxCIR , MxCIL , MndCIR , MndCIL , MxLIR , MxLIL , MndLIR , MndLIL ;
    public TMP_InputField MxSMR,MxSML,MndSMR,MndSML,MxCaR,MxCaL,MndCaR,MndCaL,MxPMR1,MxPML1,MndPMR1,MndPML1,MxPMR2,MxPML2,MndPMR2,MndPML2,MxX2R,MxX2L,MndX2R,MndX2L;

	private float ftpr(TMP_InputField in_field)
	{
		return float.Parse(in_field.text);
	}
	private float Mndb,Mxb,c,MxX1R,MxX1L,MxXR,MxXL,MxACaR,MxACaL,MxAPMR1,MxAPML1,MxAPMR2,MxAPML2,MndX1R,MndX1L,MndXR,MndXL,MndACaR,MndACaL,MndAPMR1,MndAPML1,MndAPMR2,MndAPML2,MxaH,MxTotal_discrepancy_H,MndaH,MndTotal_discrepancy_H;
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

	}

		
}
