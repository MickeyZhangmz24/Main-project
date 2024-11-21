using UnityEngine;
using YHBGAME.YHB_Tools;

namespace YHBGAME.UIFrameWork_1
{
    
    public abstract class UIBase : MonoBehaviour
    {
       
        [HideInInspector]
        public UIPanelType CurrentUIPanelType = UIPanelType.None;
       

      
        private CanvasGroup canvasGroup = null;

        protected CanvasGroup CanvasGroup
        {
            get
            {
                canvasGroup = this.GetComponent<CanvasGroup>();

                if (canvasGroup == null)
                {
                    canvasGroup = this.gameObject.AddComponent<CanvasGroup>();
                }

                return canvasGroup;
            }
        }

      
        
       

      
        public abstract void OnEnter();
       
        public abstract void OnPause();
        
        public abstract void OnResume();
       
        public abstract void OnExit();
      
    }
}