namespace LicenceShop.Application.Common.Dto.Category;

public record UpdateCategoryDto(string CategoryId, string? Name, bool? Active);