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
    public class DefaultTrackableEventHandler9 : MonoBehaviour,
                                                ITrackableEventHandler
    {
		public GameObject go;
		public AudioSource audio1, audio2, audio3, audio4;
		public float delay = 0.0f, delay1 = 0.0f, delay2 = 0.0f, delay3 = 0.0f, delay4 = 0.0f;
		public float delay5 = 0.0f, delay6 = 4.55f, delay7 = 6.9f;
        #region PRIVATE_MEMBER_VARIABLES
		private Control control;
        private TrackableBehaviour mTrackableBehaviour;
		public Texture[] hoja;
        #endregion // PRIVATE_MEMBER_VARIABLES



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
				control.Encontro_Target9 ();
				StartCoroutine (Play_Audio());
				StartCoroutine (Change ());
				control.DesaparecerTrack ();
				delay5 = 0.0f;
				delay6 = 4.55f;
				delay7 = 6.9f;

            }
            else
            {
                OnTrackingLost();
				control.Start ();
				StopCoroutine (Play_Audio());
				audio1.Stop ();
				control.AparecerTrack ();
				delay5 = 0.0f;
				delay6 = 0.0f;
				delay7 = 0.0f;

            }
        }

		IEnumerator Play_Audio () {
			yield return new WaitForSeconds (delay);
			audio1.PlayDelayed (delay1);
			audio2.PlayDelayed (delay2);
			audio3.PlayDelayed (delay3);
			audio4.PlayDelayed (delay4);
		}

		IEnumerator Change () {
			yield return new WaitForSeconds (delay5);
			go.GetComponent<Renderer> ().material.mainTexture = hoja [0];
			yield return new WaitForSeconds (delay6);
			go.GetComponent<Renderer> ().material.mainTexture = hoja [1];
			yield return new WaitForSeconds (delay7);
			go.GetComponent<Renderer> ().material.mainTexture = hoja [2];
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
