using AutoMapper;
using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.ProgramminLanguages.Commands.CreateProgrammingLanguage;
using KodlamaIoDevs.Application.Features.ProgramminLanguages.Commands.DeleteProgrammingLanguageCommand;
using KodlamaIoDevs.Application.Features.ProgramminLanguages.Commands.UpdateProgrammingLanguageCommand;
using KodlamaIoDevs.Application.Features.ProgramminLanguages.Dtos;
using KodlamaIoDevs.Application.Features.ProgramminLanguages.Models;
using KodlamaIoDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.ProgramminLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguage, CreatedProgramminLangueageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateProgramminLanguageCommand>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeletedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, GetByIdProgrammingLanguageDto>().ReverseMap();
        }
    }
}
