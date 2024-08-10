using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedScriptableVariable<T> : ScriptableObject
{
    private enum clearCondition
    {
        noClear,
        onPlay,
        onEnable,
        onStop,
        onDisable
    }
    [Header("Config")]
    [SerializeField] private clearCondition clearOn = clearCondition.noClear;
    [SerializeField] private clearCondition defaultOn = clearCondition.noClear;
    [SerializeField] private bool defaultClearFirst = true;

    [Header("Value")]
    [SerializeField] private T valuE;
    [SerializeField] private T defaults;

    public T Value
    {
        get { return  valuE; }
        set { valuE = value; }
    }

    private void OnEnable()
    {
        if (clearOn == clearCondition.onPlay || clearOn == clearCondition.onEnable)
        {
            valuE = default;
        }
        if (defaultOn == clearCondition.onPlay || defaultOn == clearCondition.onEnable)
        {
            if (defaultClearFirst)
            {
                valuE = defaults;
            }
            else
            {
                defaults = valuE;
            }
        }
    }

    private void OnDisable()
    {
        if (clearOn == clearCondition.onStop || clearOn == clearCondition.onDisable)
        {
            valuE = default;
        }
        if (defaultOn == clearCondition.onStop || defaultOn == clearCondition.onDisable)
        {
            if (defaultClearFirst)
            {
                valuE = defaults;
            }
            else
            {
                defaults = valuE;
            }
        }
    }
}
