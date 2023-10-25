using AutoMapper;
using LicenceShop.Application.Common.Dto;
using LicenceShop.Application.Common.Dto.Category;
using LicenceShop.Application.Extensions.Category;
using MediatR;
using MongoDB.Entities;

namespace LicenceShop.Application.Category.Queries;

public record GetPageableCategoryQuery(int PageNumber, int PageSize, string? Search) : IRequest<CategoryPageableDto>;

public class GetPageableCategoryQueryHandler : IRequestHandler<GetPageableCategoryQuery, CategoryPageableDto>
{

    private readonly IMapper _mapper;

    public GetPageableCategoryQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<CategoryPageableDto> Handle(GetPageableCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await DB.PagedSearch<Domain.Entities.Category>()
            .Sort(b => b.Name, MongoDB.Entities.Order.Ascending)
            .ApplyFilters(request)
            .PageSize(request.PageSize)
            .PageNumber(request.PageNumber)
            .ExecuteAsync(cancellationToken);
        return _mapper.Map<CategoryPageableDto>(category.Results).AddPagination(new PaginationDto(category.TotalCount, category.PageCount));
    }
}