using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ControlIng : MonoBehaviour {
	public GameObject[] Letras;
	public int LetraActual;
	public GameObject abc;
	public bool adelante;
	public bool stop;
	public GameObject AdelanteCol;
	public GameObject AtrasCol;
    public Button adelanteB;
    public Button atrasB;
    public AudioSource[] Audios;
    private Animator animA;
	private Animator animB;
	private Animator animC;
	private Animator animD;
	private Animator animE;
	private Animator animF;
	private Animator animG;
	private Animator animH;
	private Animator animI;
	private Animator animJ;
	private Animator animK;
	private Animator animL;
	private Animator animM;
	private Animator animN;
	private Animator animO;
	private Animator animP;
	private Animator animQ;
	private Animator animR;
	private Animator animS;
	private Animator animT;
	private Animator animU;
	private Animator animV;
	private Animator animW;
	private Animator animX;
	private Animator animY;
	private Animator animZ;
	public bool activaA;
	public bool activaB;
	public bool activaC;
	public bool activaD;
	public bool activaE;
	public bool activaF;
	public bool activaG;
	public bool activaH;
	public bool activaI;
	public bool activaJ;
	public bool activaK;
	public bool activaL;
	public bool activaM;
	public bool activaN;
	public bool activaO;
	public bool activaP;
	public bool activaQ;
	public bool activaR;
	public bool activaS;
	public bool activaT;
	public bool activaU;
	public bool activaV;
	public bool activaW;
	public bool activaX;
	public bool activaY;
	public bool activaZ;
	// Use this for initialization
	void Start () 
	{
		
	}
	// Update is called once per frame
	void Update () 
	{ 
		if (LetraActual < 0) 
		{
			LetraActual = 0;
		}
		if (LetraActual > 25) 
		{
			LetraActual = 25;
		}
		animA = Letras [0].GetComponent<Animator> ();
		animB = Letras [1].GetComponent<Animator> ();
		animC = Letras [2].GetComponent<Animator> ();
		animD = Letras [3].GetComponent<Animator> ();
		animE = Letras [4].GetComponent<Animator> ();
		animF = Letras [5].GetComponent<Animator> ();
		animG = Letras [6].GetComponent<Animator> ();
		animH = Letras [7].GetComponent<Animator> ();
		animI = Letras [8].GetComponent<Animator> ();
		animJ = Letras [9].GetComponent<Animator> ();
		animK = Letras [10].GetComponent<Animator> ();
		animL = Letras [11].GetComponent<Animator> ();
		animM = Letras [12].GetComponent<Animator> ();
		animN = Letras [13].GetComponent<Animator> ();
		animO = Letras [14].GetComponent<Animator> ();
		animP = Letras [15].GetComponent<Animator> ();
		animQ = Letras [16].GetComponent<Animator> ();
		animR = Letras [17].GetComponent<Animator> ();
		animS = Letras [18].GetComponent<Animator> ();
		animT = Letras [19].GetComponent<Animator> ();
		animU = Letras [20].GetComponent<Animator> ();
		animV = Letras [21].GetComponent<Animator> ();
		animW = Letras [22].GetComponent<Animator> ();
		animX = Letras [23].GetComponent<Animator> ();
		animY = Letras [24].GetComponent<Animator> ();
		animZ = Letras [25].GetComponent<Animator> ();
		animA.SetBool ("activa",activaA);
		animB.SetBool ("activa",activaB);
		animC.SetBool ("activa",activaC);
		animD.SetBool ("activa",activaD);
		animE.SetBool ("activa",activaE);
		animF.SetBool ("activa",activaF);
		animG.SetBool ("activa",activaG);
		animH.SetBool ("activa",activaH);
		animI.SetBool ("activa",activaI);
		animJ.SetBool ("activa",activaJ);
		animK.SetBool ("activa",activaK);
		animL.SetBool ("activa",activaL);
		animM.SetBool ("activa",activaM);
		animN.SetBool ("activa",activaN);
		animO.SetBool ("activa",activaO);
		animP.SetBool ("activa",activaP);
		animQ.SetBool ("activa",activaQ);
		animR.SetBool ("activa",activaR);
		animS.SetBool ("activa",activaS);
		animT.SetBool ("activa",activaT);
		animU.SetBool ("activa",activaU);
		animV.SetBool ("activa",activaV);
		animW.SetBool ("activa",activaW);
		animX.SetBool ("activa",activaX);
		animY.SetBool ("activa",activaY);
		animZ.SetBool ("activa",activaZ);

		if (stop == true) 
		{
			abc.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,0);
		}
		for(int i = 0; i < 26; i++)
		{
			Letras [i].GetComponent<Collider2D> ().enabled = false;
		}

		if (adelante == true) 
		{
			Letras [LetraActual].GetComponent<Collider2D> ().enabled = true;
			abc.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-1, 0)* 750;
		} 
		 
		if (adelante == false) 
		{
			Letras[LetraActual].GetComponent<Collider2D> ().enabled = true;
			abc.GetComponent<Rigidbody2D> ().velocity = new Vector2 (1, 0)* 750;
		}

		if (LetraActual == 0) 
		{
			activaA = true;
            atrasB.interactable = false;
        }
		else 
		{
			activaA = false;
        }
		if (LetraActual == 1) 
		{
			activaB = true;
        } else 
		{
			activaB = false;
		}
		if (LetraActual == 2) 
		{
			activaC = true;
        } else 
		{
            activaC = false;
		}
		if (LetraActual == 3) 
		{
			activaD = true;
        } else 
		{
			activaD = false;
        }
		if (LetraActual == 4) 
		{
			activaE = true;
        } else 
		{
			activaE = false;
		}
		if (LetraActual == 5) 
		{
			activaF = true;
        } else 
		{
			activaF = false;
		}
		if (LetraActual == 6) 
		{
			activaG = true;
        } else 
		{
			activaG = false;
		}
		if (LetraActual == 7) 
		{
			activaH = true;
        } else 
		{
			activaH = false;
		}
		if (LetraActual == 8) 
		{
			activaI = true;
        } else 
		{
			activaI = false;
		}
		if (LetraActual == 9) 
		{
			activaJ = true;
        } else 
		{
			activaJ = false;
		}
		if (LetraActual == 10) 
		{
			activaK = true;
        } else 
		{
			activaK = false;
		}
		if (LetraActual == 11) 
		{
			activaL = true;
        } else 
		{
			activaL = false;
		}
		if (LetraActual == 12) 
		{
			activaM = true;
        } else 
		{
			activaM = false;
		}
		if (LetraActual == 13) 
		{
			activaN = true;
		} 
		else 
		{
			activaN = false;
		}
		if (LetraActual == 14) 
		{
			activaO = true;
        } else 
		{
			activaO = false;
		}
		if (LetraActual == 15) 
		{
			activaP = true;
        } else 
		{
			activaP = false;
		}
		if (LetraActual == 16) 
		{
			activaQ = true;
        } else 
		{
			activaQ = false;
		}
		if (LetraActual == 17) 
		{
			activaR = true;
        } else 
		{
			activaR = false;
		}
		if (LetraActual == 18) 
		{
			activaS = true;
        } else 
		{
			activaS = false;
		}
		if (LetraActual == 19) 
		{
			activaT = true;
        } else 
		{
			activaT = false;
		}
		if (LetraActual == 20) 
		{
			activaU = true;
        } else 
		{
			activaU = false;
		}
		if (LetraActual == 21) 
		{
			activaV = true;
        } else 
		{
			activaV = false;
		}
		if (LetraActual == 22) 
		{
			activaW = true;
        } else 
		{
			activaW = false;
        }
		if (LetraActual == 23) 
		{
			activaX = true;
        } else 
		{
			activaX = false;
        }
		if (LetraActual == 24) 
		{
			activaY = true;
        } else 
		{
			activaY = false;
        }
		if (LetraActual == 25) 
		{
			activaZ = true;
            adelanteB.interactable = false;
        }
        else 
		{
			activaZ = false;
        }

	}

	public void Cerrar_Ventana () {
		SceneManager.LoadScene ("Loading");
	}
	public void KnotionApp () {
		Application.OpenURL ("knotion://");
	}
	public void Cambiar_Ingles () 
	{
		SceneManager.LoadScene ("Abecedario Ingles");
	}
	public void Cambiar_Español () 
	{
		SceneManager.LoadScene ("Abecedario Español");
	}
	public void Atrass()
	{
        StartCoroutine("AtrassC");
	}
	public void Adelantee()
	{
        StartCoroutine("AdelanteeC");
    }

    IEnumerator AdelanteeC()
    {  
            adelante = true;
            AtrasCol.SetActive(false);
            AdelanteCol.SetActive(true);
            LetraActual += 1;
            Audios[LetraActual].Play();
            adelanteB.interactable = false;
            atrasB.interactable = false;
        yield return new WaitForSeconds(1f);
        adelanteB.interactable = true;
        atrasB.interactable = true;
    }

    IEnumerator AtrassC()
    {
            adelante = false;
            AdelanteCol.SetActive(false);
            AtrasCol.SetActive(true);
            LetraActual -= 1;
            Audios[LetraActual].Play();
             atrasB.interactable = false;
            adelanteB.interactable = false;
        yield return new WaitForSeconds(1f);
        atrasB.interactable = true;
        adelanteB.interactable = true;
    }
}
