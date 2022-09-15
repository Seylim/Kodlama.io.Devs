using AutoMapper;
using KodlamaIoDevs.Application.Features.ProgramminLanguages.Dtos;
using KodlamaIoDevs.Application.Features.ProgramminLanguages.Rules;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.ProgramminLanguages.Commands.DeleteProgrammingLanguageCommand
{
    public class DeleteProgrammingLanguageCommand : IRequest<DeletedProgrammingLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeletedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _businessRules;

            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules businessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage mappedProgrammingLanguage = await _programmingLanguageRepository.GetAsync(pl => pl.Id == request.Id);

                await _businessRules.ProgrammingLanguageShouldExistWhenRequested(mappedProgrammingLanguage);

                mappedProgrammingLanguage.IsActive = false;
                ProgrammingLanguage deletedProgrammingLanguage = await _programmingLanguageRepository.UpdateAsync(mappedProgrammingLanguage);
                DeletedProgrammingLanguageDto result = _mapper.Map<DeletedProgrammingLanguageDto>(deletedProgrammingLanguage);

                return result;
            }
        }
    }
}
