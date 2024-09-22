using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiddleScene;

public class MiddleSceneGameLoop : MonoBehaviour
{
    public Facade facade;
    private void Start()
    {
        facade = new Facade();
    }
    private void Update()
    {
        facade.GameUpdate();
    }

}
