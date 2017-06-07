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
    public class DefaultTrackableEventHandler33 : MonoBehaviour,
                                                ITrackableEventHandler
    {
		
		public AudioSource audio1;
		public float delay = 0.0f;
        #region PRIVATE_MEMBER_VARIABLES
		private Control control;
        private TrackableBehaviour mTrackableBehaviour;
		public GameObject jar1, jar2, jar3;
    
        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
			jar1.SetActive (false);
			jar2.SetActive (false);
			jar3.SetActive (false);
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
				control.Encontro_Target36 ();
				delay = 3.6f;
				StartCoroutine (Play_Audio());
				StartCoroutine (Jar());
				control.DesaparecerTrack ();

            }
            else
            {
                OnTrackingLost();
				control.Start ();
				StopCoroutine (Play_Audio());
				StopCoroutine (Jar());
				audio1.Stop ();
				control.AparecerTrack ();
				jar1.SetActive (false);
				jar2.SetActive (false);
				jar3.SetActive (false); 
				delay = 0.0f;
            }
        }

		IEnumerator Play_Audio () {
			yield return new WaitForSeconds (delay);
			audio1.Play ();
		}
        #endregion // PUBLIC_METHODS

		IEnumerator Jar(){
			yield return new WaitForSeconds (0);
			jar1.SetActive (true);
			jar2.SetActive (false);
			jar3.SetActive (false);
			yield return new WaitForSeconds (2.12f);
			jar1.SetActive (false);
			jar2.SetActive (true);
			jar3.SetActive (false);
			yield return new WaitForSeconds (0.9f);
			jar1.SetActive (false);
			jar2.SetActive (false);
			jar3.SetActive (true);
		}

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
