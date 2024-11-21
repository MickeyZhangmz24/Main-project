using UnityEngine;


namespace YHBGAME.YHB_Singleton
{
    
    public class SingletonBase<Type> : MonoBehaviour where Type : MonoBehaviour
    {
        
        private static Type _ins = null;

        public static Type Instance
        {
            get
            {
                
                if (_ins == null)
                {
                    
                    _ins = GameObject.FindObjectOfType(typeof(Type)) as Type;

                    
                    if (_ins == null)
                    {
                        
                        GameObject go = new GameObject("(YHBGAME_)" + typeof(Type) + "(_Singleton)");
                        
                        _ins = go.AddComponent<Type>();

                        
                        DontDestroyOnLoad(go);

                        Debug.LogWarning("find object！");

                        
                        return _ins;
                    }
                }

                Debug.LogWarning("find object！");
               
                return _ins;
            }
        }
       
    }
}









