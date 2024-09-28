using Cinemachine;
using UnityEngine;

public enum CameraType
{
    StaticCamera,
    SelectCamera,
    FollowCamera,
}
public class CameraSystem : AbstractSystem
{
    private CinemachineVirtualCamera StaticCamera;
    private CinemachineVirtualCamera SelectCamera;
    private CinemachineVirtualCamera FollowCamera;
    private GameObject cameras;
    public CameraSystem()
    {

    }

    protected override void OnInit()
    {
        base.OnInit();
        cameras = GameObject.Find("Cameras");
        StaticCamera = UnityTool.Instance.GetComponentFromChildren<CinemachineVirtualCamera>(cameras, "StaticCamera");
        SelectCamera = UnityTool.Instance.GetComponentFromChildren<CinemachineVirtualCamera>(cameras, "SelectCamera");
        FollowCamera = UnityTool.Instance.GetComponentFromChildren<CinemachineVirtualCamera>(cameras, "FollowCamera");
    }

    public void SetSelectTarget(Transform t)
    {
        SelectCamera.Follow = t;
    }

    public void SetFollowTarget(Transform t)
    {
        FollowCamera.Follow = t;
    }

    public void ChangeCamera(CameraType type)
    {
        StaticCamera.gameObject.SetActive(false);
        SelectCamera.gameObject.SetActive(false);
        FollowCamera.gameObject.SetActive(false);

        switch(type)
        {
            case CameraType.StaticCamera:
                StaticCamera.gameObject.SetActive(true);
                break;
            case CameraType.SelectCamera:
                SelectCamera.gameObject.SetActive(true);
                break;
            case CameraType.FollowCamera:
                FollowCamera.gameObject.SetActive(true);
                break;
        }
    }
}
