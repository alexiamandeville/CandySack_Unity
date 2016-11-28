using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour {

	//scoring
	public int score;
	public Text playerScore;
	public Text gameOverScore;
	public GameObject scoreObject;

	//mouse stuff
	Vector3 mousePosition;
	float playerPositionx;

	Animator anim;

	//screens
	public GameObject playfield;
	public GameObject gameOver;

	public GPGFunctions googlePlay;

	public void Reset(){

		score = 0;

		//make original
		transform.localScale = new Vector3 (1, 1, 1);}

	void OnParticleCollision(GameObject other)
	{
			//add to score
			score += 10;

			//make larger
			transform.localScale += new Vector3 (0.003F, 0.003F, 0.003F);

		if (other.GetComponent<ParticleBehavior> ().candyType == ParticleBehavior.CandyType.syringe){
			playfield.SetActive (false);
			gameOver.SetActive (true);
			scoreObject.SetActive (false);
			googlePlay.OnAddScoreToLeaderBoard ();
		}

		if (other.GetComponent<ParticleBehavior> ().candyType == ParticleBehavior.CandyType.razor) {
			playfield.SetActive (false);
			gameOver.SetActive (true);
			scoreObject.SetActive (false);
			googlePlay.OnAddScoreToLeaderBoard ();
		}

		if (other.GetComponent<ParticleBehavior> ().candyType == ParticleBehavior.CandyType.diet) {
			//make smaller
			transform.localScale -= new Vector3 (0.11F, 0.11F, 0.11F);
		}

		AudioSource audio = GetComponent<AudioSource> ();
		//audio.Play ();
	}
		

	void Update () {

		anim = GetComponentInChildren<Animator> (); 

		if(Input.GetMouseButton (0)) {
			gameObject.GetComponent<SphereCollider>().enabled = true;
			//anim.Stop ();
			anim.Play("FingerPulse", -1, 0f);
		}

		if (Input.GetMouseButtonUp (0)) {
			anim.Play ("FingerPulse"); 	//play pulse animation only when not clicked or touching screen

			gameObject.GetComponent<SphereCollider>().enabled = false;
		}
			
		//move finger to mouse position
		Vector3 temp = Input.mousePosition;
		temp.z = 10f; // Set this to be the distance you want the object to be placed in front of the camera.
		this.transform.position = Camera.main.ScreenToWorldPoint(temp);

		//update score on canvas
		playerScore.text = score.ToString();
		gameOverScore.text = score.ToString();




	}



	/*void CandyCause(candyType candy){

		//make that ish smalllller
		if (candy == candyType.diet) {
			transform.localScale += new Vector3 (-0.008F, -0.008F, -0.008F);
		}

		if (candy == candyType.syringe) {
			gameOver.SetActive (true);
			playfield.SetActive (true);
		}
	}*/

}
