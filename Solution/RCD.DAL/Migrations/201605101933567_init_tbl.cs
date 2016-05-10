namespace RCD.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_tbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblFile",
                c => new
                    {
                        FileID = c.Int(nullable: false, identity: true),
                        Path = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        UserID = c.Int(nullable: false),
                        FileTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileID)
                .ForeignKey("dbo.tblFileType", t => t.FileTypeID, cascadeDelete: true)
                .ForeignKey("dbo.tblUser", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.FileTypeID);
            
            CreateTable(
                "dbo.tblFileType",
                c => new
                    {
                        FileTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FileTypeID);
            
            CreateTable(
                "dbo.tblUser",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        IsActive = c.Boolean(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .Index(t => t.Username, unique: true)
                .Index(t => t.Password, unique: true);
            
            CreateTable(
                "dbo.tblMetadata",
                c => new
                    {
                        MetadataID = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                        FileID = c.Int(nullable: false),
                        MetadataTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MetadataID)
                .ForeignKey("dbo.tblFile", t => t.FileID, cascadeDelete: true)
                .ForeignKey("dbo.tblMetadataType", t => t.MetadataTypeID, cascadeDelete: true)
                .Index(t => t.FileID)
                .Index(t => t.MetadataTypeID);
            
            CreateTable(
                "dbo.tblMetadataType",
                c => new
                    {
                        MetadataTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MetadataTypeID);
            
            CreateTable(
                "dbo.tblSetting",
                c => new
                    {
                        SettingID = c.Int(nullable: false, identity: true),
                        PeriodTime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SettingID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblMetadata", "MetadataTypeID", "dbo.tblMetadataType");
            DropForeignKey("dbo.tblMetadata", "FileID", "dbo.tblFile");
            DropForeignKey("dbo.tblFile", "UserID", "dbo.tblUser");
            DropForeignKey("dbo.tblFile", "FileTypeID", "dbo.tblFileType");
            DropIndex("dbo.tblMetadata", new[] { "MetadataTypeID" });
            DropIndex("dbo.tblMetadata", new[] { "FileID" });
            DropIndex("dbo.tblUser", new[] { "Password" });
            DropIndex("dbo.tblUser", new[] { "Username" });
            DropIndex("dbo.tblFile", new[] { "FileTypeID" });
            DropIndex("dbo.tblFile", new[] { "UserID" });
            DropTable("dbo.tblSetting");
            DropTable("dbo.tblMetadataType");
            DropTable("dbo.tblMetadata");
            DropTable("dbo.tblUser");
            DropTable("dbo.tblFileType");
            DropTable("dbo.tblFile");
        }
    }
}
