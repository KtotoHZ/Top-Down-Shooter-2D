using UnityEngine;

public interface IInputPlayer 
{
    event System.Action OnExitClick;
    event System.Action OnActionClick;
    event System.Action OnAlternativeActionClick;

    event System.Action OnPreviewItemClick;
    event System.Action<int> OnItemChoose;
    event System.Action OnNextItemClick;

    bool IsAttackPressed();
    bool IsAlternativeAttackClickPressed();

    Vector2 RotateVector();
    Vector2 GetAxis();
    Vector2 GetAxisRaw();
}
