using System;
using System.Collections.Generic;
using UnityEngine;

public class SetManager {

    public static SetManager m_Inst;
    public List<Set> Sets = new List<Set>();

    public static SetManager Inst
    {
        get
        {
            if (m_Inst == null)
                m_Inst = new SetManager();
            return m_Inst;
        }
    }


    // Open a set base on type
    public static T OpenSet<T>(Action<T> Init = null ) where T : Set
    {
        string SetName = typeof(T).Name;

        // If set is already in stack and is inactive
        if (Inst.Sets.Count > 0)
        {
            foreach (Set set in Inst.Sets)
            {
                if (set.name == SetName && set != null)
                {
                    ToggleSet(set);
                    return set.GetComponent<T>();
                }
            }
        }


        // create set and add to stack
        GameObject SetGO = ResourcesManager.Create("Sets/" + SetName);
        SetGO.name = SetName;
        if (SetGO != null)
        {
            T CastedObject = SetGO.GetComponent<T>();

            if (CastedObject == null)
            {
                Debug.LogWarning(SetName + " didn't have a Set component attached, adding it now...");
                CastedObject = SetGO.AddComponent<T>();
            }

            Inst.Sets.Add(CastedObject);
            return CastedObject;
        }
        return null;
    }


    // Set is disabling or can change to destroy 
    public static void ToggleSet(Set set)
    {
        var inst = Inst;
        if (!inst.Sets.Contains(set))
        {
            Debug.Log("Tried to close a set that wasn't on the stack");
            return;
        }
        bool isActive = set.gameObject.activeInHierarchy;
        set.gameObject.SetActive(!isActive);
    }
}
