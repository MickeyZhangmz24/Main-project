using UnityEngine;

namespace YHBGAME.YHB_Tools
{
  
    public static class InstantiateTools
    {
       
        public static GameObject CreateUGUIPanel(UIPanelType uiType, string path, Transform parent, bool isMax)
        {
            GameObject prefabGO = ResourcesTools.LoadPrefab(uiType.ToString(), path);

            if (prefabGO == null)
            {
                Debug.LogWarning("Loading failed prefabGO is empty!");
                return null;
            }

            GameObject uiPanelGo = GameObject.Instantiate(prefabGO);

            if (uiPanelGo == null)
            {
                Debug.LogWarning("UIPanel instantiation failed, please check EnumUIType and Prefab paths");
                return null;
            }

            uiPanelGo.name = uiType.ToString();
            RectTransform uiPanelRectTransform = uiPanelGo.GetComponent<RectTransform>();

            if (parent != null)
            {
                uiPanelRectTransform.SetParent(parent);
            }
            else
            {
                uiPanelRectTransform.SetParent(CacheTools.Canvas);
            }

            uiPanelRectTransform.localPosition = Vector3.zero;
            uiPanelRectTransform.localScale = Vector3.one;

            if (isMax)
            {
                uiPanelRectTransform.anchorMax = Vector2.one;
                uiPanelRectTransform.anchorMin = Vector2.zero;
                uiPanelRectTransform.offsetMax = Vector2.zero;
                uiPanelRectTransform.offsetMin = Vector2.zero;
            }

            return uiPanelGo;
        }
       

       
        public static GameObject CreateUGUIPanel(UIPanelType uiType, Transform parent, bool isMax)
        {
            return CreateUGUIPanel(uiType, string.Empty, parent, isMax);
        }
       
        public static GameObject CreateUGUIPanel(UIPanelType uiType, bool isMax)
        {
            return CreateUGUIPanel(uiType, string.Empty, null, isMax);
        }
        
        public static GameObject CreateUGUIPanel(UIPanelType uiType, Transform parent)
        {
            return CreateUGUIPanel(uiType, string.Empty, parent, false);
        }
        
        public static GameObject CreateUGUIPanel(UIPanelType uiType)
        {
            return CreateUGUIPanel(uiType, string.Empty, null, false);
        }
       
        public static GameObject CreateUGUIPanel(UIPanelType uiType, string path, bool isMax)
        {
            return CreateUGUIPanel(uiType, path + "/", null, isMax);
        }
        
        public static GameObject CreateUGUIPanel(UIPanelType uiType, string path, Transform parent)
        {
            return CreateUGUIPanel(uiType, path + "/", parent, false);
        }
        
        public static GameObject CreateUGUIPanel(UIPanelType uiType, string path)
        {
            return CreateUGUIPanel(uiType, path + "/", null, false);
        }
       
        public static RectTransform LoadCreateUGUIGameObject(string name, string path, Transform parent)
        {
            GameObject prefabGO = ResourcesTools.LoadPrefab(name, path + "/");

            if (prefabGO == null)
            {
                Debug.LogWarning("Loading failed prefabGO is empty!");
                return null;
            }

            GameObject uiGo = GameObject.Instantiate(prefabGO);

            if (uiGo == null)
            {
                Debug.LogWarning("UIGameObject instantiation failed, please check name and path");
                return null;
            }

            uiGo.name = name;
            RectTransform uiPanelRectTransform = uiGo.GetComponent<RectTransform>();

            if (uiPanelRectTransform == null)
            {
                Debug.LogWarning("UIGameObject instantiation failed, please check!");
                return null;
            }

            if (parent != null)
            {
                uiPanelRectTransform.SetParent(parent);
            }
            else
            {
                uiPanelRectTransform.SetParent(CacheTools.Canvas);
            }

            uiPanelRectTransform.localPosition = Vector3.zero;
            uiPanelRectTransform.localScale = Vector3.one;

            return uiPanelRectTransform;
        }
        

        
        public static RectTransform LoadCreateUGUIGameObject(string name, string path)
        {
            return LoadCreateUGUIGameObject(name, path + "/", null);
        }
       

        
        public static RectTransform LoadCreateUGUIGameObject(string name, Transform parent)
        {
            return LoadCreateUGUIGameObject(name, string.Empty, parent);
        }
        
        public static RectTransform LoadCreateUGUIGameObject(string name)
        {
            return LoadCreateUGUIGameObject(name, string.Empty, null);
        }
        
        public static GameObject CreateUGUIGameObject(GameObject prefabGO, Transform parent = null)
        {
            GameObject uiGo = GameObject.Instantiate(prefabGO);
            RectTransform uiGoRectTransform = uiGo.GetComponent<RectTransform>();

            if (parent != null)
            {
                uiGoRectTransform.SetParent(parent);
            }
            else
            {
                uiGoRectTransform.SetParent(CacheTools.Canvas);
            }

            uiGoRectTransform.localScale = Vector3.one;
            uiGoRectTransform.localPosition = Vector3.zero;

            return uiGo;
        }
       

       
        
    }
}