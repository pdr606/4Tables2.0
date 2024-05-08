using _4Tables.Base;
using _4Tables2._0.Domain.Base.Common;
using _4Tables2._0.Domain.Base.Result;
using _4Tables2._0.Domain.SettingsContext.Settings.DTO;
using _4Tables2._0.Domain.SettingsContext.Settings.Interfaces.Services;
using _4Tables2._0.Domain.SettingsContext.Table.DTO;
using Microsoft.AspNetCore.Mvc;

namespace _4Tables.ControllerSettings.Settings
{
    [Route("api/[controller]")]
    public class SettingsController : BaseController
    {

        private readonly ISettingsService _settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        [HttpPost("Tables/{totalTables}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result))]
        public async Task<ActionResult> AddTables([FromRoute] short totalTables)
        {
            var result = await _settingsService.AddSettingsAsync(totalTables);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SettingsDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        public async Task<ActionResult> FindSettings()
        {
            var result = await _settingsService.GetSettings();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("Tables")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TableResultDTO))]
        public async Task<ActionResult> FindTables()
        {
            var result = await _settingsService.GetAllTablesAsyncNoTracking();
            return StatusCode(result.StatusCode, result);
        }
    }
}
