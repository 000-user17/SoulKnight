using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMediator : AbstractMediator
{
    // Start is called before the first frame update
    private static GameMediator instance;
    
    public static GameMediator Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameMediator();
            }
            return instance;
        }
    }

    private GameMediator() {}

}
