using UnityEngine;


public class Born : MonoBehaviour
{

    [HideInInspector]
    public bool createPlayer = false;
    

   
    void Start()
    {
        
        Invoke("BornTank", 1f);
       
        Destroy(gameObject, 1);
    }
   

   
    private void BornTank()
    {
       
        if (createPlayer)
        {
            
            Instantiate(GameManager.Instance.PlayerGO, this.transform.position, Quaternion.identity);
        }
        else
        {
            
            int num = Random.Range(0, 2);
            
            Instantiate(GameManager.Instance.EnemyGO[num], this.transform.position, Quaternion.identity);
        }
    }
    
}