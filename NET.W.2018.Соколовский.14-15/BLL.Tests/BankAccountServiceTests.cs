using System;
using AutoMapper;
using BLL.Interface;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.DTO;
using DAL.Interface.Enums;
using DAL.Interface.Interfaces;
using Moq;
using NUnit.Framework;

namespace BLL.Tests
{
    [TestFixture]
    public class BankAccountServiceTests
    {
        private Mock<IBankAccountsRepository> _storage;

        private IBankAccountService _service;

        private BankAccount _testAccount;

        [SetUp]
        public void Init()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<BankAccount, BankAccountDTO>().ReverseMap();
                cfg.CreateMap<BankAccountTypes, BankAccountTypesDTO>().ReverseMap();
            });
            this._storage = new Mock<IBankAccountsRepository>();
            this._testAccount = new BankAccount(1, "FirstName", "Surname", 40, 0, false, BankAccountTypes.Standart, 1);
            this._storage.Setup(x => x.Add(It.IsAny<BankAccountDTO>())).Returns(Mapper.Map<BankAccountDTO>(this._testAccount));
            this._storage.Setup(x => x.Get(It.Is<int>(i => i == this._testAccount.AccountId))).Returns(Mapper.Map<BankAccountDTO>(this._testAccount));
            this._storage.Setup(x => x.Update(It.IsAny<BankAccountDTO>())).Returns<BankAccountDTO>(account => account);
            this._service = new BankAccountService(this._storage.Object);
            this._service.AddAccount(this._testAccount);
        }

        [Test]
        public void AddAccountTest()
        {
            var newAccount = new BankAccount(2, "FirstName", "Surname", 20, 0, false, BankAccountTypes.Standart, 1);
            Assert.IsNotNull(this._service.AddAccount(newAccount));
        }

        [Test]
        public void AddAccountTest_NullArgument_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this._service.AddAccount(null));
        }

        [TestCase(20, ExpectedResult = 60)]
        public decimal DepositTest(decimal amount)
        {
            return this._service.Deposit(amount, this._testAccount.AccountId).Ammount;
        }

        [TestCase(20)]
        public void DepositTest_WrongAccountId_ArgumentException(decimal amount)
        {
            Assert.Throws<ArgumentException>(() => this._service.Deposit(amount, 100));
        }

        [TestCase(20, ExpectedResult = 20)]
        public decimal WithdrawTest(decimal amount)
        {
            return this._service.Withdraw(amount, this._testAccount.AccountId).Ammount;
        }

        [TestCase(20)]
        public void WhithdrawTest_WrongAccountId_ArgumentException(decimal amount)
        {
            Assert.Throws<ArgumentException>(() => this._service.Withdraw(amount, 100));
        }

        [Test]
        public void CloseAnAccountTest()
        {
            Assert.IsTrue(this._service.CloseAnAccount(this._testAccount.AccountId).IsClosed);
        }

        [Test]
        public void CloseAnAccountTest_WrongAccountId_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => this._service.CloseAnAccount(100));
        }
    }
}