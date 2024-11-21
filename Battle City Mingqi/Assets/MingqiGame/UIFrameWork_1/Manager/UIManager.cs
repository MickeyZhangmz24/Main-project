using System.Collections.Generic;
using UnityEngine;
using YHBGAME.YHB_Tools;

namespace YHBGAME.UIFrameWork_1
{
   
    public class UIManager : MonoBehaviour
    {
       
        private static UIManager instance = null;

        public static UIManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UIManager();
                }

                return instance;
            }
        }
        
       
        private static Dictionary<UIPanelType, UIBase> uiPanelDic = new Dictionary<UIPanelType, UIBase>();
        

       
        public UIBase GetUIPanel(UIPanelType panelType)
        {
            UIBase uiPanel = null;

            
            if (uiPanelDic.TryGetValue(panelType, out uiPanel))
            {
                Debug.LogWarning("get a UIBase!");
            }
            else
            {
                Debug.LogWarning("getUIBase fail，create UIBase child object!!!");
            }

            return uiPanel;
        }
        

        
        private UIBase CreateUIPanel(UIPanelType panelType)
        {
            UIBase uiPanel = GetUIPanel(panelType);

          
            if (uiPanel != null)
            {
                Debug.LogWarning("uiPanelDic There are corresponding ones in the panel dictionary" + panelType.ToString() + "panel object！");
            }
            else
            {
                GameObject uiPanelGO = InstantiateTools.CreateUGUIPanel(panelType, PathTools.UIPanel, true);
                uiPanel = uiPanelGO.GetComponent<UIBase>();

                if (uiPanel == null)
                {
                    Debug.LogError("The panel is instantiated successfully according to the UI panel path, but the instantiated panel does not inherit from UIBase");
                    return null;
                }

               
                uiPanel.CurrentUIPanelType = panelType;
                uiPanel.OnEnter();
                uiPanelDic.Add(panelType, uiPanel);
            }

            return uiPanel;
        }
       

        

       
        public void OpenUIPanel(UIPanelType panelType, bool isPauseAll = false, params UIBase[] pausePanel)
        {
            
            if (isPauseAll)
            {
               
                foreach (UIPanelType uiType in uiPanelDic.Keys)
                {
                   
                    if (uiType != panelType)
                    {
                        
                        CreateUIPanel(uiType).OnPause();
                    }
                }
            }

           
           
            if (pausePanel.Length > 0)
            {
                for (int i = 0; i < pausePanel.Length; i++)
                {
                    foreach (UIBase uiBase in uiPanelDic.Values)
                    {
                        
                        if (uiBase.CurrentUIPanelType == pausePanel[i].CurrentUIPanelType)
                        {
                            pausePanel[i].OnPause();
                        }
                    }
                }
            }

            
            CreateUIPanel(panelType).OnResume();
        }
        

      
        
        public void ExitOneUIPanel(UIPanelType uiPanelType)
        {
            
            UIBase uiPanel = CreateUIPanel(uiPanelType);
            uiPanel.OnExit();
            DestroyImmediate(uiPanel.gameObject);
            uiPanelDic.Remove(uiPanelType);
        }
       

       
        public void ExitAllUIPanel()
        {
            foreach (UIBase uiBase in uiPanelDic.Values)
            {
                uiBase.OnExit();
                DestroyImmediate(uiBase.gameObject);
            }

            uiPanelDic.Clear();
        }
        

       
    }
}