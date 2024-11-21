using System.Collections.Generic;
using UnityEngine;

namespace YHBGAME.YHB_Tools
{
    
    public class YHBPool
    {
       
        private static Dictionary<string, List<GameObject>> pool = new Dictionary<string, List<GameObject>>();
        private static GameObject poolGameObject = null;
        
        
        public static GameObject ShowGameObjectToName(string prefabName, string path = null, Transform parent = null)
        {
            
            string keyName = prefabName + "(Clone)";

            
            if (pool.ContainsKey(keyName) && pool[keyName].Count > 0)
            {
                
                List<GameObject> list = pool[keyName];

               
                poolGameObject = list[0];

                
                list.RemoveAt(0);

               
                poolGameObject.SetActive(true);
            }
            else
            {
               
                poolGameObject = GameObject.Instantiate(ResourcesTools.LoadPrefab(prefabName, path));

                
                if (parent != null)
                {
                    poolGameObject.transform.SetParent(parent);
                }
            }

            return poolGameObject;
        }
       
        public static void HideGameObject(GameObject currentGameObject)
        {
            if (currentGameObject == null)
            {
                Debug.LogWarning("Game empty！");
                return;
            }

            
            string keyName = currentGameObject.name;

            
            if (pool.ContainsKey(keyName))
            {
               
                List<GameObject> list = pool[keyName];
                
                list.Add(currentGameObject);
            }
            else
            {
                
                pool[keyName] = new List<GameObject>() {};
                
                pool[keyName].Add(currentGameObject);
            }

           
            currentGameObject.SetActive(false);
        }
       
    }
}