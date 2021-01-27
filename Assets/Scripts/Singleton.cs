using UnityEngine;
using System.Collections;
 
/// <summary>
/// Inherit from this base class to create a singleton.
/// e.g. public class MyClassName : Singleton<MyClassName> {}
/// </summary>



public  class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance{
        get
        {
            if(instance==null)
            {
                instance = FindObjectOfType<T>();
            }

            return instance;
        }
    }
}