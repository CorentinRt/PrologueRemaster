using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSoundsData", menuName = "ScriptableObjects/SpawnPlayerSoundsData", order = 1)]
public class PlayerSoundsDataSO : ScriptableObject
{
    #region Fields

    [Header("Player Jump")]
    [SerializeField] private AudioClip[] _playerJumpStarts;
    [SerializeField] private AudioClip[] _playerJumpLandings;

    [Space(50)]

    [Header("Player Sword")]
    [SerializeField] private AudioClip[] _playerSwordSwings;
    [SerializeField] private AudioClip[] _playerSwordImpact;

    #endregion

    #region Properties
    public AudioClip[] PlayerJumpStarts { get => _playerJumpStarts; set => _playerJumpStarts = value; }
    public AudioClip[] PlayerJumpLandings { get => _playerJumpLandings; set => _playerJumpLandings = value; }
    public AudioClip[] PlayerSwordSwings { get => _playerSwordSwings; set => _playerSwordSwings = value; }
    public AudioClip[] PlayerSwordImpact { get => _playerSwordImpact; set => _playerSwordImpact = value; }

    #endregion
}
