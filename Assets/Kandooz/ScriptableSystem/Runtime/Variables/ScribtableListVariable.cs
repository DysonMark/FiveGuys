using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kandooz.ScriptableSystem
{
    public class ScribtableListVariable<T> : ScriptableObject
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
        [SerializeField] private List<T> list;
        [SerializeField] private List<T> defaults;

        public List<T> Values
        {
            get { return list; }
            set
            {
                if (value.GetType() != typeof(List<T>))
                {
                    list = value;
                }
            }
        }
        public T Value
        {
            set { list.Add(value); }
        }

        private void OnEnable()
        {
            if (clearOn == clearCondition.onPlay || clearOn == clearCondition.onEnable)
            {
                list.Clear();
            }
            if (defaultOn == clearCondition.onPlay || defaultOn == clearCondition.onEnable)
            {
                if (defaultClearFirst)
                {
                    list.Clear();
                    list = defaults;
                }
                else
                {
                    list.AddRange(defaults);
                }
            }
        }

        private void OnDisable()
        {
            if (clearOn == clearCondition.onStop || clearOn == clearCondition.onDisable)
            {
                list.Clear();
            }
            if (defaultOn == clearCondition.onStop || defaultOn == clearCondition.onDisable)
            {
                if (defaultClearFirst)
                {
                    list.Clear();
                    list = defaults;
                }
                else
                {
                    list.AddRange(defaults);
                }
            }
        }
    } 
}
