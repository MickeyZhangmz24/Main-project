using UnityEngine;
using UnityEngine.UI;
using YHBGAME.YHB_Singleton;


public class UIController : MonoBehaviour
{
    
    private Button StartBtn = null;
   

   
    void Start()
    {
        
        StartBtn = this.transform.Find("StartBtn").GetComponent<Button>();
       
        StartBtn.onClick.AddListener(GameManager.Instance.OnStartBtnClick);
    }
    
}