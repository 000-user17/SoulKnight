using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractModel
{
    public AbstractModel()
    {
        OnInit();
    }
    
    protected virtual void OnInit()
    {

    }
}
