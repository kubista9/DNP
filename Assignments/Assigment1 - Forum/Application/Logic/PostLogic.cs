using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao _postDao;
    private readonly IUserDao _userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        _postDao = postDao;
        _userDao = userDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await _userDao.GetByIdAsync(dto.OwnerId);
        if (user == null)
        {
            throw new Exception($"User with id: {dto.OwnerId} was not found.");
        }

        Post post = new Post(user, dto.Title, dto.PostBody);

        ValidatePost(post);

        Post created = await _postDao.CreateAsync(post);
        created.Owner.Password = null;
        return created;
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        return _postDao.GetAsync(searchParameters);
    }

    public async Task UpdateAsync(PostUpdateDto dto)
    {
        Post? existing = await _postDao.GetByIdAsync(dto.Id);

        if (existing == null)
        {
            throw new Exception($"Post with ID {dto.Id} not found!");
        }

        User? user = null;
        if (dto.OwnerId != null)
        {
            user = await _userDao.GetByIdAsync((int)dto.OwnerId);
            if (user == null)
            {
                throw new Exception($"User with id {dto.OwnerId} was not found.");
            }
        }

        string titleToUse = dto.Title ?? existing.Title;
        string bodyToUse = dto.Body ?? existing.Body;

        Post updated = new(existing.Owner, titleToUse, bodyToUse)
        {
            Id = existing.Id
        };

        ValidatePost(updated);

        await _postDao.UpdateAsync(updated);
    }

    public async Task<PostBasicDto> GetByIdAsync(int id)
    {
        Post? post = await _postDao.GetByIdAsync(id);
        if (post == null)
        {
            throw new Exception($"Post with id {id} not found");
        }

        return new PostBasicDto(post.Id, post.Owner.Username, post.Title, post.Body);
    }

    private void ValidatePost(Post post)
    {
        //validation stuff for each private instance variable of post
    }
}
