﻿using Ardalis.ApiEndpoints;
using GameMissions.Core.GameAggregate;
using GameMissions.Core.GameAggregate.Specifications;
using GameMissions.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameMissions.Web.Endpoints.MissionEndpoints;

public class List : EndpointBaseAsync.WithoutRequest.WithActionResult<MissionListResponse>
{
  private readonly IReadRepository<Mission> _missionRepository;

  public List(IReadRepository<Mission> missionRepository)
  {
    _missionRepository = missionRepository;
  }

  public override async Task<ActionResult<MissionListResponse>> HandleAsync(CancellationToken cancellationToken = new())
  {
    var spec = new AllMissionsSpec();
    var missions = await _missionRepository.ListAsync(spec);
    if (!missions.Any())
    {
      return NotFound();
    }

    var response = new MissionListResponse
    {
      Missions = missions.Select(m => new MissionRecord(m.Id, m.GameId, (int)m.MissionType, m.Order, m.Title, 
        m.CompletionLevel, m.Reward, m.Description)).ToList()
    };

    return Ok(response);
  }
}
