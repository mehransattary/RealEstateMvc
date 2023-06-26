namespace MoshaverDataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        ImgPath = c.String(),
                        Text = c.String(nullable: false, maxLength: 400),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ImgPath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        cityname = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MelkId = c.Int(nullable: false),
                        ParentId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        TextComment = c.String(nullable: false),
                        Date = c.String(),
                        IsShow = c.Boolean(nullable: false),
                        OkAnswer = c.Boolean(nullable: false),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Melks", t => t.MelkId, cascadeDelete: true)
                .ForeignKey("dbo.Comments", t => t.ParentId)
                .Index(t => t.MelkId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Melks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        cityId = c.Int(nullable: false),
                        ImgL = c.String(maxLength: 300),
                        ImgS = c.String(maxLength: 300),
                        ImgB = c.String(maxLength: 300),
                        addressId = c.String(nullable: false),
                        typecustumerId = c.Int(nullable: false),
                        typeEmkanatId = c.String(nullable: false),
                        typeGardadId = c.Int(nullable: false),
                        typeMahdodeId = c.Int(nullable: false),
                        typeMelkId = c.Int(nullable: false),
                        typeSanadId = c.Int(nullable: false),
                        Meter = c.Int(nullable: false),
                        PriceMeter = c.Double(nullable: false),
                        locationSN = c.String(maxLength: 50),
                        TypeEskelet = c.String(maxLength: 50),
                        GedmatSakht = c.Int(nullable: false),
                        Zirbana = c.Int(nullable: false),
                        CountTabagat = c.Int(nullable: false),
                        NumberTabage = c.Int(nullable: false),
                        NumberVahed = c.Int(nullable: false),
                        PriceAll = c.Double(nullable: false),
                        DateCreate = c.String(),
                        SpecialAmlak = c.Boolean(nullable: false),
                        Rooms = c.Int(nullable: false),
                        Wc = c.Int(nullable: false),
                        IsShow = c.Boolean(nullable: false),
                        typeWriter = c.Int(nullable: false),
                        userId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.cityId, cascadeDelete: true)
                .ForeignKey("dbo.TypeCustumers", t => t.typecustumerId, cascadeDelete: true)
                .ForeignKey("dbo.TypeGardads", t => t.typeGardadId, cascadeDelete: true)
                .ForeignKey("dbo.TypeMahdodes", t => t.typeMahdodeId, cascadeDelete: true)
                .ForeignKey("dbo.TypeMelks", t => t.typeMelkId, cascadeDelete: true)
                .ForeignKey("dbo.TypeSanads", t => t.typeSanadId, cascadeDelete: true)
                .Index(t => t.cityId)
                .Index(t => t.typecustumerId)
                .Index(t => t.typeGardadId)
                .Index(t => t.typeMahdodeId)
                .Index(t => t.typeMelkId)
                .Index(t => t.typeSanadId);
            
            CreateTable(
                "dbo.TypeCustumers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Custumer = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeGardads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        typegardadname = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeMahdodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        typemahdodename = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeMelks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        typemelkname = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeSanads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        typesanadname = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MelkId = c.Int(nullable: false),
                        ImgGalleryL = c.String(maxLength: 300),
                        ImgGalleryS = c.String(maxLength: 300),
                        ImgGalleryB = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Melks", t => t.MelkId, cascadeDelete: true)
                .Index(t => t.MelkId);
            
            CreateTable(
                "dbo.ItemMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ZirmenuId = c.Int(nullable: false),
                        ItemName = c.String(),
                        ItemNameId = c.Int(),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ZirMenus", t => t.ZirmenuId, cascadeDelete: true)
                .Index(t => t.ZirmenuId);
            
            CreateTable(
                "dbo.ZirMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuId = c.Int(nullable: false),
                        zirMenuName = c.String(),
                        zirMenuNameId = c.Int(),
                        Order = c.Int(nullable: false),
                        Isitems = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.MenuId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuName = c.String(nullable: false, maxLength: 20),
                        MenuOrder = c.Int(nullable: false),
                        IsMenuItems = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameStore = c.String(nullable: false, maxLength: 50),
                        AddressStore1 = c.String(maxLength: 60),
                        AddressStore2 = c.String(maxLength: 60),
                        EmailStore1 = c.String(maxLength: 30),
                        EmailStore2 = c.String(maxLength: 30),
                        TellPhone1 = c.String(maxLength: 20),
                        TellPhone2 = c.String(maxLength: 20),
                        addressPosti = c.String(maxLength: 20),
                        WorkTime = c.String(maxLength: 60),
                        AboutMe = c.String(),
                        imageSrc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SliderIMG = c.String(),
                        MelkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Socials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocialName = c.String(nullable: false, maxLength: 100),
                        SocialIcon = c.String(),
                        SocialLink = c.String(maxLength: 200),
                        NotShow = c.Boolean(nullable: false),
                        SocialOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UsualQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Text = c.String(nullable: false),
                        Title2 = c.String(nullable: false, maxLength: 50),
                        Text2 = c.String(nullable: false),
                        Title3 = c.String(nullable: false, maxLength: 50),
                        Text3 = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ItemMenus", "ZirmenuId", "dbo.ZirMenus");
            DropForeignKey("dbo.ZirMenus", "MenuId", "dbo.Menus");
            DropForeignKey("dbo.Galleries", "MelkId", "dbo.Melks");
            DropForeignKey("dbo.Comments", "ParentId", "dbo.Comments");
            DropForeignKey("dbo.Comments", "MelkId", "dbo.Melks");
            DropForeignKey("dbo.Melks", "typeSanadId", "dbo.TypeSanads");
            DropForeignKey("dbo.Melks", "typeMelkId", "dbo.TypeMelks");
            DropForeignKey("dbo.Melks", "typeMahdodeId", "dbo.TypeMahdodes");
            DropForeignKey("dbo.Melks", "typeGardadId", "dbo.TypeGardads");
            DropForeignKey("dbo.Melks", "typecustumerId", "dbo.TypeCustumers");
            DropForeignKey("dbo.Melks", "cityId", "dbo.Cities");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ZirMenus", new[] { "MenuId" });
            DropIndex("dbo.ItemMenus", new[] { "ZirmenuId" });
            DropIndex("dbo.Galleries", new[] { "MelkId" });
            DropIndex("dbo.Melks", new[] { "typeSanadId" });
            DropIndex("dbo.Melks", new[] { "typeMelkId" });
            DropIndex("dbo.Melks", new[] { "typeMahdodeId" });
            DropIndex("dbo.Melks", new[] { "typeGardadId" });
            DropIndex("dbo.Melks", new[] { "typecustumerId" });
            DropIndex("dbo.Melks", new[] { "cityId" });
            DropIndex("dbo.Comments", new[] { "ParentId" });
            DropIndex("dbo.Comments", new[] { "MelkId" });
            DropTable("dbo.UsualQuestions");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Socials");
            DropTable("dbo.Sliders");
            DropTable("dbo.Settings");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Menus");
            DropTable("dbo.ZirMenus");
            DropTable("dbo.ItemMenus");
            DropTable("dbo.Galleries");
            DropTable("dbo.TypeSanads");
            DropTable("dbo.TypeMelks");
            DropTable("dbo.TypeMahdodes");
            DropTable("dbo.TypeGardads");
            DropTable("dbo.TypeCustumers");
            DropTable("dbo.Melks");
            DropTable("dbo.Comments");
            DropTable("dbo.Cities");
            DropTable("dbo.Brands");
            DropTable("dbo.Advertises");
        }
    }
}
