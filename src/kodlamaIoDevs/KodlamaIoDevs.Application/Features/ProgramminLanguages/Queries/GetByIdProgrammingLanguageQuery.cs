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

namespace KodlamaIoDevs.Application.Features.ProgramminLanguages.Queries
{
    public class GetByIdProgrammingLanguageQuery : IRequest<GetByIdProgrammingLanguageDto>
    {
        public int Id { get; set; }

        public class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery, GetByIdProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _businessRules;

            public GetByIdProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules businessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<GetByIdProgrammingLanguageDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(pl => pl.Id == request.Id);

                await _businessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguage);

                GetByIdProgrammingLanguageDto result = _mapper.Map<GetByIdProgrammingLanguageDto>(programmingLanguage);

                return result;
            }
        }
    }
}
