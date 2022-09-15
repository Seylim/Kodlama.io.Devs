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

namespace KodlamaIoDevs.Application.Features.ProgramminLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgramminLanguageCommand : IRequest<CreatedProgramminLangueageDto>
    {
        public string Name { get; set; }

        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgramminLanguageCommand, CreatedProgramminLangueageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _businessRules;

            public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules businessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CreatedProgramminLangueageDto> Handle(CreateProgramminLanguageCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.ProgrammingLanguageNameCanNotBeDublicatedWhenInserted(request.Name);

                ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                mappedProgrammingLanguage.IsActive = true;
                ProgrammingLanguage createdProgrammingLanguage = await _programmingLanguageRepository.AddAsync(mappedProgrammingLanguage);
                CreatedProgramminLangueageDto createdProgrammingLanguageDto = _mapper.Map<CreatedProgramminLangueageDto>(createdProgrammingLanguage);

                return createdProgrammingLanguageDto;
            }
        }
    }
}
