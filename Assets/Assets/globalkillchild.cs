using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalkillchild : MonoBehaviour
{

  
    void Start()
    {
        
        void OnDestroy()
        {
            // This code will be executed when the GameObject is destroyed

            // Example: Check if a certain condition is met before performing an action
            if (ShouldPerformAction())
            {
                PerformAction();
            }
        }

        bool ShouldPerformAction()
        {
            // Your condition logic here
            // For example, you might check a variable, state, or other conditions
            return true; // Replace this with your condition
        }

        void PerformAction()
        {
            spaningbomb += 1;// Your action or code to execute when the condition is met
            Debug.Log("Performing action when GameObject is destroyed.");
        }
    }

}

