using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrashFrenzy.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Tool", menuName = "Tools")]
    public class ToolType : ScriptableObject
    {
        [Header("Tool Info")]
        public string toolName;
        public ToolClass toolClass;
        public Sprite toolSprite;

        [Header("Tool Properties")]
        public int baseEfficiency;
        public int baseRange;
    }

    public enum ToolClass
    {
        Biodegradable,
        NonBiodegradable,
        Recyclable
    }
}