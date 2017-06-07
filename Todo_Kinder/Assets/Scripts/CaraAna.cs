using UnityEngine;
using System.Collections;

public class CaraAna : MonoBehaviour {

	public GameObject go;
	public Texture[] caras;

	void Start () {
		StartCoroutine (ChangeFace ());
		go.GetComponent<Renderer> ().material.mainTexture = caras [0];
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void Cambio(){
		StartCoroutine (ChangeFace ());
	}

	public void Parar(){
		StopCoroutine (ChangeFace ());
		go.GetComponent<Renderer> ().material.mainTexture = caras [0];
	}

	IEnumerator ChangeFace () {
		
		go.GetComponent<Renderer> ().material.mainTexture = caras [0];
		yield return new WaitForSeconds (1);
		go.GetComponent<Renderer> ().material.mainTexture = caras [1];
		yield return new WaitForSeconds (2);
		go.GetComponent<Renderer> ().material.mainTexture = caras [2];
		yield return new WaitForSeconds (2);
		go.GetComponent<Renderer> ().material.mainTexture = caras [3];
		yield return new WaitForSeconds (2.7f);
		go.GetComponent<Renderer> ().material.mainTexture = caras [4];
		yield return new WaitForSeconds (2.5f);
		go.GetComponent<Renderer> ().material.mainTexture = caras [0];
	}
}
