/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using System.Collections;
namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler48 : MonoBehaviour,
                                                ITrackableEventHandler
    {
		public Texture[] mat;
		public GameObject[] voc;
		public GameObject[] con;
		public AudioSource audio1;
		private float delay = 0.4f, delay1 = 5.8f, delay2 = 1.5f, delay3 = 0.7f, delay4 = 2.0f;

        #region PRIVATE_MEMBER_VARIABLES
		private Control control;
        private TrackableBehaviour mTrackableBehaviour;
    
        #endregion // PRIVATE_MEMBER_VARIABLES

		//5.8 solo voc
		//7.5 todos
		//8   solo con
		//10 todos
        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
			GameObject controlMaestro = GameObject.Find ("Control");
			if (controlMaestro != null) {
				control = controlMaestro.GetComponent<Control> ();
			} else {
				Debug.Log ("Objeto no encontrado");
			}
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
				control.Encontro_Target47 ();
				StartCoroutine (Play_Audio());
				StartCoroutine (MatVoc ());
				delay = 0.4f;
				delay1 = 5.8f;
				delay2 = 1.5f;
				delay3 = 0.7f;
				delay4 = 2.0f;
				control.DesaparecerTrack ();

            }
            else
            {
                OnTrackingLost();
				control.Start ();
				delay1 = 0.0f;
				delay2 = 0.0f;
				delay3 = 0.0f;
				delay4 = 0.0f;
				StopAllCoroutines ();
				audio1.Stop ();
				control.AparecerTrack ();
            }
        }

		IEnumerator Play_Audio () {
			yield return new WaitForSeconds (delay);
			audio1.Play ();
		}

		IEnumerator MatVoc(){
			yield return new WaitForSeconds (0);
			voc[0].GetComponent<Renderer> ().material.mainTexture = mat[0];
			voc[1].GetComponent<Renderer> ().material.mainTexture = mat[0];
			voc[2].GetComponent<Renderer> ().material.mainTexture = mat[0];
			con[0].GetComponent<Renderer> ().material.mainTexture = mat[0];
			con[1].GetComponent<Renderer> ().material.mainTexture = mat[0];
			con[2].GetComponent<Renderer> ().material.mainTexture = mat[0];
			con[3].GetComponent<Renderer> ().material.mainTexture = mat[0];
			yield return new WaitForSeconds (delay1);
			voc[0].GetComponent<Renderer> ().material.mainTexture = mat[1];
			voc[1].GetComponent<Renderer> ().material.mainTexture = mat[1];
			voc[2].GetComponent<Renderer> ().material.mainTexture = mat[1];
			con[0].GetComponent<Renderer> ().material.mainTexture = mat[0];
			con[1].GetComponent<Renderer> ().material.mainTexture = mat[0];
			con[2].GetComponent<Renderer> ().material.mainTexture = mat[0];
			con[3].GetComponent<Renderer> ().material.mainTexture = mat[0];
			yield return new WaitForSeconds (delay2);
			voc[0].GetComponent<Renderer> ().material.mainTexture = mat[0];
			voc[1].GetComponent<Renderer> ().material.mainTexture = mat[0];
			voc[2].GetComponent<Renderer> ().material.mainTexture = mat[0];
			con[0].GetComponent<Renderer> ().material.mainTexture = mat[0];
			con[1].GetComponent<Renderer> ().material.mainTexture = mat[0];
			con[2].GetComponent<Renderer> ().material.mainTexture = mat[0];
			con[3].GetComponent<Renderer> ().material.mainTexture = mat[0];
			yield return new WaitForSeconds (delay3);
			voc[0].GetComponent<Renderer> ().material.mainTexture = mat[0];
			voc[1].GetComponent<Renderer> ().material.mainTexture = mat[0];
			voc[2].GetComponent<Renderer> ().material.mainTexture = mat[0];
			con[0].GetComponent<Renderer> ().material.mainTexture = mat[2];
			con[1].GetComponent<Renderer> ().material.mainTexture = mat[2];
			con[2].GetComponent<Renderer> ().material.mainTexture = mat[2];
			con[3].GetComponent<Renderer> ().material.mainTexture = mat[2];
			yield return new WaitForSeconds (delay4);
			voc[0].GetComponent<Renderer> ().material.mainTexture = mat[0];
			voc[1].GetComponent<Renderer> ().material.mainTexture = mat[0];
			voc[2].GetComponent<Renderer> ().material.mainTexture = mat[0];
			con[0].GetComponent<Renderer> ().material.mainTexture = mat[0];
			con[1].GetComponent<Renderer> ().material.mainTexture = mat[0];
			con[2].GetComponent<Renderer> ().material.mainTexture = mat[0];
			con[3].GetComponent<Renderer> ().material.mainTexture = mat[0];
		}
        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        }

        #endregion // PRIVATE_METHODS
    }
}
