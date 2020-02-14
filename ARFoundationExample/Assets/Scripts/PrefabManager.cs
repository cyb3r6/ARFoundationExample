using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Example singleton to keep placed prefabs in
/// the scenes you load. 
/// </summary>

namespace Corgan
{
    public class PrefabManager : MonoBehaviour
    {
        public static PrefabManager instance;

        private List<GameObject> placedPrefabs = new List<GameObject>();

        void Awake()
        {
            if(instance != null)
            {
                Destroy(gameObject);                
            }

            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }

        public void AddPrefabs(GameObject prefab)
        {
            placedPrefabs.Add(prefab);

            foreach(GameObject g_Object in placedPrefabs)
            {
                DontDestroyOnLoad(g_Object);
            }
        }
    }
}