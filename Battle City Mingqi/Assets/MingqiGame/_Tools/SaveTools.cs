using UnityEngine;

namespace YHBGAME.YHB_Tools
{
   
    public class SaveTools : MonoBehaviour
    {
       
        public static float LocalFloatData(float currentData, string dataName = "YHBGAME", bool isMax = true)
        {
            
            float data = PlayerPrefs.GetFloat(dataName, 0);

            if (isMax)
            {
                
                if (currentData > data)
                {
                   
                    PlayerPrefs.SetFloat(dataName, currentData);
                }
            }
            else
            {
               
                if (data == 0)
                {
                   
                    PlayerPrefs.SetFloat(dataName, currentData);
                }
                else
                {
                   
                    if (currentData < data)
                    {
                        
                        PlayerPrefs.SetFloat(dataName, currentData);
                    }
                }
            }

           
            return PlayerPrefs.GetFloat(dataName);
        }
       
    }
}