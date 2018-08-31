
public class ViewChangeRequestEvent : CodeControl.Message
{
    public View view;

    public ViewChangeRequestEvent(View view)
    {
        this.view = view;
    }
}
