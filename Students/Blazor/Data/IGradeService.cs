using Shared.DTOs;

namespace Blazor.Data;

public interface IGradeService
{
	Task<StatisticsOverviewDto> GetCourseStatisticsAsync();
}
