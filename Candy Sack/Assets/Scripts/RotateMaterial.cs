using UnityEngine;
using System.Collections;

public class RotateMaterial : MonoBehaviour {

	float speed = 0.5f;

	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * 15 * Time.deltaTime);	}
}
