using UnityEngine;

namespace YHBGAME.YHB_Tools
{
    
    public static class ResourcesTools
    {
        
        public static GameObject LoadPrefab(string prefabName, string path = null)
        {
            string prefabPath = path + prefabName;
            GameObject goPrefab = Resources.Load<GameObject>(prefabPath);

            if (goPrefab == null)
            {
                Debug.LogWarning("Prefab path+ [ " + path + prefabName + " ] Loading failed! Check whether the resource path is correct！");
                return null;
            }

            return goPrefab;
        }
        
    }
}