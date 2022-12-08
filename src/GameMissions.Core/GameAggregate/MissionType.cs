using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Players get [Reward] amount as gift of completing a mission based on [MissionType], [CompletionLevel] and [Order] of completion
/// 
/// </summary>
public enum MissionType
{
  /// <summary>
  /// Install another game or app and get a reward
  /// </summary>
  Install = 1,
  /// <summary>
  /// 
  /// </summary>
  GotoLevel = 2,
  /// <summary>
  /// Invite a friend to play this game 
  /// Get all [Referral]s of current game by order
  /// </summary>
  Referral = 3
}
