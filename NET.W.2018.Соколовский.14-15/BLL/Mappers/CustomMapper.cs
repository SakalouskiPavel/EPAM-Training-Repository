using AutoMapper;
using BLL.Interface;
using BLL.Interface.Entities;
using DAL.Interface.DTO;
using DAL.Interface.Enums;

namespace BLL.Mappers
{
    public static class CustomMapper 
    {
        static CustomMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<BankAccount, BankAccountDTO>();
                cfg.CreateMap<BankAccountTypes, BankAccountTypesDTO>();
            });
        }


    }
}