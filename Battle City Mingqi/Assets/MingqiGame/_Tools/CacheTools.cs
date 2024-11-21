using UnityEngine;

namespace YHBGAME.YHB_Tools
{
   
    public static class CacheTools
    {
        

       
        private static Transform canvas = null;

        public static Transform Canvas
        {
            get
            {
                if (canvas == null)
                {
                    canvas = GameObject.Find("Canvas").transform;

                    if (canvas == null)
                    {
                        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;

                        if (canvas == null)
                        {
                            Debug.LogWarning("Please set the name or Tag of the UGUI Canvas game object to Canvas！！！");
                            return null;
                        }
                    }
                }

                return canvas;
            }
        }
      

        
        private static Transform player = null;

        public static Transform Player
        {
            get
            {
                if (player == null)
                {
                    player = GameObject.Find("Player").transform;

                    if (player == null)
                    {
                        player = GameObject.FindGameObjectWithTag("Player").transform;

                        if (player == null)
                        {
                            Debug.LogWarning("Please set the name or Tag of the player Player game object to Player！！！");
                            return null;
                        }
                    }
                }

                return player;
            }
        }
        

        
    }
}