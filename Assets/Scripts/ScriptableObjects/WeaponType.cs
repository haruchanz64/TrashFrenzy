using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponType : ScriptableObject
{
    [Header("Weapon Info")]
    public string weaponName;
    public WeaponClass weaponClass;
    public Sprite weaponSprite;


    [Header("Weapon Attributes")]
    public float weaponFireRate;
    public int weaponDamage;
    public float weaponRange;

    [Header("Weapon Object")]
    public GameObject weaponPrefab;
}

public enum WeaponClass
{
    Plastic,
    Organic,
    Industrial
}
