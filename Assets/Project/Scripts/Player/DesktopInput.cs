using System;
using UnityEngine;

public class DesktopInput : MonoBehaviour, IInputPlayer
{
    private Camera _camera;

    public event Action OnExitClick;

    public event Action OnActionClick;
    public event Action OnAlternativeActionClick;

    public event Action OnPreviewItemClick;
    public event Action OnNextItemClick;
    public event Action<int> OnItemChoose;


    private void Awake() => _camera = Camera.main;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) OnExitClick?.Invoke();

        if (Input.GetMouseButtonDown(0)) OnActionClick?.Invoke();
        if (Input.GetMouseButtonDown(1)) OnAlternativeActionClick?.Invoke();

        if (Input.mouseScrollDelta.y <= -0.1f) OnPreviewItemClick?.Invoke();
        if (Input.mouseScrollDelta.y >= 0.1f) OnNextItemClick?.Invoke();

        for (int i = 0; i <= 8; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i)) OnItemChoose?.Invoke(i);          
        }
    }
    public Vector2 GetAxis()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        return new Vector2(x, y);
    }

    public Vector2 GetAxisRaw()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        return new Vector2(x, y);
    }

    public bool IsAttackPressed()
    {
        if (Input.GetMouseButton(0)) return true;
        else return false;
    }

    public bool IsAlternativeAttackClickPressed()
    {
        if(Input.GetMouseButton(1)) return true;
        else return false;
    }

    public Vector2 RotateVector()
    {
        return _camera.ScreenToWorldPoint(Input.mousePosition);
    }
}
