using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        DispatchMainViewRequestEvent();
    }

    private void DispatchMainViewRequestEvent()
    {
        CodeControl.Message.Send(new ViewChangeRequestEvent(View.Main));
    }
}
