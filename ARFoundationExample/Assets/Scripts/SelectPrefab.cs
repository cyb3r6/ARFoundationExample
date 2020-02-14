using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corgan
{
    public class SelectPrefab : MonoBehaviour
    {
        public Camera arCamera;

        private PlacedPrefab placedPrefab;

        private Color selectedColor = Color.red;
        private Color deselectedColor = Color.grey;
    
        
        void Update()
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                Vector2 touchPosition = touch.position;
                if(touch.phase == TouchPhase.Began)
                {
                    Ray ray = arCamera.ScreenPointToRay(touch.position);
                    RaycastHit hitObject;
                    if(Physics.Raycast(ray, out hitObject))
                    {
                        PlacedPrefab placementPrefab = hitObject.transform.GetComponent<PlacedPrefab>();

                        if (placementPrefab)
                        {
                            SelectedObject(placementPrefab);
                        }
                    }
                }
            }
        }

        void SelectedObject(PlacedPrefab selectedPrefab)
        {
            selectedPrefab.Selected = true;
        }
    }
}