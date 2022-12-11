using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Character", menuName = "Character SSelection/Character")]

public class Character : ScriptableObject
{
    [SerializeField] private string _characterName = default;
    [SerializeField] private GameObject _characterPreviewPrefab = default;
    [SerializeField] private GameObject _characterGameplayPrefab = default;

    public string CharacterName => _characterName;
    public GameObject CharacterPreviewfab => _characterPreviewPrefab; //in scence option that people pick
    public GameObject CharacterGameplayPrefab => _characterGameplayPrefab; // what people actually play as




}
