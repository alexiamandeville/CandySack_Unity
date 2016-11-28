using UnityEngine;
using System.Collections;

public class UIFunctionality : MonoBehaviour {


	public void OnRateButtonClick(){
		#if UNITY_ANDROID
		Application.OpenURL("market://details?id=com.GoldFaceGames.CandySack1");
		#elif UNITY_IPHONE
		Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_APP_ID");
		#endif
	}



}
