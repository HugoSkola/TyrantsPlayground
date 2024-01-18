using UnityEngine;

public class ObjectDestroyed : MonoBehaviour
{
    // Event to notify when an object is destroyed
    public delegate void ObjectDestroyedHandler();
    public static event ObjectDestroyedHandler OnObjectDestroyed;

    void OnDestroy()
    {
       
        // Invoke the event when the object is destroyed
        OnObjectDestroyed?.Invoke();
    }

}