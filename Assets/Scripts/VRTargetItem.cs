using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class VRTargetItem : MonoBehaviour
{
    //events invoked when gaze pointer enters or exits object
    public UnityEvent m_gazeEnterEvent;
    public UnityEvent m_gazeExitEvent;
    //events that are invoked once we select this target item
    public UnityEvent m_completionEvent;

    private EventTrigger m_trigger;
    private ISubmitHandler m_submit;

    private void Awake()
    {
        m_trigger = GetComponent<EventTrigger>();
        m_submit = GetComponent<ISubmitHandler>();
    }

    public void GazeEnter(PointerEventData pointer)
    {
        // When the user looks at the rendering of the scene, show the radial.
        if(m_trigger)
            m_trigger.OnPointerEnter(pointer);
        else
            m_gazeEnterEvent.Invoke();
    }

    public void GazeExit(PointerEventData pointer)
    {
        // When the user looks away from the rendering of the scene, hide the radial.
        if (m_trigger)
            m_trigger.OnPointerExit(pointer);
        else
            m_gazeExitEvent.Invoke();
    }

    public void GazeComplete(PointerEventData pointer)
    {
        //invoke events that are set up in the inspector
        if (m_submit != null)
            m_submit.OnSubmit(pointer);
        else
            m_completionEvent.Invoke();
    }
}