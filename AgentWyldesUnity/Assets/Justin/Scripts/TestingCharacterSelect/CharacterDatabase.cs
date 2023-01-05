using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{

    public CharacterTest[] characterTests;

    public int characterCount
    {
        get

        {
            return characterTests.Length;
        }
    }
    public CharacterTest GetCharacterTest(int index)
    {
        return characterTests[index];

    }


}
