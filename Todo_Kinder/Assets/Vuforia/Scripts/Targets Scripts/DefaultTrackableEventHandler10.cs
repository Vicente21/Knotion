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
    public class DefaultTrackableEventHandler10 : MonoBehaviour,
                                                ITrackableEventHandler
    {
		
		public AudioSource audio1;
		public float delay = 0.0f;
		public float delay1 = 1.0f, delay2 = 2.0f, delay3 = 2.0f, delay4 = 2.7f, delay5 = 2.5f;
        #region PRIVATE_MEMBER_VARIABLES
		private Control control;
        private TrackableBehaviour mTrackableBehaviour;
		//public CaraAna cara;
		public GameObject go;
		public Texture[] caras;
        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
			GameObject controlMaestro = GameObject.Find ("Control");
			//go.GetComponent<Renderer> ().material.mainTexture = caras [0];
			//cara = FindObjectOfType(typeof(CaraAna)) as CaraAna;
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
				control.Encontro_Target10 ();
				//StartCoroutine (Play_Audio());
				StartCoroutine (ChangeFace ());
				control.DesaparecerTrack ();
				audio1.Play ();
				delay1 = 1.0f;
				delay2 = 2.0f;
				delay3 = 2.0f;
				delay4 = 2.7f;
				delay5 = 2.5f;
            }
            else
            {
                OnTrackingLost();
				control.Start ();
				//StopCoroutine (Play_Audio());
				StopAllCoroutines();
				delay1 = 0.0f;
				delay2 = 0.0f;
				delay3 = 0.0f;
				delay4 = 0.0f;
				delay5 = 0.0f;
				audio1.Stop ();
				control.AparecerTrack ();
            }
        }

		IEnumerator ChangeFace () {
			yield return new WaitForSeconds (delay);
			go.GetComponent<Renderer> ().material.mainTexture = caras [0];
			yield return new WaitForSeconds (delay1);
			go.GetComponent<Renderer> ().material.mainTexture = caras [1];
			yield return new WaitForSeconds (delay2);
			go.GetComponent<Renderer> ().material.mainTexture = caras [2];
			yield return new WaitForSeconds (delay3);
			go.GetComponent<Renderer> ().material.mainTexture = caras [3];
			yield return new WaitForSeconds (delay4);
			go.GetComponent<Renderer> ().material.mainTexture = caras [4];
			yield return new WaitForSeconds (delay5);
			go.GetComponent<Renderer> ().material.mainTexture = caras [0];
		}

		IEnumerator Play_Audio () {
			yield return new WaitForSeconds (delay);
			audio1.Play ();
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
