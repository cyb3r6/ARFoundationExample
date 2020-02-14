using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Corgan
{
    public class PlacedPrefab : MonoBehaviour
    {
        [SerializeField]
        private bool IsSelected;

        public bool Selected { get { return this.IsSelected; } set { IsSelected = value; } }

        public List<GameObject> models = new List<GameObject>();

        public void AddToModelAButton(Button modelAButton)
        {
            modelAButton.onClick.AddListener(() => ModelA());
        }
        public void AddToModelBButton(Button modelBButton)
        {
            modelBButton.onClick.AddListener(() => ModelB());
        }

        public void ModelA()
        {
            foreach (GameObject gameObject in models)
            {
                gameObject.SetActive(false);
            }
            models[0].SetActive(true);
        }
        public void ModelB()
        {
            foreach (GameObject gameObject in models)
            {
                gameObject.SetActive(false);
            }
            models[1].SetActive(true);
        }
    }
}
