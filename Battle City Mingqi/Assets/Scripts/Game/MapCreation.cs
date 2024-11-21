using System.Collections.Generic;
using UnityEngine;


public class MapCreation : MonoBehaviour
{
    
    private List<Vector3> itemPositionList = new List<Vector3>();
    

    
    private void Awake()
    {
        InitMap();
    }
   

    private void InitMap()
    {
       
        CreateItem(GameManager.Instance.ItemGO[0], new Vector3(0, -8, 0));
        
        CreateItem(GameManager.Instance.ItemGO[1], new Vector3(-1, -8, 0));
        CreateItem(GameManager.Instance.ItemGO[1], new Vector3(1, -8, 0));
        
        for (int i = -1; i < 2; i++)
        {
            CreateItem(GameManager.Instance.ItemGO[1], new Vector3(i, -7, 0));
        }

        
       
        for (int i = -10; i < 11; i++)
        {
            CreateItem(GameManager.Instance.ItemGO[6], new Vector3(i, 9, 0));
        }
       
        for (int i = -10; i < 11; i++)
        {
            CreateItem(GameManager.Instance.ItemGO[6], new Vector3(i, -9, 0));
        }
        
        for (int i = -8; i < 9; i++)
        {
            CreateItem(GameManager.Instance.ItemGO[6], new Vector3(-11, i, 0));
        }
       
        for (int i = -8; i < 9; i++)
        {
            CreateItem(GameManager.Instance.ItemGO[6], new Vector3(11, i, 0));
        }

        
        GameObject go = Instantiate(GameManager.Instance.ItemGO[3], new Vector3(-2, -8, 0), Quaternion.identity);
        go.GetComponent<Born>().createPlayer = true;

       
        CreateItem(GameManager.Instance.ItemGO[3], new Vector3(-10, 8, 0));
        CreateItem(GameManager.Instance.ItemGO[3], new Vector3(10, 8, 0));

        
        InvokeRepeating("CreateEnemy", 5, 10);

        
        for (int i = 0; i < 60; i++)
        {
            CreateItem(GameManager.Instance.ItemGO[1], CreateRandomPosition());
        }
        
        for (int i = 0; i < 20; i++)
        {
            CreateItem(GameManager.Instance.ItemGO[2], CreateRandomPosition());
        }
       
        for (int i = 0; i < 20; i++)
        {
            CreateItem(GameManager.Instance.ItemGO[4], CreateRandomPosition());
        }
        
        for (int i = 0; i < 20; i++)
        {
            CreateItem(GameManager.Instance.ItemGO[5], CreateRandomPosition());
        }
    }

   
    private void CreateItem(GameObject createCameObject, Vector3 createPosition)
    {
        
        GameObject itemGo = Instantiate(createCameObject, createPosition, Quaternion.identity);
       
        itemGo.transform.SetParent(this.gameObject.transform);
        
        itemPositionList.Add(createPosition);
    }
   

    
    private Vector3 CreateRandomPosition()
    {
        
        while (true)
        {
           
            Vector3 createPosition = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0);

           
            if (HasThePosition(createPosition) == false)
            {
               
                return createPosition;
            }
        }
    }
   

   
    private bool HasThePosition(Vector3 createPos)
    {
      
        for (int i = 0; i < itemPositionList.Count; i++)
        {
            
            if (createPos == itemPositionList[i])
            {
                return true;
            }
        }

        
        return false;
    }
    

    
    private void CreateEnemy()
    {
        
        int num = Random.Range(0, 3);
        
        Vector3 EnemyPos = new Vector3();
       
        if (num == 0)
        {
           
            EnemyPos = new Vector3(-10, 8, 0);
        }
        else if (num == 1)
        {
            EnemyPos = new Vector3(0, 8, 0);
        }
        else
        {
            EnemyPos = new Vector3(10, 8, 0);
        }

       
        CreateItem(GameManager.Instance.ItemGO[3], EnemyPos);
    }
    
}