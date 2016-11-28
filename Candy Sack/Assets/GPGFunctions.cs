using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GPGFunctions : MonoBehaviour
{
	#region PUBLIC_VAR
	public string leaderboard;
	public PlayerInfo playStats;
	public GameObject playerLogin;
	#endregion
	#region DEFAULT_UNITY_CALLBACKS
	void Start ()
	{
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;

		// Activate the Google Play Games platform
		GooglePlayGames.PlayGamesPlatform.Activate();
	
		/// Login In Into Your Google+ Account
		Social.localUser.Authenticate ((bool success) =>
			{
				return;
			});

	}

	#endregion
	#region BUTTON_CALLBACKS
	/// <summary>
	/// Login In Into Your Google+ Account
	/// </summary>
	public void LogIn ()
	{
		Social.localUser.Authenticate ((bool success) =>
			{
				return;

			});
	}
	/// <summary>
	/// Shows All Available Leaderborad
	/// </summary>
	public void OnShowLeaderBoard ()
	{
		if (Social.localUser.authenticated) {
			((PlayGamesPlatform)Social.Active).ShowLeaderboardUI (leaderboard); // Show current (Active) leaderboard
		}

	}
	/// <summary>
	/// Adds Score To leader board
	/// </summary>
	public void OnAddScoreToLeaderBoard ()
	{
		if (Social.localUser.authenticated) {
			Social.ReportScore (playStats.score, leaderboard, (bool success) =>
				{
					return;
				});
		}
	}
	/// <summary>
	/// On Logout of your Google+ Account
	/// </summary>
	public void OnLogOut ()
	{
		((PlayGamesPlatform)Social.Active).SignOut ();
	}

	public void CheckAuthScores(){
		
		if (Social.localUser.authenticated) {
			OnShowLeaderBoard ();
		} else {
			playerLogin.SetActive (true);
		}
	}
	#endregion
}