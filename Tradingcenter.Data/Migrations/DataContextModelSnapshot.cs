﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tradingcenter.Data;

namespace Tradingcenter.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Trainingcenter.Domain.DomainModels.ExchangeKey", b =>
                {
                    b.Property<int>("ExchangeKeyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key")
                        .IsRequired();

                    b.Property<int>("LastId");

                    b.Property<DateTime>("LastRefresh");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Secret")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("ExchangeKeyId");

                    b.HasIndex("UserId");

                    b.ToTable("ExchangeKeys");
                });

            modelBuilder.Entity("Trainingcenter.Domain.DomainModels.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Message")
                        .IsRequired();

                    b.Property<int>("PortfolioId");

                    b.HasKey("NoteId");

                    b.HasIndex("PortfolioId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Trainingcenter.Domain.DomainModels.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Currency")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("Exchange")
                        .IsRequired();

                    b.Property<int>("ExchangeKeyId");

                    b.Property<string>("ExchangeOrderId")
                        .IsRequired();

                    b.Property<string>("ImgURL");

                    b.Property<bool>("IsSold");

                    b.Property<double>("OrderQty");

                    b.Property<double>("Price");

                    b.Property<string>("Side")
                        .IsRequired();

                    b.Property<string>("Symbol")
                        .IsRequired();

                    b.Property<DateTime>("Timestamp");

                    b.Property<int>("UserId");

                    b.HasKey("OrderId");

                    b.HasIndex("ExchangeKeyId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Trainingcenter.Domain.DomainModels.OrderComment", b =>
                {
                    b.Property<int>("OrderCommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Message")
                        .IsRequired();

                    b.Property<int>("OrderId");

                    b.Property<DateTime>("PostedOn");

                    b.Property<int>("UserId");

                    b.HasKey("OrderCommentId");

                    b.HasIndex("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("OrderComments");
                });

            modelBuilder.Entity("Trainingcenter.Domain.DomainModels.Portfolio", b =>
                {
                    b.Property<int>("PortfolioId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Description");

                    b.Property<string>("Goal");

                    b.Property<string>("ImgURL");

                    b.Property<bool>("IsDefault");

                    b.Property<bool>("IsForSale");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("PortfolioId");

                    b.HasIndex("UserId");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("Trainingcenter.Domain.DomainModels.PortfolioComment", b =>
                {
                    b.Property<int>("PortfolioCommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Message")
                        .IsRequired();

                    b.Property<int?>("OrderId");

                    b.Property<int>("PortfolioId");

                    b.Property<DateTime>("PostedOn");

                    b.Property<int>("UserId");

                    b.HasKey("PortfolioCommentId");

                    b.HasIndex("OrderId");

                    b.HasIndex("PortfolioId");

                    b.HasIndex("UserId");

                    b.ToTable("PortfolioComments");
                });

            modelBuilder.Entity("Trainingcenter.Domain.DomainModels.PortfolioOrder", b =>
                {
                    b.Property<int>("OrderId");

                    b.Property<int>("PortfolioId");

                    b.HasKey("OrderId", "PortfolioId");

                    b.HasIndex("PortfolioId");

                    b.ToTable("OrderPortolios");
                });

            modelBuilder.Entity("Trainingcenter.Domain.DomainModels.PurchasedPortfolio", b =>
                {
                    b.Property<int>("PurchasedPortfolioId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PortfolioId");

                    b.Property<int>("UserId");

                    b.HasKey("PurchasedPortfolioId");

                    b.HasIndex("PortfolioId");

                    b.HasIndex("UserId");

                    b.ToTable("PurchasedPortfolios");
                });

            modelBuilder.Entity("Trainingcenter.Domain.DomainModels.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsVerified");

                    b.Property<DateTime>("LastActive");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired();

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<string>("PictureURL");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.Property<string>("VerificationKey");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Trainingcenter.Domain.DomainModels.Wallet", b =>
                {
                    b.Property<int>("WalletId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<string>("Currency");

                    b.Property<int>("ExchangeKeyId");

                    b.Property<string>("ExchangeTransactionId");

                    b.Property<int>("Fee");

                    b.Property<DateTime>("Timestamp");

                    b.Property<string>("TransactionType");

                    b.Property<int>("Walletbalance");

                    b.HasKey("WalletId");

                    b.HasIndex("ExchangeKeyId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Trainingcenter.Domain.DomainModels.ExchangeKey", b =>
                {
                    b.HasOne("Trainingcenter.Domain.DomainModels.User", "User")
                        .WithMany("ExchangeKeys")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trainingcenter.Domain.DomainModels.Note", b =>
                {
                    b.HasOne("Trainingcenter.Domain.DomainModels.Portfolio", "Portfolio")
                        .WithMany("Notes")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trainingcenter.Domain.DomainModels.Order", b =>
                {
                    b.HasOne("Trainingcenter.Domain.DomainModels.ExchangeKey", "Exchangekey")
                        .WithMany("Orders")
                        .HasForeignKey("ExchangeKeyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trainingcenter.Domain.DomainModels.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trainingcenter.Domain.DomainModels.OrderComment", b =>
                {
                    b.HasOne("Trainingcenter.Domain.DomainModels.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trainingcenter.Domain.DomainModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trainingcenter.Domain.DomainModels.Portfolio", b =>
                {
                    b.HasOne("Trainingcenter.Domain.DomainModels.User", "User")
                        .WithMany("Portfolios")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trainingcenter.Domain.DomainModels.PortfolioComment", b =>
                {
                    b.HasOne("Trainingcenter.Domain.DomainModels.Order")
                        .WithMany("Comments")
                        .HasForeignKey("OrderId");

                    b.HasOne("Trainingcenter.Domain.DomainModels.Portfolio", "Portfolio")
                        .WithMany()
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trainingcenter.Domain.DomainModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trainingcenter.Domain.DomainModels.PortfolioOrder", b =>
                {
                    b.HasOne("Trainingcenter.Domain.DomainModels.Order", "Order")
                        .WithMany("OrderPortfolios")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trainingcenter.Domain.DomainModels.Portfolio", "Portfolio")
                        .WithMany("PortfolioOrders")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trainingcenter.Domain.DomainModels.PurchasedPortfolio", b =>
                {
                    b.HasOne("Trainingcenter.Domain.DomainModels.Portfolio", "Portfolio")
                        .WithMany()
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trainingcenter.Domain.DomainModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trainingcenter.Domain.DomainModels.Wallet", b =>
                {
                    b.HasOne("Trainingcenter.Domain.DomainModels.ExchangeKey", "ExchangeKey")
                        .WithMany("Transactions")
                        .HasForeignKey("ExchangeKeyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
