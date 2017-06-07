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
    public class DefaultTrackableEventHandler46 : MonoBehaviour,
                                                ITrackableEventHandler
    {
		
		public AudioSource audio1;
		public AudioSource audio2;
		public AudioSource audio3;
		public AudioSource audio4;

		//private float delay1 = 0.3f, delay2 = 3.5f, delay3 = 4.0f, delay4 = 3.7f;
		private float delay1 = 0.3f, delay2 = 3.8f, delay3 = 7.8f, delay4 = 11.5f;
        #region PRIVATE_MEMBER_VARIABLES
		private Control control;
        private TrackableBehaviour mTrackableBehaviour;
    
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
				control.Encontro_Target46 ();
				StartCoroutine (Play_Audio());
				control.DesaparecerTrack ();

            }
            else
            {
                OnTrackingLost();
				control.Start ();
				StopCoroutine (Play_Audio());
				StopAllCoroutines ();
				audio1.Stop ();
				audio2.Stop ();
				audio3.Stop ();
				audio4.Stop ();
				control.AparecerTrack ();
            }
        }

		IEnumerator Play_Audio () {
			yield return new WaitForSeconds (delay1);
			audio1.Play ();
			audio2.PlayDelayed (delay2);
			audio3.PlayDelayed (delay3);
			audio4.PlayDelayed (delay4);
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
