using UnityEngine;
using System.Collections;

public class Testeo : MonoBehaviour {
	
    public GameObject modelo;
	//public GameObject modelo2;

    public AudioSource audio1;
	//public AudioSource audio2;
	//public AudioSource audio3;
	//public AudioSource audio4;

	//public float delay1 = 0.0f;
	//public float delay2 = 0.0f;
	//public float delay3 = 0.0f;
	//public float delay4 = 0.0f;
	bool isEnable;

	// Use this for initialization
	void Start () {
        isEnable = false;
		modelo.SetActive (false);
		//modelo2.SetActive (false);
		//Todo ();
	}
    
    public void Todo(){
        if(isEnable == false){
			modelo.SetActive (true);
			//modelo2.SetActive (true);
			//audio1.PlayDelayed (delay1);
			//audio2.PlayDelayed (delay2);
			//audio3.PlayDelayed (delay3);
			//audio4.PlayDelayed (delay4);
            //audio#.playDelayed(delay#);
            isEnable = true;
        }else{
			modelo.SetActive (false);
			//modelo2.SetActive (false);
            //audio1.Stop();
			//audio2.Stop();
			//audio3.Stop();
			//audio4.Stop();
			//audio2.Stop ();
            //audio#.Stop();
            isEnable = false;
        }
    }
	

}