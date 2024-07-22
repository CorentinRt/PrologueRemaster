using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSoundsData", menuName = "ScriptableObjects/SpawnPlayerSoundsData", order = 1)]
public class PlayerSoundsDataSO : ScriptableObject
{
    [SerializeField] private AudioClip[] _playerJumpStarts;
    [SerializeField] private AudioClip[] _playerJumpLandings;

    public AudioClip[] PlayerJumpStarts { get => _playerJumpStarts; set => _playerJumpStarts = value; }
    public AudioClip[] PlayerJumpLandings { get => _playerJumpLandings; set => _playerJumpLandings = value; }
}
