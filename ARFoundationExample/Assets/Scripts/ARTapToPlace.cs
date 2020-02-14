using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

namespace Corgan
{
    public class ARTapToPlace : MonoBehaviour
    {
        public GameObject prefab;
        public Button modelAButton;
        public Button modelBButton;
        private GameObject spawnedObject;       // to hold a reference to the placed object

        static List<ARRaycastHit> hits = new List<ARRaycastHit>();

        private ARRaycastManager raycastManager;
        
        void Awake()
        {
            raycastManager = GetComponent<ARRaycastManager>();
        }

        
        void Update()
        {
            // need to know if we touched the screen and where
            if(Input.touchCount > 0)
            {
                Vector3 touchPosition = Input.GetTouch(0).position;         // (x,y)
                if(raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
                {
                    var hitPose = hits[0].pose;

                    spawnedObject = Instantiate(prefab, hitPose.position, hitPose.rotation);

                    // need to assign button onClick functions
                    PlacedPrefab placedPrefab = spawnedObject.GetComponent<PlacedPrefab>();
                    placedPrefab.AddToModelAButton(modelAButton);
                    placedPrefab.AddToModelBButton(modelBButton);

                    // put our spawnedObject into our prefab manager list
                    PrefabManager.instance.AddPrefabs(spawnedObject);
                }
            }
        }
    }
}

