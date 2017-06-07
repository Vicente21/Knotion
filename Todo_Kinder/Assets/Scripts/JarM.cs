using UnityEngine;
using System.Collections;

public class JarM : MonoBehaviour {

	public GameObject jar1, jar2, jar3;
	// Use this for initialization
	void Start () {
		jar1.SetActive (false);
		jar2.SetActive (false);
		jar3.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Lanzar(){
		StartCoroutine (Jar ());
	}

	IEnumerator Jar(){
		yield return new WaitForSeconds (0);
		jar1.SetActive (true);
		yield return new WaitForSeconds (2.12f);
		jar1.SetActive (false);
		jar2.SetActive (true);
		yield return new WaitForSeconds (0.9f);
		jar2.SetActive (false);
		jar3.SetActive (true);
	}
	 
}
