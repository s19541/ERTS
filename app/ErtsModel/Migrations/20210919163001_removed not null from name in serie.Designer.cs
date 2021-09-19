﻿// <auto-generated />
using System;
using ErtsModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ErtsModel.Migrations
{
    [DbContext(typeof(ErtsContext))]
    [Migration("20210919163001_removed not null from name in serie")]
    partial class removednotnullfromnameinserie
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ErtsModel.Entities.Game", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp without time zone")
                        .HasComment("End time");

                    b.Property<long?>("MatchId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone")
                        .HasComment("Start time");

                    b.Property<long?>("WinnerTeamId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("WinnerTeamId");

                    b.ToTable("Games");

                    b
                        .HasComment("Game");
                });

            modelBuilder.Entity("ErtsModel.Entities.League", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ApiId")
                        .HasColumnType("integer")
                        .HasComment("ApiId");

                    b.Property<string>("GameType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("Game type");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text")
                        .HasComment("Image url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("Name");

                    b.Property<string>("Url")
                        .HasColumnType("text")
                        .HasComment("Url");

                    b.HasKey("Id");

                    b.ToTable("Leagues");

                    b
                        .HasComment("League");
                });

            modelBuilder.Entity("ErtsModel.Entities.Lol.LolChampion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text")
                        .HasComment("Image url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("Name");

                    b.HasKey("Id");

                    b.ToTable("LolChampions");

                    b
                        .HasComment("Lol Champion");
                });

            modelBuilder.Entity("ErtsModel.Entities.Lol.LolGamePlayer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Assists")
                        .HasColumnType("integer")
                        .HasComment("Assists");

                    b.Property<long?>("ChampionId")
                        .HasColumnType("bigint");

                    b.Property<int>("DamageDealt")
                        .HasColumnType("integer")
                        .HasComment("Damage dealt");

                    b.Property<int>("DamageDealtToChamps")
                        .HasColumnType("integer")
                        .HasComment("Damage dealt to champs");

                    b.Property<int>("DamageTaken")
                        .HasColumnType("integer")
                        .HasComment("Damage taken");

                    b.Property<int>("Deaths")
                        .HasColumnType("integer")
                        .HasComment("Deaths");

                    b.Property<int>("EnemyNeutralMinionsKilled")
                        .HasColumnType("integer");

                    b.Property<bool>("FirstBlood")
                        .HasColumnType("boolean")
                        .HasComment("First blood");

                    b.Property<bool>("FirstBloodAssist")
                        .HasColumnType("boolean")
                        .HasComment("Total blood assits");

                    b.Property<long?>("GameId")
                        .HasColumnType("bigint");

                    b.Property<int>("GoldEarned")
                        .HasColumnType("integer")
                        .HasComment("Gold earned");

                    b.Property<int>("GoldSpent")
                        .HasColumnType("integer")
                        .HasComment("Gold spent");

                    b.Property<int>("InhibitorsDestroyed")
                        .HasColumnType("integer")
                        .HasComment("Inhibitor destroyed");

                    b.Property<int>("Kills")
                        .HasColumnType("integer")
                        .HasComment("Kills");

                    b.Property<int>("LargestCriticalStrike")
                        .HasColumnType("integer")
                        .HasComment("Largest critical strike");

                    b.Property<int>("LargestKillingSpree")
                        .HasColumnType("integer")
                        .HasComment("Largest killing spree");

                    b.Property<int>("LargestMultiKill")
                        .HasColumnType("integer")
                        .HasComment("Largest multi kill");

                    b.Property<int>("Level")
                        .HasColumnType("integer")
                        .HasComment("Level");

                    b.Property<int>("MagicDamageDealt")
                        .HasColumnType("integer")
                        .HasComment("Magic damage dealt");

                    b.Property<int>("MagicDamageDealtToChamps")
                        .HasColumnType("integer")
                        .HasComment("Magic damage dealt to champs");

                    b.Property<int>("MinionsKilled")
                        .HasColumnType("integer")
                        .HasComment("Minions killed");

                    b.Property<int>("NeutralMinionsKilled")
                        .HasColumnType("integer")
                        .HasComment("Neutral minions killed");

                    b.Property<int>("PhysicalDamageDealt")
                        .HasColumnType("integer")
                        .HasComment("Physical damage dealt");

                    b.Property<int>("PhysicalDamageDealtToChamps")
                        .HasColumnType("integer")
                        .HasComment("Physical damage dealt to champs");

                    b.Property<long?>("PlayerId")
                        .HasColumnType("bigint");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasComment("Role");

                    b.Property<long?>("Spell1Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("Spell2Id")
                        .HasColumnType("bigint");

                    b.Property<int>("TotalHeal")
                        .HasColumnType("integer")
                        .HasComment("Total heal");

                    b.Property<int>("TotalTimeCrowdControlDealt")
                        .HasColumnType("integer")
                        .HasComment("Total time crowd control dealt");

                    b.Property<int>("TrueDamageDealt")
                        .HasColumnType("integer")
                        .HasComment("True damage dealt");

                    b.Property<int>("TrueDamageDealtToChamps")
                        .HasColumnType("integer")
                        .HasComment("True damage dealt to champs");

                    b.Property<int>("TurretsDestroyed")
                        .HasColumnType("integer")
                        .HasComment("Turrets destroyed");

                    b.Property<int>("WardsDestroyed")
                        .HasColumnType("integer")
                        .HasComment("Wards destroyed");

                    b.Property<int>("WardsPlaced")
                        .HasColumnType("integer")
                        .HasComment("Wards placed");

                    b.HasKey("Id");

                    b.HasIndex("ChampionId");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("Spell1Id");

                    b.HasIndex("Spell2Id");

                    b.ToTable("LolGamePlayers");

                    b
                        .HasComment("Player stats in game");
                });

            modelBuilder.Entity("ErtsModel.Entities.Lol.LolGamePlayerItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("GamePlayerId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ItemId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GamePlayerId");

                    b.HasIndex("ItemId");

                    b.ToTable("LolGamePlayerItems");

                    b
                        .HasComment("items of player in game");
                });

            modelBuilder.Entity("ErtsModel.Entities.Lol.LolGameTeam", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("Ban1Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("Ban2Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("Ban3Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("Ban4Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("Ban5Id")
                        .HasColumnType("bigint");

                    b.Property<int>("BaronKilled")
                        .HasColumnType("integer")
                        .HasComment("Baron killed");

                    b.Property<int>("CloudDrakeKilled")
                        .HasColumnType("integer")
                        .HasComment("Cloud drake killed");

                    b.Property<int>("Color")
                        .HasColumnType("integer")
                        .HasComment("Color");

                    b.Property<int>("ElderDrakeKilled")
                        .HasColumnType("integer")
                        .HasComment("Elder drake killed");

                    b.Property<bool>("FirstBaron")
                        .HasColumnType("boolean")
                        .HasComment("First baron");

                    b.Property<bool>("FirstBlood")
                        .HasColumnType("boolean")
                        .HasComment("First blood");

                    b.Property<bool>("FirstDragon")
                        .HasColumnType("boolean");

                    b.Property<bool>("FirstInhibitor")
                        .HasColumnType("boolean");

                    b.Property<bool>("FirstTurret")
                        .HasColumnType("boolean");

                    b.Property<long?>("GameId")
                        .HasColumnType("bigint");

                    b.Property<int>("GoldEarned")
                        .HasColumnType("integer")
                        .HasComment("Gold earned");

                    b.Property<int>("HeraldKilled")
                        .HasColumnType("integer")
                        .HasComment("Herald killed");

                    b.Property<int>("InfernalDrakeKilled")
                        .HasColumnType("integer")
                        .HasComment("Infernal drake killed");

                    b.Property<int>("InhibitorDestroyed")
                        .HasColumnType("integer");

                    b.Property<int>("Kills")
                        .HasColumnType("integer")
                        .HasComment("Kills");

                    b.Property<int>("MountainDrakeKilled")
                        .HasColumnType("integer")
                        .HasComment("First inhibitor");

                    b.Property<int>("OceanDrakeKilled")
                        .HasColumnType("integer")
                        .HasComment("Ocean drake killed");

                    b.Property<long?>("TeamId")
                        .HasColumnType("bigint");

                    b.Property<int>("TurretDestroyed")
                        .HasColumnType("integer")
                        .HasComment("Inhibitor destroyed");

                    b.HasKey("Id");

                    b.HasIndex("Ban1Id");

                    b.HasIndex("Ban2Id");

                    b.HasIndex("Ban3Id");

                    b.HasIndex("Ban4Id");

                    b.HasIndex("Ban5Id");

                    b.HasIndex("GameId");

                    b.HasIndex("TeamId");

                    b.ToTable("LolGameTeam");

                    b
                        .HasComment("Team stats in game");
                });

            modelBuilder.Entity("ErtsModel.Entities.Lol.LolItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text")
                        .HasComment("Image url");

                    b.Property<bool>("IsTrinket")
                        .HasColumnType("boolean")
                        .HasComment("Is trinket");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("Name");

                    b.HasKey("Id");

                    b.ToTable("LolItems");

                    b
                        .HasComment("Lol Item");
                });

            modelBuilder.Entity("ErtsModel.Entities.Lol.LolSpell", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text")
                        .HasComment("Image url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("Name");

                    b.HasKey("Id");

                    b.ToTable("LolSpells");

                    b
                        .HasComment("Lol Spell");
                });

            modelBuilder.Entity("ErtsModel.Entities.Lol.LolTournamentPlayer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("AverageAssists")
                        .HasColumnType("double precision")
                        .HasComment("AverageAssists");

                    b.Property<double>("AverageDeaths")
                        .HasColumnType("double precision")
                        .HasComment("AverageDeaths");

                    b.Property<double>("AverageKills")
                        .HasColumnType("double precision")
                        .HasComment("AverageKills");

                    b.Property<double>("AverageMinionsKilled")
                        .HasColumnType("double precision")
                        .HasComment("AverageMinionsKilled");

                    b.Property<long?>("ChampionId1")
                        .HasColumnType("bigint");

                    b.Property<long?>("ChampionId2")
                        .HasColumnType("bigint");

                    b.Property<long?>("ChampionId3")
                        .HasColumnType("bigint");

                    b.Property<long?>("PlayerId")
                        .HasColumnType("bigint");

                    b.Property<long?>("TournamentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ChampionId1");

                    b.HasIndex("ChampionId2");

                    b.HasIndex("ChampionId3");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TournamentId");

                    b.ToTable("LolTournamentPlayers");

                    b
                        .HasComment("Tournament to player");
                });

            modelBuilder.Entity("ErtsModel.Entities.LolTournamentTeam", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("AverageAssists")
                        .HasColumnType("double precision")
                        .HasComment("AverageAssists");

                    b.Property<double>("AverageBaronKilled")
                        .HasColumnType("double precision")
                        .HasComment("AverageBaronKilled");

                    b.Property<double>("AverageDeaths")
                        .HasColumnType("double precision")
                        .HasComment("AverageDeaths");

                    b.Property<double>("AverageDragonKilled")
                        .HasColumnType("double precision")
                        .HasComment("AverageDragonKilled");

                    b.Property<double>("AverageGoldEarned")
                        .HasColumnType("double precision")
                        .HasComment("AverageGoldEarned");

                    b.Property<double>("AverageHeraldKilled")
                        .HasColumnType("double precision")
                        .HasComment("AverageHeraldKilled");

                    b.Property<double>("AverageKills")
                        .HasColumnType("double precision")
                        .HasComment("AverageKills");

                    b.Property<double>("AverageTowerDestroyed")
                        .HasColumnType("double precision")
                        .HasComment("AverageTowerDestroyed");

                    b.Property<long?>("ChampionId1")
                        .HasColumnType("bigint");

                    b.Property<long?>("ChampionId2")
                        .HasColumnType("bigint");

                    b.Property<long?>("ChampionId3")
                        .HasColumnType("bigint");

                    b.Property<long?>("ChampionId4")
                        .HasColumnType("bigint");

                    b.Property<long?>("ChampionId5")
                        .HasColumnType("bigint");

                    b.Property<int>("GamesLost")
                        .HasColumnType("integer")
                        .HasComment("GamesLost");

                    b.Property<int>("GamesWon")
                        .HasColumnType("integer")
                        .HasComment("GamesWon");

                    b.Property<int>("MatchesLost")
                        .HasColumnType("integer")
                        .HasComment("MatchesLost");

                    b.Property<int>("MatchesWon")
                        .HasColumnType("integer")
                        .HasComment("MatchesWon");

                    b.Property<long?>("TeamId")
                        .HasColumnType("bigint");

                    b.Property<long?>("TournamentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ChampionId1");

                    b.HasIndex("ChampionId2");

                    b.HasIndex("ChampionId3");

                    b.HasIndex("ChampionId4");

                    b.HasIndex("ChampionId5");

                    b.HasIndex("TeamId");

                    b.HasIndex("TournamentId");

                    b.ToTable("LolTournamentTeams");

                    b
                        .HasComment("Tournament to team");
                });

            modelBuilder.Entity("ErtsModel.Entities.Match", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ApiId")
                        .HasColumnType("integer")
                        .HasComment("ApiId");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("timestamp without time zone")
                        .HasComment("End time");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("timestamp without time zone")
                        .HasComment("Start time");

                    b.Property<string>("StreamUrl")
                        .HasColumnType("text")
                        .HasComment("Stream url");

                    b.Property<long?>("Team1Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("Team2Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("tournamentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Team1Id");

                    b.HasIndex("Team2Id");

                    b.HasIndex("tournamentId");

                    b.ToTable("Matches");

                    b
                        .HasComment("Lol game stats");
                });

            modelBuilder.Entity("ErtsModel.Entities.Player", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ApiId")
                        .HasColumnType("integer")
                        .HasComment("ApiId");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasComment("First Name");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasComment("Last Name");

                    b.Property<string>("Nationality")
                        .HasColumnType("text")
                        .HasComment("Nationality");

                    b.Property<string>("Nick")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("Nickname");

                    b.Property<long>("TeamId")
                        .HasColumnType("bigint")
                        .HasComment("Team ID");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");

                    b
                        .HasComment("Players");
                });

            modelBuilder.Entity("ErtsModel.Entities.Serie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ApiId")
                        .HasColumnType("integer")
                        .HasComment("ApiId");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("timestamp without time zone")
                        .HasComment("End time");

                    b.Property<long?>("LeagueId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasComment("Name");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("timestamp without time zone")
                        .HasComment("Start time");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.ToTable("Series");

                    b
                        .HasComment("Serie");
                });

            modelBuilder.Entity("ErtsModel.Entities.Team", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Acronym")
                        .HasColumnType("text")
                        .HasComment("Acronym");

                    b.Property<int>("ApiId")
                        .HasColumnType("integer")
                        .HasComment("ApiId");

                    b.Property<string>("GameType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("Game type");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text")
                        .HasComment("Image url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("Name");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b
                        .HasComment("Team");
                });

            modelBuilder.Entity("ErtsModel.Entities.Tournament", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ApiId")
                        .HasColumnType("integer")
                        .HasComment("ApiId");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp without time zone")
                        .HasComment("End time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("Name");

                    b.Property<double>("PrizePool")
                        .HasColumnType("double precision")
                        .HasComment("Prize pool");

                    b.Property<long?>("SerieId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone")
                        .HasComment("Start time");

                    b.HasKey("Id");

                    b.HasIndex("SerieId");

                    b.ToTable("Tournaments");

                    b
                        .HasComment("Tournament");
                });

            modelBuilder.Entity("ErtsModel.Entities.Game", b =>
                {
                    b.HasOne("ErtsModel.Entities.Match", null)
                        .WithMany("Games")
                        .HasForeignKey("MatchId");

                    b.HasOne("ErtsModel.Entities.Team", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerTeamId");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("ErtsModel.Entities.Lol.LolGamePlayer", b =>
                {
                    b.HasOne("ErtsModel.Entities.Lol.LolChampion", "Champion")
                        .WithMany()
                        .HasForeignKey("ChampionId");

                    b.HasOne("ErtsModel.Entities.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId");

                    b.HasOne("ErtsModel.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");

                    b.HasOne("ErtsModel.Entities.Lol.LolSpell", "Spell1")
                        .WithMany()
                        .HasForeignKey("Spell1Id");

                    b.HasOne("ErtsModel.Entities.Lol.LolSpell", "Spell2")
                        .WithMany()
                        .HasForeignKey("Spell2Id");

                    b.Navigation("Champion");

                    b.Navigation("Game");

                    b.Navigation("Player");

                    b.Navigation("Spell1");

                    b.Navigation("Spell2");
                });

            modelBuilder.Entity("ErtsModel.Entities.Lol.LolGamePlayerItem", b =>
                {
                    b.HasOne("ErtsModel.Entities.Lol.LolGamePlayer", "GamePlayer")
                        .WithMany()
                        .HasForeignKey("GamePlayerId");

                    b.HasOne("ErtsModel.Entities.Lol.LolItem", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.Navigation("GamePlayer");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("ErtsModel.Entities.Lol.LolGameTeam", b =>
                {
                    b.HasOne("ErtsModel.Entities.Lol.LolChampion", "Ban1")
                        .WithMany()
                        .HasForeignKey("Ban1Id");

                    b.HasOne("ErtsModel.Entities.Lol.LolChampion", "Ban2")
                        .WithMany()
                        .HasForeignKey("Ban2Id");

                    b.HasOne("ErtsModel.Entities.Lol.LolChampion", "Ban3")
                        .WithMany()
                        .HasForeignKey("Ban3Id");

                    b.HasOne("ErtsModel.Entities.Lol.LolChampion", "Ban4")
                        .WithMany()
                        .HasForeignKey("Ban4Id");

                    b.HasOne("ErtsModel.Entities.Lol.LolChampion", "Ban5")
                        .WithMany()
                        .HasForeignKey("Ban5Id");

                    b.HasOne("ErtsModel.Entities.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId");

                    b.HasOne("ErtsModel.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.Navigation("Ban1");

                    b.Navigation("Ban2");

                    b.Navigation("Ban3");

                    b.Navigation("Ban4");

                    b.Navigation("Ban5");

                    b.Navigation("Game");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("ErtsModel.Entities.Lol.LolTournamentPlayer", b =>
                {
                    b.HasOne("ErtsModel.Entities.Lol.LolChampion", "FavouriteChampion1")
                        .WithMany()
                        .HasForeignKey("ChampionId1");

                    b.HasOne("ErtsModel.Entities.Lol.LolChampion", "FavouriteChampion2")
                        .WithMany()
                        .HasForeignKey("ChampionId2");

                    b.HasOne("ErtsModel.Entities.Lol.LolChampion", "FavouriteChampion3")
                        .WithMany()
                        .HasForeignKey("ChampionId3");

                    b.HasOne("ErtsModel.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");

                    b.HasOne("ErtsModel.Entities.Tournament", "Tournament")
                        .WithMany()
                        .HasForeignKey("TournamentId");

                    b.Navigation("FavouriteChampion1");

                    b.Navigation("FavouriteChampion2");

                    b.Navigation("FavouriteChampion3");

                    b.Navigation("Player");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("ErtsModel.Entities.LolTournamentTeam", b =>
                {
                    b.HasOne("ErtsModel.Entities.Lol.LolChampion", "FavouriteChampion1")
                        .WithMany()
                        .HasForeignKey("ChampionId1");

                    b.HasOne("ErtsModel.Entities.Lol.LolChampion", "FavouriteChampion2")
                        .WithMany()
                        .HasForeignKey("ChampionId2");

                    b.HasOne("ErtsModel.Entities.Lol.LolChampion", "FavouriteChampion3")
                        .WithMany()
                        .HasForeignKey("ChampionId3");

                    b.HasOne("ErtsModel.Entities.Lol.LolChampion", "FavouriteChampion4")
                        .WithMany()
                        .HasForeignKey("ChampionId4");

                    b.HasOne("ErtsModel.Entities.Lol.LolChampion", "FavouriteChampion5")
                        .WithMany()
                        .HasForeignKey("ChampionId5");

                    b.HasOne("ErtsModel.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.HasOne("ErtsModel.Entities.Tournament", "Tournament")
                        .WithMany()
                        .HasForeignKey("TournamentId");

                    b.Navigation("FavouriteChampion1");

                    b.Navigation("FavouriteChampion2");

                    b.Navigation("FavouriteChampion3");

                    b.Navigation("FavouriteChampion4");

                    b.Navigation("FavouriteChampion5");

                    b.Navigation("Team");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("ErtsModel.Entities.Match", b =>
                {
                    b.HasOne("ErtsModel.Entities.Team", "Team1")
                        .WithMany()
                        .HasForeignKey("Team1Id");

                    b.HasOne("ErtsModel.Entities.Team", "Team2")
                        .WithMany()
                        .HasForeignKey("Team2Id");

                    b.HasOne("ErtsModel.Entities.Tournament", "Tournament")
                        .WithMany()
                        .HasForeignKey("tournamentId");

                    b.Navigation("Team1");

                    b.Navigation("Team2");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("ErtsModel.Entities.Player", b =>
                {
                    b.HasOne("ErtsModel.Entities.Team", null)
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ErtsModel.Entities.Serie", b =>
                {
                    b.HasOne("ErtsModel.Entities.League", "League")
                        .WithMany()
                        .HasForeignKey("LeagueId");

                    b.Navigation("League");
                });

            modelBuilder.Entity("ErtsModel.Entities.Tournament", b =>
                {
                    b.HasOne("ErtsModel.Entities.Serie", "Serie")
                        .WithMany()
                        .HasForeignKey("SerieId");

                    b.Navigation("Serie");
                });

            modelBuilder.Entity("ErtsModel.Entities.Match", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("ErtsModel.Entities.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
