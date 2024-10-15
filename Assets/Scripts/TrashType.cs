using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace TrashFrenzy.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Trash", menuName = "Trash")]
    public class TrashType : ScriptableObject
    {
        [Header("Trash Info")]
        public string trashName;
        public TrashVariant trashVariant;
        public Sprite trashSprite;
        public ToolClass requiredTool;
    }

    public enum TrashVariant
    {
        Biodegradable,
        Non_Biodegradable,
        Recyclable
    }
}