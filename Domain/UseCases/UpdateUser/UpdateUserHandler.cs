using AutoMapper;
using CleanArchtecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.UpdateUser;

public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserRequest command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(command.Id, cancellationToken);

        if (user == null) return default;

        user.Name = command.Name;
        user.Email = command.Email;

        _userRepository.Update(user);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<UpdateUserResponse>(user);
    }
}