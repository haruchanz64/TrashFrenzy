using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrashFrenzy.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Trash", menuName = "Trash")]
    public class TrashType : ScriptableObject
    {
        [Header("Trash Info")]
        public string trashName;
        public TrashVariant trashVariant;

        [Header("Trash Object")]
        public GameObject trashPrefab;
    }

    public enum TrashVariant
    {
        Organic, 
        Plastic, 
        Chemical
    }
}