using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenuAttribute(fileName = "New Warrior Data", menuName = "CharacterData/Warrior")]
public class WarriorData : CharacterData
{
    public WarriorDmgType warriorDmg;
    public WarriorWpnType warriorWpn;
}
