﻿using System;
using Data.Common.IoCModules;
using Data.Models;
using Data.SQL.Common.IoCModule;
using Data.SQL.EF.IoCModules;
using Data.SQL.InMemory.ApacheIgnite.IoCModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector.Packaging;
using Data.SQL.Combinations.ApacheIgniteAndEF.IoCModule;

namespace Test.Data
{
    [TestClass]
    public class TestCombinationOfEFAndApacheIgniteInsert : BaseTest
    {
        protected override IPackage[] RegisterPackages()
        {
            IPackage[] packages = new IPackage[]
            {
                new TemporaryInMemoryDataStoresModule(),
                new CommanBuildersModule(),
                new DataEntityFrameworkModule(),
                new ApacheIgniteModule(),
                new DataCommitersModule(),
            };

            return packages;
        }

        [TestMethod]
        public void InsertUser()
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Username = "Baba Meca",
                Password = "baba@meca123",
                Email = "baba@meca.com"
            };

            base.userDataStore.AppendForInserting(user);
            base.dataCommiter.Commit();
        }

        [TestMethod]
        public void InsertPromotion()
        {
            Promotion promotion = new Promotion()
            {
                Id = Guid.NewGuid(),
                Name = "promo baba meca",
                CategoryName = "TV"
            };

            base.promotionDataStore.AppendForInserting(promotion);
            base.dataCommiter.Commit();
        }

        [TestMethod]
        public void InsetUserAndPromotion()
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Username = "Baba Meca",
                Password = "baba@meca123",
                Email = "baba@meca.com"
            };

            Promotion promotion = new Promotion()
            {
                Id = Guid.NewGuid(),
                Name = "promo baba meca",
                CategoryName = "TV"
            };

            base.userDataStore.AppendForInserting(user);
            base.promotionDataStore.AppendForInserting(promotion);

            base.dataCommiter.Commit();
        }
    }
}
